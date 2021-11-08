
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

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

        public class ApplicationEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
            public string version { get; set; }
            public string program { get; set; }
            public string location { get; set; }
            public string url { get; set; }
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
            }

            public void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<ReplyList>(_json);
                control.ApplicationList.Clear();
                foreach(var e in reply.application)
                {
                    control.ApplicationList.Add(e);
                }
            }
        }

        public ApplicationFacade facade { get; set; }

        //ҳ�����������ҳ�����תʱ��������
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public ObservableCollection<ApplicationEntity> ApplicationList { get; set; }

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

            /*
            var bridge = facade.getViewBridge() as IGuardViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["domain"] = tbDomain.Uid;
            param["device"] = itemApplication.uuid;
            param["alias"] = tbEditAlias.Text;
            param["access"] = cbEditAccess.SelectedIndex;
            string json = JsonSerializer.Serialize(param);
            bridge.OnEditSubmit(json);
            */
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

            tbEditName.Text = item.name;
            tbEditVersion.Text = item.version;
            tbEditProgram.Text = item.program;
            tbEditLocation.Text = item.location;
            tbEditUrl.Text = item.url;
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
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IApplicationViewBridge;
            bridge.OnAddSubmit(json);
        }

        private void onNewCancelClicked(object sender, RoutedEventArgs e)
        {
            formNewApplication.Visibility = Visibility.Collapsed;
        }
    }
}
