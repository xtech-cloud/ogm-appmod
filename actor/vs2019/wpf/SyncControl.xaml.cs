using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Controls;
using HandyControl.Controls;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.ComponentModel;

namespace ogm.actor
{
    public partial class SyncControl : UserControl
    {
        public class SyncUiBridge : ISyncUiBridge
        {
            public SyncControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void RefreshList(string _reply)
            {
                /*
                control.cbDomainList.Items.Clear();
                DomainEntity[] domainList = JsonSerializer.Deserialize<DomainEntity[]>(_reply);
                foreach (var entity in domainList)
                {
                    var item = new ComboBoxItem();
                    item.Content = entity.name;
                    item.Uid = entity.uuid;
                    control.cbDomainList.Items.Add(item);
                }
                if (control.cbDomainList.Items.Count > 0)
                    control.cbDomainList.SelectedIndex = 0;
                */
            }

            public void UpdatePermission(Dictionary<string, string> _permission)
            {
            }

            public void ReceivePull(string _json)
            {
                List<DeviceEntity> needRemove = new List<DeviceEntity>();
                foreach (var e in control.deviceIndexMap.Values)
                {
                    needRemove.Add(e);
                }

                PullReply pullReply = JsonSerializer.Deserialize<PullReply>(_json);
                foreach (var e in pullReply.device)
                {
                    string alias;
                    if (pullReply.alias.TryGetValue(e.uuid, out alias))
                        e._alias = alias;
                    string application;
                    if (pullReply.property.TryGetValue(e.uuid, out application))
                        e._application = application;
                    e._storageAvailable = string.Format("{0} G", e.storageAvailable / 1024 / 1024 / 1024);

                    if (control.deviceIndexMap.ContainsKey(e.uuid))
                    {
                        var device = control.deviceIndexMap[e.uuid];
                        device.Clone(e);
                        if (needRemove.Contains(device))
                            needRemove.Remove(device);
                    }
                    else
                    {
                        control.DeviceList.Add(e);
                        control.deviceIndexMap[e.uuid] = e;
                    }
                }

                // 删除多余的
                foreach (var e in needRemove)
                {
                    control.DeviceList.Remove(e);
                }

                // 重建索引
                control.deviceIndexMap.Clear();
                for (int i = 0; i < control.DeviceList.Count; i++)
                {
                    control.deviceIndexMap[control.DeviceList[i].uuid] = control.DeviceList[i];
                }
            }

            public void ReceiveApplicationList(string _json)
            {
                var reply = JsonSerializer.Deserialize<ApplicationListReply>(_json);
                control.cbApplication.Items.Clear();
                foreach (var e in reply.application)
                {
                    ComboBoxItem item = new ComboBoxItem();
                    item.Content = e.name;
                    item.Uid = e.program;
                    control.cbApplication.Items.Add(item);
                }
            }
        }

        public class PullReply
        {
            public DeviceEntity[] device { get; set; }
            public Dictionary<string, string> property { get; set; }
            public Dictionary<string, string> alias { get; set; }
        }

        public class ApplicationListReply
        {
            public long total { get; set; }
            public ApplicationEntity[] application { get; set; }
        }

        public class DeviceEntity : INotifyPropertyChanged
        {
            public string uuid { get; set; }
            public string serialNumber { get; set; }
            public int battery { get; set; }
            public int volume { get; set; }
            public int brightness { get; set; }
            public long storageAvailable { get; set; }
            public int networkStrength { get; set; }
            public string _alias { get; set; }
            public string _application { get; set; }
            public string _storageAvailable { get; set; }

            public void Clone(DeviceEntity _other)
            {
                battery = _other.battery;
                volume = _other.volume;
                brightness = _other.brightness;
                storageAvailable = _other.storageAvailable;
                networkStrength = _other.networkStrength;
                _alias = _other._alias;
                _application = _other._application;
                _storageAvailable = _other._storageAvailable;
                OnPrepertyChanged("battery");
                OnPrepertyChanged("volume");
                OnPrepertyChanged("brightness");
                OnPrepertyChanged("storageAvailable");
                OnPrepertyChanged("networkStrength");
                OnPrepertyChanged("_alias");
                OnPrepertyChanged("_application");
                OnPrepertyChanged("_storageAvailable");
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPrepertyChanged(string _propertyName)
            {
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
            }
        }

        public class DomainEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
        }

        public class ApplicationEntity
        {
            public string name { get; set; }
            public string program { get; set; }
        }


        public SyncFacade facade { get; set; }
        public ApplicationFacade facadeApplication { get; set; }
        public DomainFacade facadeDomain { get; set; }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }
        public bool isSyncPush = false;

        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        //设备索引
        private Dictionary<string, DeviceEntity> deviceIndexMap { get; set; }

        public SyncControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            deviceIndexMap = new Dictionary<string, DeviceEntity>();
            InitializeComponent();
        }

        public void RefreshWithExtra()
        {
            DeviceList.Clear();
            object o_uuid;
            if (!PageExtra.TryGetValue("domain.uuid", out o_uuid))
                return;
            object o_name;
            if (!PageExtra.TryGetValue("domain.name", out o_name))
                return;
            tbDomain.Uid = (string)o_uuid;
            tbDomain.Text = (string)o_name;
            tbDomain.IsEnabled = false;

            asyncLoopPull();
            listApplication();
        }

        private void onResetCliked(object sender, RoutedEventArgs e)
        {
            tbDomain.Uid = "";
            tbDomain.Text = "";
            DeviceList.Clear();
            isSyncPush = false;
        }

        private void onConnectClicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDomain.Text))
                return;

            asyncLoopPull();
            listApplication();
        }

        private void onDeviceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void pull(string _domainUUID)
        {
            var bridge = facade.getViewBridge() as ISyncViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = _domainUUID;
            string json = JsonSerializer.Serialize(param);
            bridge.OnPullSubmit(json);
        }

        private void onRunClicked(object sender, RoutedEventArgs e)
        {
            string domainUUID = tbDomain.Uid;
            if (string.IsNullOrEmpty(domainUUID))
                return;

            ComboBoxItem application = cbApplication.SelectedItem as ComboBoxItem;
            if (null == application)
                return;

            List<string> deviceAry = new List<string>();
            foreach (var item in dgDeviceList.SelectedItems)
            {
                var device = item as DeviceEntity;
                deviceAry.Add(device.serialNumber);
            }


            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter["program"] = application.Uid;
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(parameter);
            string base64 = Convert.ToBase64String(jsonBytes);

            var bridge = facadeDomain.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = domainUUID;
            param["command"] = "/application/run";
            param["device"] = deviceAry;
            param["parameter"] = base64;
            string json = JsonSerializer.Serialize(param);
            bridge.OnExecuteSubmit(json);
        }

        private void onExitClicked(object sender, RoutedEventArgs e)
        {
            string domainUUID = tbDomain.Uid;
            if (string.IsNullOrEmpty(domainUUID))
                return;

            List<string> deviceAry = new List<string>();
            foreach (var item in dgDeviceList.SelectedItems)
            {
                var device = item as DeviceEntity;
                deviceAry.Add(device.serialNumber);
            }

            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter["program"] = "";
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(parameter);
            string base64 = Convert.ToBase64String(jsonBytes);

            var bridge = facadeDomain.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = domainUUID;
            param["command"] = "/application/exit";
            param["device"] = deviceAry;
            param["parameter"] = base64;
            string json = JsonSerializer.Serialize(param);
            bridge.OnExecuteSubmit(json);
        }

        private async Task asyncLoopPull()
        {
            isSyncPush = true;
            string domainUuid = tbDomain.Uid;
            if (string.IsNullOrEmpty(domainUuid))
                return;
            await Task.Run(() =>
            {
                while (isSyncPush)
                {
                    this.Dispatcher.Invoke(new Action(() => { pull(domainUuid); }));
                    Thread.Sleep(1000);
                }
            });
        }

        private void listApplication()
        {
            string domainUUID = tbDomain.Uid;
            if (string.IsNullOrEmpty(domainUUID))
                return;
            var bridge = facadeApplication.getViewBridge() as IApplicationViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = domainUUID;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }
    }
}
