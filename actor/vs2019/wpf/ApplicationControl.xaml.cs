
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using HandyControl.Controls;

namespace ogm.actor
{
    public partial class ApplicationControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public class ApplicationUiBridge : BaseApplicationUiBridge, IApplicationExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionAdd = _permission.ContainsKey("/ogm/actor/Application/Add");
                control.PermissionRemove = _permission.ContainsKey("/ogm/actor/Application/Remove");
                control.PermissionUpdate = _permission.ContainsKey("/ogm/actor/Application/Update");
            }

            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void ReceiveAdd(string _json)
            {
                var reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formNewApplication.Visibility = Visibility.Collapsed;
                control.listApplication(control.tbDomain.Uid);
            }

            public override void ReceiveRemove(string _json)
            {
                var reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formEditApplication.Visibility = Visibility.Collapsed;
                control.listApplication(control.tbDomain.Uid);
            }

            public override void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<ApplicationListReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.ApplicationList.Clear();
                foreach (var e in reply.application)
                {
                    control.ApplicationList.Add(e);
                }
            }

            public override void ReceiveUpdate(string _json)
            {
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formEditApplication.Visibility = Visibility.Collapsed;
                control.getApplication(reply.uuid);
            }

            public override void ReceiveGet(string _json)
            {
                var reply = JsonSerializer.Deserialize<ApplicationGetReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                foreach(var e in control.ApplicationList)
                {
                    if(e.uuid.Equals(reply.application.uuid))
                    {
                        e.CopyFromOther(reply.application);
                        break;
                    }
                }
            }
        }

        public ApplicationFacade facade { get; set; }


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

            listApplication(tbDomain.Uid);
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

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
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

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewApplication.Visibility = Visibility.Collapsed;
            tbNewName.Text = "";
            tbNewVersion.Text = "";
            tbNewProgram.Text = "";
            tbNewLocation.Text = "";
            tbNewUrl.Text = "";
            cbNewUpgrade.SelectedIndex = 0;
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
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

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Collapsed;
            formNewApplication.Visibility = Visibility.Collapsed;
        }

        private void onAddClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Collapsed;
            formNewApplication.Visibility = Visibility.Visible;
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

        private void onEditApplicationClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditApplication.Visibility = Visibility.Visible;
            formNewApplication.Visibility = Visibility.Collapsed;
        }

        private void onDeleteApplicationClicked(object sender, System.Windows.RoutedEventArgs e)
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

        private void listApplication(string _domainUUID)
        {
            if (string.IsNullOrEmpty(_domainUUID))
                return;
            var bridge = facade.getViewBridge() as IApplicationViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = _domainUUID;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void getApplication(string _uuid)
        {
            if (string.IsNullOrEmpty(_uuid))
                return;
            var bridge = facade.getViewBridge() as IApplicationViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = _uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnGetSubmit(json);
        }
    }
}
