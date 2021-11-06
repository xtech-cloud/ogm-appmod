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
        public class FetchDeviceReply
        {
            public DeviceEntity[] device { get; set; }
            public Dictionary<string, string> alias { get; set; }
            public Dictionary<string, int> access { get; set; }
        }

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
            }

            public void RefreshFetchDevice(string _reply)
            {
                FetchDeviceReply reply = JsonSerializer.Deserialize<FetchDeviceReply>(_reply);
                foreach (var e in reply.device)
                {
                    DeviceEntity entity = e;
                    int access;
                    reply.access.TryGetValue(e.uuid, out access);
                    entity.access = access;
                    string alias;
                    reply.alias.TryGetValue(e.uuid, out alias);
                    entity.alias = alias;
                    if (string.IsNullOrEmpty(entity.alias))
                        entity.alias = entity.name;
                    control.DeviceList.Add(entity);

                    entity._waitVisibility = entity.access == 0 ? Visibility.Visible : Visibility.Collapsed;
                    entity._acceptVisibility = entity.access == 1 ? Visibility.Visible : Visibility.Collapsed;
                    entity._rejectVisibility = entity.access == 2 ? Visibility.Visible : Visibility.Collapsed;
                }

            }

            public void UpdatePermission(Dictionary<string, string> _permission)
            {
            }
        }

        public class DeviceEntity
        {
            public string uuid { get; set; }
            public string serialNumber { get; set; }
            public string name { get; set; }
            public string operationSystem { get; set; }
            public string systemVersion { get; set; }
            public string shape { get; set; }
            public int battery { get; set; }
            public int volume { get; set; }
            public int brightness { get; set; }
            public string storage { get; set; }
            public long storageBlocks { get; set; }
            public long storageAvailable { get; set; }
            public string network { get; set; }
            public int networkStrength { get; set; }
            public Dictionary<string, string> program { get; set; }
            public int access { get; set; }
            public string alias { get; set; }

            public Visibility _acceptVisibility { get; set; }
            public Visibility _rejectVisibility { get; set; }
            public Visibility _waitVisibility { get; set; }
        }

        public class DomainEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
        }


        public SyncFacade facade { get; set; }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        public SyncControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            InitializeComponent();
            formEditDevice.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void onRefreshCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as ISyncViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            //bridge.OnListSubmit(json);
        }

        private void onDomainSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            ComboBoxItem item = cbDomainList.SelectedItem as ComboBoxItem;
            if (null == item)
                return;
            param["uuid"] = item.Uid;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnFetchDeviceSubmit(json);
        }

        private void onEditDeviceClicked(object sender, RoutedEventArgs e)
        {
            var item = dgDeviceList.SelectedItem;
            if (null == item)
                return;
            formEditDevice.Visibility = Visibility.Visible;
        }

        private void onDeviceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dgDeviceList.SelectedItem as DeviceEntity;
            if (null == item)
                return;

            tbEditAlias.Text = item.alias;
            //0:Î´´¦Àí 1: ÔÊÐí£¬2£º¾Ü¾ø
            cbEditAccess.SelectedIndex = item.access;
        }

        private void onEditSubmitClicked(object sender, RoutedEventArgs e)
        {
            var itemDomain = cbDomainList.SelectedItem as ComboBoxItem;
            if (null == itemDomain)
                return;
            var itemDevice = dgDeviceList.SelectedItem as DeviceEntity;
            if (null == itemDevice)
                return;

            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = itemDomain.Uid;
            param["device"] = itemDevice.uuid;
            param["alias"] = tbEditAlias.Text;
            param["access"] = cbEditAccess.SelectedIndex;
            string json = JsonSerializer.Serialize(param);
            bridge.OnEditDeviceSubmit(json);
        }

        private void onEditCancelClicked(object sender, RoutedEventArgs e)
        {
            formEditDevice.Visibility = Visibility.Collapsed;
        }

        private void getGeometry(string _name)
        {
        }
    }
}
