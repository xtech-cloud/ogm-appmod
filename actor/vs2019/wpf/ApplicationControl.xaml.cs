
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.ComponentModel;

namespace ogm.actor
{
    public partial class ApplicationControl : UserControl
    {

        public class ReplyStatus
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public class ReplyList
        {
            public long total { get; set; }
            public ApplicationEntity[] application { get; set; }
        }

        public class ApplicationEntity : INotifyPropertyChanged
        {
            public string uuid { get; set; }
            public string name { get; set; }
            public string version { get; set; }
            public string program { get; set; }
            public string location { get; set; }
            public string url { get; set; }

            public int upgrade
            {
                get { return upgrade_; }
                set
                {
                    upgrade_ = value;
                    _noUpgradeVisibility = upgrade_ == 1 ? Visibility.Visible : Visibility.Collapsed;
                    _autoUpgradeVisibility = upgrade_ == 2 ? Visibility.Visible : Visibility.Collapsed;
                    _manualUpgradeVisibility = upgrade_ == 3 ? Visibility.Visible : Visibility.Collapsed;
                    OnPrepertyChanged("_noUpgradeVisibility");
                    OnPrepertyChanged("_autoUpgradeVisibility");
                    OnPrepertyChanged("_manualUpgradeVisibility");
                }
            }
            private int upgrade_ { get; set; }

            public Visibility _noUpgradeVisibility { get; set; }
            public Visibility _autoUpgradeVisibility { get; set; }
            public Visibility _manualUpgradeVisibility { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPrepertyChanged(string _propertyName)
            {
                if (this.PropertyChanged == null)
                    return;
                this.PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
            }

        }
        public class ApplicationUiBridge : IApplicationUiBridge
        {
            public ApplicationControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionAdd = _permission.ContainsKey("/ogm/actor/Application/Add");
                control.PermissionRemove = _permission.ContainsKey("/ogm/actor/Application/Remove");
                control.PermissionUpdate = _permission.ContainsKey("/ogm/actor/Application/Update");
            }

            public void ReceiveAdd(string _json)
            {
                var replyStatus = JsonSerializer.Deserialize<ReplyStatus>(_json);
                if (replyStatus.code != 0)
                {
                    Alert(replyStatus.message);
                    return;
                }
                control.formNewApplication.Visibility = Visibility.Collapsed;
                control.listApplication(control.tbDomain.Uid);
            }

            public void ReceiveRemove(string _json)
            {
                var replyStatus = JsonSerializer.Deserialize<ReplyStatus>(_json);
                if (replyStatus.code != 0)
                {
                    Alert(replyStatus.message);
                    return;
                }
                control.formEditApplication.Visibility = Visibility.Collapsed;
                control.listApplication(control.tbDomain.Uid);
            }


            public void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<ReplyList>(_json);
                control.ApplicationList.Clear();
                foreach (var e in reply.application)
                {
                    control.ApplicationList.Add(e);
                }
            }

            public void ReceiveUpdate(string _reply)
            {
                ReplyStatus status = JsonSerializer.Deserialize<ReplyStatus>(_reply);
                if (status.code == 0)
                {
                    control.formEditApplication.Visibility = Visibility.Collapsed;

                    var item = control.dgApplicationList.SelectedItem as ApplicationEntity;
                    if (null == item)
                        return;
                    item.upgrade = control.cbEditUpgrade.SelectedIndex + 1;
                }
            }

        }

        public ApplicationFacade facade { get; set; }

        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public ObservableCollection<ApplicationEntity> ApplicationList { get; set; }


        public static readonly DependencyProperty PermissionAddProperty = DependencyProperty.Register("PermissionAdd", typeof(bool), typeof(ApplicationControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionRemoveProperty = DependencyProperty.Register("PermissionRemove", typeof(bool), typeof(ApplicationControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionUpdateProperty = DependencyProperty.Register("PermissionUpdate", typeof(bool), typeof(ApplicationControl), new PropertyMetadata(true));

        public bool PermissionAdd
        {
            get { return (bool)GetValue(PermissionAddProperty); }
            set { SetValue(PermissionAddProperty, value); }
        }

        public bool PermissionRemove
        {
            get { return (bool)GetValue(PermissionRemoveProperty); }
            set { SetValue(PermissionRemoveProperty, value); }
        }

        public bool PermissionUpdate
        {
            get { return (bool)GetValue(PermissionUpdateProperty); }
            set { SetValue(PermissionUpdateProperty, value); }
        }

        public ApplicationControl()
        {
            ApplicationList = new ObservableCollection<ApplicationEntity>();
            InitializeComponent();
            formEditApplication.Visibility = Visibility.Collapsed;
            formNewApplication.Visibility = Visibility.Collapsed;
        }

        public void RefreshWithExtra()
        {
            ApplicationList.Clear();
            object o_uuid;
            if (!PageExtra.TryGetValue("domain.uuid", out o_uuid))
                return;
            object o_name;
            if (!PageExtra.TryGetValue("domain.name", out o_name))
                return;
            tbDomain.Uid = (string)o_uuid;
            tbDomain.Text = (string)o_name;
            tbDomain.IsEnabled = false;

            listApplication(tbDomain.Uid);
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Collapsed;
            formNewApplication.Visibility = Visibility.Collapsed;

            tbDomain.Text = "";
            tbDomain.Uid = "";
            ApplicationList.Clear();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Collapsed;
            formNewApplication.Visibility = Visibility.Collapsed;

            ApplicationList.Clear();
            if (string.IsNullOrEmpty(tbDomain.Uid))
            {
                return;
            }

            listApplication(tbDomain.Uid);
        }

        private void onEditApplicationClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Visible;
            formNewApplication.Visibility = Visibility.Collapsed;
        }

        private void onEditSubmitClicked(object sender, RoutedEventArgs e)
        {
            var itemApplication = dgApplicationList.SelectedItem as ApplicationEntity;
            if (null == itemApplication)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = formEditApplication.Uid;
            param["name"] = tbEditName.Text;
            param["version"] = tbEditVersion.Text;
            param["program"] = tbEditProgram.Text;
            param["location"] = tbEditLocation.Text;
            param["url"] = tbEditUrl.Text;
            param["upgrade"] = cbEditUpgrade.SelectedIndex + 1;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IApplicationViewBridge;
            bridge.OnUpdateSubmit(json);
        }

        private void onEditCancelClicked(object sender, RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Collapsed;
            formNewApplication.Visibility = Visibility.Collapsed;
        }

        private void onApplicationSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dgApplicationList.SelectedItem as ApplicationEntity;
            if (null == item)
                return;

            formEditApplication.Uid = item.uuid;
            tbEditName.Text = item.name;
            tbEditVersion.Text = item.version;
            tbEditProgram.Text = item.program;
            tbEditLocation.Text = item.location;
            tbEditUrl.Text = item.url;
            cbEditUpgrade.SelectedIndex = item.upgrade - 1;
        }


        private void listApplication(string _domainUUID)
        {
            var bridge = facade.getViewBridge() as IApplicationViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = _domainUUID;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void onAddClicked(object sender, RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Collapsed;
            formNewApplication.Visibility = Visibility.Visible;
        }

        private void onNewSubmitClicked(object sender, RoutedEventArgs e)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = tbDomain.Uid;
            param["name"] = tbNewName.Text;
            param["version"] = tbNewVersion.Text;
            param["program"] = tbNewProgram.Text;
            param["location"] = tbNewLocation.Text;
            param["url"] = tbNewUrl.Text;
            param["upgrade"] = cbNewUpgrade.SelectedIndex + 1;

            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IApplicationViewBridge;
            bridge.OnAddSubmit(json);
        }

        private void onNewCancelClicked(object sender, RoutedEventArgs e)
        {
            formNewApplication.Visibility = Visibility.Collapsed;
            tbNewName.Text = "";
            tbNewVersion.Text = "";
            tbNewProgram.Text = "";
            tbNewLocation.Text = "";
            tbNewUrl.Text = "";
            cbNewUpgrade.SelectedIndex = 0;
        }

        private void onDeleteApplicationClicked(object sender, RoutedEventArgs e)
        {
            var item = dgApplicationList.SelectedItem as ApplicationEntity;
            if (null == item)
                return;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;

            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IApplicationViewBridge;
            bridge.OnRemoveSubmit(json);
        }
    }
}
