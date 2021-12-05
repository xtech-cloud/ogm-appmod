
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using HandyControl.Controls;

namespace ogm.actor
{
    public partial class GuardControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public class GuardUiBridge : BaseGuardUiBridge, IGuardExtendUiBridge
        {
            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionEdit = _permission.ContainsKey("/ogm/actor/Guard/Edit");
                control.PermissionDelete = _permission.ContainsKey("/ogm/actor/Guard/Delete");
            }

            public override void ReceiveFetch(string _json)
            {
                var reply = JsonSerializer.Deserialize<GuardFetchReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }

                control.DeviceList.Clear();
                foreach (var e in reply.device)
                {
                    DeviceEntity entity = e;
                    int access;
                    reply.access.TryGetValue(e.uuid, out access);
                    entity._access = access;
                    string alias;
                    reply.alias.TryGetValue(e.uuid, out alias);
                    entity._alias = alias;
                    if (string.IsNullOrEmpty(entity._alias))
                        entity._alias = entity.name;
                    control.DeviceList.Add(entity);
                }
            }

            public override void ReceiveEdit(string _json)
            {
                var reply = JsonSerializer.Deserialize<GuardFetchReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }

                control.formEditDevice.Visibility = Visibility.Collapsed;

                var itemDevice = control.dgDeviceList.SelectedItem as DeviceEntity;
                if (null == itemDevice)
                    return;
                itemDevice._alias = control.tbEditAlias.Text;
                itemDevice._access = control.cbEditAccess.SelectedIndex;
            }
        }

        public GuardFacade facade { get; set; }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(GuardControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(GuardControl), new PropertyMetadata(true));

        public bool PermissionEdit
        {
            get { return (bool)GetValue(PermissionEditProperty); }
            set { SetValue(PermissionEditProperty, value); }
        }

        public bool PermissionDelete
        {
            get { return (bool)GetValue(PermissionDeleteProperty); }
            set { SetValue(PermissionDeleteProperty, value); }
        }


        public GuardControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            InitializeComponent();
            formEditDevice.Visibility = Visibility.Collapsed;
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

            listDevice(tbDomain.Uid);
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            listDevice(tbDomain.Uid);
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            listDevice(tbDomain.Uid);
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var itemDevice = dgDeviceList.SelectedItem as DeviceEntity;
            if (null == itemDevice)
                return;

            var bridge = facade.getViewBridge() as IGuardViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = tbDomain.Uid;
            param["device"] = itemDevice.uuid;
            param["alias"] = tbEditAlias.Text;
            param["access"] = cbEditAccess.SelectedIndex;
            string json = JsonSerializer.Serialize(param);
            bridge.OnEditSubmit(json);
        }

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditDevice.Visibility = Visibility.Collapsed;
        }

        private void onDeviceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dgDeviceList.SelectedItem as DeviceEntity;
            if (null == item)
                return;

            tbEditAlias.Text = item._alias;
            //0:未处理 1: 允许，2：拒绝
            cbEditAccess.SelectedIndex = item._access;
        }

        private void onEditDeviceClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditDevice.Visibility = Visibility.Visible;
        }

        private void listDevice(string _domainUUID)
        {
            var bridge = facade.getViewBridge() as IGuardViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = _domainUUID;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnFetchSubmit(json);
        }
    }
}
