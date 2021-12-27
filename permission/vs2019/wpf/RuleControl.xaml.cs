using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ogm.permission
{
    public partial class RuleControl : UserControl
    {
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();
        public class RuleUiBridge : BaseRuleUiBridge, IRuleExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionAdd = _permission.ContainsKey("/ogm/permission/Rule/Add");
                control.PermissionEdit = _permission.ContainsKey("/ogm/permission/Rule/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/permission/Rule/Delete");
            }

            public override void ReceiveAdd(string _json)
            {
                base.ReceiveAdd(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code == 0)
                {
                    control.formAddRule.Visibility = Visibility.Collapsed;
                    control.listRule();
                }
            }

            public override void ReceiveUpdate(string _json)
            {
                base.ReceiveUpdate(_json);
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code == 0)
                {
                    control.formEditRule.Visibility = Visibility.Collapsed;
                    foreach (var e in control.RuleList)
                    {
                        if (e.uuid.Equals(reply.uuid))
                        {
                            e.name = control.tbEditName.Text;
                            e.key = control.tbEditKey.Text;
                            e.state = control.cbEditState.SelectedIndex + 1;
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
                    RuleEntity found = null;
                    foreach (var e in control.RuleList)
                    {
                        if (e.uuid.Equals(reply.uuid))
                        {
                            found = e;
                            break;
                        }
                    }
                    if (null != found)
                        control.RuleList.Remove(found);
                }
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                RuleListReply reply = JsonSerializer.Deserialize<RuleListReply>(_json);
                control.RuleList.Clear();
                foreach (var e in reply.entity)
                {
                    control.RuleList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public void HandleTabActivated()
            {
                if (string.IsNullOrEmpty(control.tbName.Text) && string.IsNullOrEmpty(control.tbKey.Text) && control.RuleList.Count == 0)
                    control.listRule();
            }
        }

        public RuleControl controlRule { get; set; }
        public RuleFacade facade { get; set; }
        public ObservableCollection<RuleEntity> RuleList { get; set; }

        public static readonly DependencyProperty PermissionAddProperty = DependencyProperty.Register("PermissionAdd", typeof(bool), typeof(RuleControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(RuleControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(RuleControl), new PropertyMetadata(true));

        public bool PermissionAdd
        {
            get { return (bool)GetValue(PermissionAddProperty); }
            set { SetValue(PermissionAddProperty, value); }
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

        public RuleControl()
        {
            RuleList = new ObservableCollection<RuleEntity>();
            InitializeComponent();
            formAddRule.Visibility = Visibility.Collapsed;
            formEditRule.Visibility = Visibility.Collapsed;
        }

        public void RefreshWithExtra()
        {
            RuleList.Clear();
            object o_uuid;
            if (!PageExtra.TryGetValue("scope.uuid", out o_uuid))
                return;
            object o_key;
            if (!PageExtra.TryGetValue("scope.key", out o_key))
                return;
            object o_name;
            if (!PageExtra.TryGetValue("scope.name", out o_name))
                return;

            tbScope.Uid = (string)o_uuid;
            tbScope.Text = (string)o_name;
            tbScope.IsEnabled = false;

            listRule();
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddRule.Visibility = Visibility.Collapsed;
            formEditRule.Visibility = Visibility.Collapsed;
            tbName.Text = "";
            tbKey.Text = "";
            listRule();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddRule.Visibility = Visibility.Collapsed;
            formEditRule.Visibility = Visibility.Collapsed;
            if (string.IsNullOrEmpty(tbName.Text) && string.IsNullOrEmpty(tbKey.Text))
                listRule();
            else
                searchRule();
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["scope"] = tbScope.Uid;
            param["key"] = tbNewKey.Text;
            param["name"] = tbNewName.Text;
            param["state"] = cbEditState.SelectedIndex + 1;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IRuleViewBridge;
            bridge.OnAddSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddRule.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddRule.Visibility = Visibility.Visible;
            formEditRule.Visibility = Visibility.Collapsed;
            tbName.Text = "";
            tbKey.Text = "";
            cbNewState.SelectedIndex = 0;
        }

        private void onEditSubmitClicked(object sender, RoutedEventArgs e)
        {
            var item = dgRuleList.SelectedItem as RuleEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            param["key"] = tbEditKey.Text;
            param["name"] = tbEditName.Text;
            param["state"] = cbEditState.SelectedIndex + 1;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IRuleViewBridge;
            bridge.OnUpdateSubmit(json);
        }

        private void onEditCancelClicked(object sender, RoutedEventArgs e)
        {
            formEditRule.Visibility = Visibility.Collapsed;
        }

        private void onRuleSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = dgRuleList.SelectedItem as RuleEntity;
            if (null == item)
                return;
            tbEditKey.Text = item.key;
            tbEditName.Text = item.name;
            cbEditState.SelectedIndex = item.state - 1;

        }

        private void onEditRuleClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgRuleList.SelectedItem as RuleEntity;
            if (null == item)
                return;
            formEditRule.Visibility = Visibility.Visible;
            formAddRule.Visibility = Visibility.Collapsed;
            tbEditKey.Text = item.key;
            tbEditName.Text = item.name;
            cbEditState.SelectedIndex = item.state - 1;
        }

        private void onDeleteRuleClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditRule.Visibility = Visibility.Collapsed;
            formAddRule.Visibility = Visibility.Collapsed;

            var item = dgRuleList.SelectedItem as RuleEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IRuleViewBridge;
            bridge.OnDeleteSubmit(json);
        }

        private void listRule()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["scope"] = tbScope.Uid;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IRuleViewBridge;
            bridge.OnListSubmit(json);
        }
        private void searchRule()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["scope"] = tbScope.Uid;
            param["key"] = tbKey.Text;
            param["name"] = tbName.Text;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IRuleViewBridge;
            bridge.OnSearchSubmit(json);
        }
    }
}
