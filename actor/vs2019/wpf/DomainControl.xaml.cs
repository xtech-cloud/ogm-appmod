using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ogm.actor
{
    public partial class DomainControl : UserControl
    {

        public class ReplyStatus
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public class DomainEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
        }

        public class DomainUiBridge : IDomainUiBridge
        {
            public DomainControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void RefreshList(string _reply)
            {
                control.DomainList.Clear();
                var list = JsonSerializer.Deserialize<DomainEntity[]>(_reply);
                foreach (var e in list)
                {
                    control.DomainList.Add(e);
                }
            }

            public void RefreshFetchDevice(string _reply)
            {
            }

            public void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/actor/Domain/Create");
                control.PermissionEdit = _permission.ContainsKey("/ogm/actor/Domain/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/actor/Domain/Delete");
            }

            public void ReceiveCreate(string _json)
            {
                var status = JsonSerializer.Deserialize<ReplyStatus>(_json);
                if (status.code == 0)
                {
                    control.formNewDomain.Visibility = Visibility.Collapsed;
                }
            }

            public void ReceiveUpdate(string _json)
            {
                var status = JsonSerializer.Deserialize<ReplyStatus>(_json);
                if (status.code == 0)
                {
                    control.formEditDomain.Visibility = Visibility.Collapsed;
                }
            }
        }

        public DomainFacade facade { get; set; }
        public GuardControl controlGuard { get; set; }
        public SyncControl controlSync { get; set; }
        public ApplicationControl controlApplication { get; set; }
        public ObservableCollection<DomainEntity> DomainList { get; set; }

        public static readonly DependencyProperty PermissionCreateProperty = DependencyProperty.Register("PermissionCreate", typeof(bool), typeof(DomainControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(DomainControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(DomainControl), new PropertyMetadata(true));

        public bool PermissionCreate
        {
            get { return (bool)GetValue(PermissionCreateProperty); }
            set { SetValue(PermissionCreateProperty, value); }
        }

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

        public DomainControl()
        {
            DomainList = new ObservableCollection<DomainEntity>();
            InitializeComponent();
            formEditDomain.Visibility = Visibility.Collapsed;
            formNewDomain.Visibility = Visibility.Collapsed;
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            param["name"] = tbEditName.Text;

            var bridge = facade.getViewBridge() as IDomainViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnUpdateSubmit(json);
        }

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditDomain.Visibility = Visibility.Collapsed;
        }

        private void onDomainSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formNewDomain.Visibility = Visibility.Collapsed;
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            tbEditUUID.Text = item.uuid;
            tbEditName.Text = item.name;
        }

        private void onEditDomainClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;
            formEditDomain.Visibility = Visibility.Visible;
            formNewDomain.Visibility = Visibility.Collapsed;

            tbEditName.Text = item.name;
        }

        private void onCreateClicked(object sender, RoutedEventArgs e)
        {
            formNewDomain.Visibility = Visibility.Visible;
            formEditDomain.Visibility = Visibility.Collapsed;
        }

        private void onResetCliked(object sender, RoutedEventArgs e)
        {
            tbName.Text = "";
            DomainList.Clear();
        }

        private void onSearchClicked(object sender, RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            if (string.IsNullOrEmpty(tbName.Text))
            {
                string json = JsonSerializer.Serialize(param);
                bridge.OnListSubmit(json);
            }
            else
            {
                param["name"] = tbName.Text;
                string json = JsonSerializer.Serialize(param);
                bridge.OnSearchSubmit(json);
            }
        }

        private void onNewSubmitClicked(object sender, RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["name"] = tbNewName.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnCreateSubmit(json);
        }

        private void onNewCancelClicked(object sender, RoutedEventArgs e)
        {
            formNewDomain.Visibility = Visibility.Collapsed;
        }

        private void OnBrowseGuardClick(object sender, RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            controlGuard.PageExtra["domain.uuid"] = item.uuid;
            controlGuard.PageExtra["domain.name"] = item.name;
            controlGuard.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            bridge.OnOpenGuardUi();
        }

        private void OnBrowseSyncClick(object sender, RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            controlSync.PageExtra["domain.uuid"] = item.uuid;
            controlSync.PageExtra["domain.name"] = item.name;
            controlSync.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            bridge.OnOpenSyncUi();
        }

        private void OnBrowseApplicationClick(object sender, RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            controlApplication.PageExtra["domain.uuid"] = item.uuid;
            controlApplication.PageExtra["domain.name"] = item.name;
            controlApplication.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            bridge.OnOpenApplicationUi();
        }
    }
}
