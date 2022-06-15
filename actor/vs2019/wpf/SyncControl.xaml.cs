using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Text.Json;

namespace ogm.actor
{
    public partial class SyncControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();
        public class SyncUiBridge : BaseSyncUiBridge, ISyncExtendUiBridge
        {
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

            public override void ReceivePull(string _json)
            {

                List<DeviceEntity> needRemove = new List<DeviceEntity>();
                foreach (var e in control.deviceIndexMap.Values)
                {
                    needRemove.Add(e);
                }

                var reply = JsonSerializer.Deserialize<SyncPullReply>(_json);
                foreach (var e in reply.device)
                {
                    string alias;
                    if (reply.alias.TryGetValue(e.uuid, out alias))
                        e._alias = alias;
                    string application;
                    if (reply.property.TryGetValue(e.uuid, out application))
                        e._application = application;
                    int healthy;
                    if (reply.healthy.TryGetValue(e.uuid, out healthy))
                        e._healthy = healthy;
                    e._storageAvailable = string.Format("{0} G", e.storageAvailable / 1024 / 1024 / 1024);

                    // 解析健康值
                    Color healthyColor = Colors.Gray;
                    if (e._healthy > 0)
                    {
                        healthyColor = Colors.Green;
                        e.controllerBattery = 8;
                    }
                    else
                    {
                        e.battery = 0;
                        e.controllerBattery = 0;
                        e.volume = 0;
                        e.brightness = 0;
                        e.networkStrength = 0;
                    }
                    e._healthyIcon = Utility.GeometrySourceFromResource(control, "HealthyGeometry", healthyColor);
                    // 解析截图
                    string captureBase64;
                    if (reply.property.TryGetValue(string.Format("file://{0}/capture", e.serialNumber), out captureBase64))
                    {
                        if (!string.IsNullOrEmpty(captureBase64))
                        {
                            try
                            {
                                byte[] data = Convert.FromBase64String(captureBase64.Replace("-", "+").Replace("_", "/"));
                                e._capture = Utility.ImageFromBytes(data);
                            }
                            catch (System.Exception ex)
                            {
                                Alert(ex.Message);
                            }
                        }

                    }

                    // 解析电量
                    int batteryLevel = (int)(e.battery / 10);
                    Color batteryColor = Colors.Gray;
                    if (batteryLevel > 7)
                        batteryColor = Colors.Green;
                    else if (batteryLevel > 4)
                        batteryColor = Colors.Yellow;
                    else if (batteryLevel > 2)
                        batteryColor = Colors.OrangeRed;
                    else if (batteryLevel > 0)
                        batteryColor = Colors.Red;
                    e._batteryIcon = Utility.GeometrySourceFromResource(control, string.Format("Battery{0}Geometry", batteryLevel), batteryColor);
                    e._controllerIcon = Utility.GeometrySourceFromResource(control, string.Format("Battery{0}Geometry", e.controllerBattery), batteryColor);

                    if (control.deviceIndexMap.ContainsKey(e.uuid))
                    {
                        var device = control.deviceIndexMap[e.uuid];
                        device.CopyFromOther(e);
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

            public override void ReceivePush(string _json)
            {
            }

        }

        public SyncFacade facade { get; set; }

        public ApplicationFacade facadeApplication { get; set; }
        public DomainFacade facadeDomain { get; set; }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }
        public bool isSyncPush = false;
        public string monitorAlias { get; set; }


        //设备索引
        private Dictionary<string, DeviceEntity> deviceIndexMap { get; set; }

        public SyncControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            deviceIndexMap = new Dictionary<string, DeviceEntity>();
            InitializeComponent();
            pageMonitorSingle.Visibility = Visibility.Collapsed;
            pageMonitorWall.Visibility = Visibility.Visible;
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

        private void onCloseMonitorClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            pageMonitorSingle.Visibility = Visibility.Collapsed;
            pageMonitorWall.Visibility = Visibility.Visible;
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            DeviceList.Clear();
            isSyncPush = false;
        }

        private void onConnectClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDomain.Text))
                return;

            asyncLoopPull();
            listApplication();
        }

        private void onRunClicked(object sender, System.Windows.RoutedEventArgs e)
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

        private void onExitClicked(object sender, System.Windows.RoutedEventArgs e)
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

        private void onCaptureClicked(object sender, RoutedEventArgs e)
        {
            string domainUUID = tbDomain.Uid;
            if (string.IsNullOrEmpty(domainUUID))
                return;

            List<string> deviceAry = new List<string>();
            foreach (var item in DeviceList)
            {
                deviceAry.Add(item.serialNumber);
            }

            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter["program"] = "";
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes(parameter);
            string base64 = Convert.ToBase64String(jsonBytes);

            var bridge = facadeDomain.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = domainUUID;
            param["command"] = "/system/capture";
            param["device"] = deviceAry;
            param["parameter"] = base64;
            string json = JsonSerializer.Serialize(param);
            bridge.OnExecuteSubmit(json);

        }

        private void onDeviceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void onFocusMonitorClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            pageMonitorSingle.Visibility = Visibility.Visible;
            pageMonitorWall.Visibility = Visibility.Collapsed;


            Button btn = sender as Button;
            if (null == btn)
                return;
            lMonitorAlias.Content = btn.Tag.ToString();

            imgMonitorCapture.Source = null;
            foreach (var device in DeviceList)
            {
                if (device._alias.Equals(btn.Tag.ToString()))
                {
                    imgMonitorCapture.Source = device._capture;
                    break;
                }
            }
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

        private void pull(string _domainUUID)
        {
            var bridge = facade.getViewBridge() as ISyncViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = _domainUUID;
            var propertyList = new List<string>();
            param["downProperty"] = propertyList;
            foreach (var device in DeviceList)
            {
                propertyList.Add(string.Format("file://{0}/capture", device.serialNumber));
            }
            string json = JsonSerializer.Serialize(param);
            bridge.OnPullSubmit(json);
        }

    }
}
