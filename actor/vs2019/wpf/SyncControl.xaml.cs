using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Controls;
using HandyControl.Controls;
using System.Linq;

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
                control.DeviceList.Clear();
                PullReply pullReply = JsonSerializer.Deserialize<PullReply>(_json);
                foreach (var e in pullReply.device)
                {
                    string alias;
                    if (pullReply.alias.TryGetValue(e.uuid, out alias))
                        e._alias = alias;
                    string application;
                    if (pullReply.property.TryGetValue(e.uuid, out application))
                        e._application = application;
                    control.DeviceList.Add(e);
                    e._storageAvailable = string.Format("{0} G", e.storageAvailable / 1024 / 1024 / 1024);
                }
            }
        }

        public class PullReply
        {
            public DeviceEntity[] device { get; set; }
            public Dictionary<string, string> property { get; set; }
            public Dictionary<string, string> alias { get; set; }
        }
        public class DeviceEntity
        {
            public string uuid { get; set; }
            public int battery { get; set; }
            public int volume { get; set; }
            public int brightness { get; set; }
            public long storageAvailable { get; set; }
            public int networkStrength { get; set; }
            public string _alias { get; set; }
            public string _application { get; set; }
            public string _storageAvailable { get; set; }
        }

        public class DomainEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
        }


        public SyncFacade facade { get; set; }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public SyncControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
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

            pull(tbDomain.Uid);
        }

        private void onResetCliked(object sender, RoutedEventArgs e)
        {
            tbDomain.Uid = "";
            tbDomain.Text = "";
            DeviceList.Clear();
        }

        private void onConnectClicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbDomain.Text))
                return;
            pull(tbDomain.Uid);
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

        private void onInstallClicked(object sender, RoutedEventArgs e)
        {

        }

        private void onRunClicked(object sender, RoutedEventArgs e)
        {

        }

        private void onExitClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
