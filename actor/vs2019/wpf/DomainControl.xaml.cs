
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using HandyControl.Controls;

namespace ogm.actor
{
    public partial class DomainControl : UserControl
    {
        public class DomainUiBridge : BaseDomainUiBridge, IDomainExtendUiBridge
        {
            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/actor/Domain/Create");
                control.PermissionEdit = _permission.ContainsKey("/ogm/actor/Domain/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/actor/Domain/Delete");
            }

            public override void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<DomainListReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.DomainList.Clear();
                foreach (var e in reply.domain)
                {
                    control.DomainList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public override void ReceiveCreate(string _json)
            {
                var reply = JsonSerializer.Deserialize<DomainListReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formNewDomain.Visibility = Visibility.Collapsed;
                control.listDomain();
            }

            public override void ReceiveUpdate(string _json)
            {
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formEditDomain.Visibility = Visibility.Collapsed;
                control.getDomain(reply.uuid);
            }
            public override void ReceiveGet(string _json)
            {
                var reply = JsonSerializer.Deserialize<DomainGetReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }

                foreach(var e in control.DomainList)
                {
                    if(e.uuid.Equals(reply.domain.uuid))
                    {
                        e.CopyFromOther(reply.domain);
                        break;
                    }
                }
            }

            public override void ReceiveDelete(string _json)
            {
                var reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formEditDomain.Visibility = Visibility.Collapsed;
                control.formNewDomain.Visibility = Visibility.Collapsed;
                control.listDomain();
            }

            public void HandleTabActivated()
            {
                control.listDomain();
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

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbName.Text = "";
            listDomain();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                listDomain();
            }
            else
            {
                searchDomain(tbName.Text);
            }
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["name"] = tbNewName.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnCreateSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
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

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewDomain.Visibility = Visibility.Visible;
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

        private void OnBrowseGuardClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            controlGuard.PageExtra["domain.uuid"] = item.uuid;
            controlGuard.PageExtra["domain.name"] = item.name;
            controlGuard.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IDomainExtendViewBridge;
            bridge.OnOpenGuardUi();
        }

        private void OnBrowseApplicationClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            controlApplication.PageExtra["domain.uuid"] = item.uuid;
            controlApplication.PageExtra["domain.name"] = item.name;
            controlApplication.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IDomainExtendViewBridge;
            bridge.OnOpenApplicationUi();
        }

        private void OnBrowseSyncClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            controlSync.PageExtra["domain.uuid"] = item.uuid;
            controlSync.PageExtra["domain.name"] = item.name;
            controlSync.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IDomainExtendViewBridge;
            bridge.OnOpenSyncUi();
        }

        private void onDeleteDomainClicked(object sender, RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;

            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            bridge.OnDeleteSubmit(json);
        }

        private void listDomain()
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void searchDomain(string _name)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["name"] = _name;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }

        private void getDomain(string _uuid)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = _uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnGetSubmit(json);
        }

    }
}
