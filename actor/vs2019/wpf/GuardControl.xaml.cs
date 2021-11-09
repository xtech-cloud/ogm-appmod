using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ogm.actor
{
    public partial class GuardControl : UserControl
    {
        public class ReplyStatus
        {
            public int code { get; set; }
            public string message { get; set; }
        }
        public class FetchDeviceReply
        {
            public long total { get; set; }
            public DeviceEntity[] device { get; set; }
            public Dictionary<string, string> alias { get; set; }
            public Dictionary<string, int> access { get; set; }
        }

        public class DeviceEntity : INotifyPropertyChanged
        {
            public string uuid { get; set; }
            public string serialNumber { get; set; }
            public string name { get; set; }
            public string operatingSystem { get; set; }
            public string systemVersion { get; set; }
            public string shape { get; set; }
            public int _access
            {
                get { return _access_; }
                set { 
                    _access_ = value;
                    _waitVisibility = _access == 0 ? Visibility.Visible : Visibility.Collapsed;
                    _acceptVisibility = _access == 1 ? Visibility.Visible : Visibility.Collapsed;
                    _rejectVisibility = _access == 2 ? Visibility.Visible : Visibility.Collapsed;
                    OnPrepertyChanged("_waitVisibility");
                    OnPrepertyChanged("_acceptVisibility");
                    OnPrepertyChanged("_rejectVisibility");
                }
            }

            public string _alias
            {
                get { return _alias_; }
                set { _alias_ = value; OnPrepertyChanged("_alias"); }
            }
            public Visibility _waitVisibility { get; set; }
            public Visibility _acceptVisibility { get; set; }
            public Visibility _rejectVisibility { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPrepertyChanged(string _propertyName)
            {
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
            }

            private string _alias_;
            private int _access_;
        }

        public class GuardUiBridge : IGuardUiBridge
        {
            public GuardControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionEdit = _permission.ContainsKey("/ogm/actor/Guard/Edit");
                control.PermissionDelete = _permission.ContainsKey("/ogm/actor/Guard/Delete");
            }

            public void ReceiveFetch(string _reply)
            {
                FetchDeviceReply reply = JsonSerializer.Deserialize<FetchDeviceReply>(_reply);
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

            public void ReceiveEdit(string _reply)
            {
                ReplyStatus status = JsonSerializer.Deserialize<ReplyStatus>(_reply);
                if (status.code == 0)
                {
                    control.formEditDevice.Visibility = Visibility.Collapsed;

                    var itemDevice = control.dgDeviceList.SelectedItem as DeviceEntity;
                    if (null == itemDevice)
                        return;
                    itemDevice._alias = control.tbEditAlias.Text;
                    itemDevice._access = control.cbEditAccess.SelectedIndex;
                }
            }
        }

        public GuardFacade facade { get; set; }

        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

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
            tbDomain.Text = "";
            tbDomain.Uid = "";
            DeviceList.Clear();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            DeviceList.Clear();
            if (string.IsNullOrEmpty(tbDomain.Uid))
            {
                return;
            }
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = tbDomain.Uid;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IGuardViewBridge;
            bridge.OnFetchSubmit(json);
        }

        private void onEditDeviceClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditDevice.Visibility = Visibility.Visible;
        }

        private void onEditSubmitClicked(object sender, RoutedEventArgs e)
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

        private void onEditCancelClicked(object sender, RoutedEventArgs e)
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
