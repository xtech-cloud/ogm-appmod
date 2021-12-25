using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ogm.permission
{
    public partial class ScopeControl : UserControl
    {
        public class ScopeUiBridge : BaseScopeUiBridge, IScopeExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/group/Scope/Create");
                control.PermissionEdit = _permission.ContainsKey("/ogm/group/Scope/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/group/Scope/Delete");
            }

            public override void ReceiveCreate(string _json)
            {
                base.ReceiveCreate(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code == 0)
                {
                    control.formNewScope.Visibility = Visibility.Collapsed;
                    control.listScope();
                }
            }

            public override void ReceiveUpdate(string _json)
            {
                base.ReceiveUpdate(_json);
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code == 0)
                {
                    control.formEditScope.Visibility = Visibility.Collapsed;
                    foreach (var e in control.ScopeList)
                    {
                        if (e.uuid.Equals(reply.uuid))
                        {
                            e.name = control.tbEditName.Text;
                            e.key = control.tbEditKey.Text;
                            e.Refresh();
                            break;
                        }
                    }
                }
            }

            public override void ReceiveDelete(string _json)
            {
                base.ReceiveDelete(_json);
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code == 0)
                {
                    ScopeEntity found = null;
                    foreach (var e in control.ScopeList)
                    {
                        if (e.uuid.Equals(reply.uuid))
                        {
                            found = e;
                            break;
                        }
                    }
                    if (null != found)
                        control.ScopeList.Remove(found);
                }
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                ScopeListReply reply = JsonSerializer.Deserialize<ScopeListReply>(_json);
                control.ScopeList.Clear();
                foreach (var e in reply.entity)
                {
                    control.ScopeList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public void HandleTabActivated()
            {
                if (string.IsNullOrEmpty(control.tbName.Text) && string.IsNullOrEmpty(control.tbKey.Text) && control.ScopeList.Count == 0)
                    control.listScope();
            }
        }

        public RuleControl controlRule { get; set; }
        public ScopeFacade facade { get; set; }
        public ObservableCollection<ScopeEntity> ScopeList { get; set; }

        public static readonly DependencyProperty PermissionCreateProperty = DependencyProperty.Register("PermissionCreate", typeof(bool), typeof(ScopeControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(ScopeControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(ScopeControl), new PropertyMetadata(true));

        public bool PermissionCreate
        {
            get { return (bool)GetValue(PermissionCreateProperty); }
            set { SetValue(PermissionCreateProperty, value); }
        }
        public bool PermissionDelete
        {
            get { return (bool)GetValue(PermissionDeleteProperty); }
            set { SetValue(PermissionDeleteProperty, value); }
        }
        public bool PermissionEdit
        {
            get { return (bool)GetValue(PermissionEditProperty); }
            set { SetValue(PermissionEditProperty, value); }
        }

        public ScopeControl()
        {
            ScopeList = new ObservableCollection<ScopeEntity>();
            InitializeComponent();
            formNewScope.Visibility = Visibility.Collapsed;
            formEditScope.Visibility = Visibility.Collapsed;
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewScope.Visibility = Visibility.Collapsed;
            formEditScope.Visibility = Visibility.Collapsed;
            tbName.Text = "";
            tbKey.Text = "";
            listScope();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewScope.Visibility = Visibility.Collapsed;
            formEditScope.Visibility = Visibility.Collapsed;
            if (string.IsNullOrEmpty(tbName.Text) && string.IsNullOrEmpty(tbKey.Text))
                listScope();
            else
                searchScope();
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["key"] = tbNewKey.Text;
            param["name"] = tbNewName.Text;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IScopeViewBridge;
            bridge.OnCreateSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewScope.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewScope.Visibility = Visibility.Visible;
            formEditScope.Visibility = Visibility.Collapsed;
            tbNewKey.Text = "";
            tbNewName.Text = "";
        }

        private void onEditSubmitClicked(object sender, RoutedEventArgs e)
        {
            var item = dgScopeList.SelectedItem as ScopeEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            param["key"] = tbEditKey.Text;
            param["name"] = tbEditName.Text;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IScopeViewBridge;
            bridge.OnUpdateSubmit(json);
        }

        private void onEditCancelClicked(object sender, RoutedEventArgs e)
        {
            formEditScope.Visibility = Visibility.Collapsed;
        }

        private void OnBrowseRuleClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgScopeList.SelectedItem as ScopeEntity;
            if (null == item)
                return;

            controlRule.PageExtra["scope.uuid"] = item.uuid;
            controlRule.PageExtra["scope.key"] = item.key;
            controlRule.PageExtra["scope.name"] = item.name;
            controlRule.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IScopeExtendViewBridge;
            bridge.OnOpenRuleUi();
        }

        private void onScopeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dgScopeList.SelectedItem as ScopeEntity;
            if (null == item)
                return;
            tbEditKey.Text = item.key;
            tbEditName.Text = item.name;

        }

        private void onEditScopeClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgScopeList.SelectedItem as ScopeEntity;
            if (null == item)
                return;
            formEditScope.Visibility = Visibility.Visible;
            formNewScope.Visibility = Visibility.Collapsed;
            tbEditKey.Text = item.key;
            tbEditName.Text = item.name;
        }

        private void onDeleteScopeClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditScope.Visibility = Visibility.Collapsed;
            formNewScope.Visibility = Visibility.Collapsed;

            var item = dgScopeList.SelectedItem as ScopeEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IScopeViewBridge;
            bridge.OnDeleteSubmit(json);
        }

        private void listScope()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IScopeViewBridge;
            bridge.OnListSubmit(json);
        }
        private void searchScope()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["key"] = tbKey.Text;
            param["name"] = tbName.Text;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IScopeViewBridge;
            bridge.OnSearchSubmit(json);
        }
    }
}
