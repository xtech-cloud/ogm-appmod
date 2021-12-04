using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ogm.group
{
    public partial class CollectionControl : UserControl
    {
        public class CollectionUiBridge : BaseCollectionUiBridge, ICollectionExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/group/Collection/Make");
                control.PermissionEdit = _permission.ContainsKey("/ogm/group/Collection/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/group/Collection/Remove");
                // 未完成功能
                control.PermissionEdit = false;
                control.PermissionDelete = false;
            }

            public override void ReceiveMake(string _json)
            {
                base.ReceiveMake(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                if(reply.status.code == 0)
                {
                    control.formNewCollection.Visibility = Visibility.Collapsed;
                    control.listCollection();
                }
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                CollectionListReply reply = JsonSerializer.Deserialize<CollectionListReply>(_json);
                control.CollectionList.Clear();
                foreach(var e in reply.entity)
                {
                    control.CollectionList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public void HandleTabActivated()
            {
                if(string.IsNullOrEmpty(control.tbName.Text) && control.CollectionList.Count == 0)
                    control.listCollection();
            }
        }

        public MemberControl controlMember { get; set; }
        public CollectionFacade facade { get; set; }
        public ObservableCollection<CollectionEntity> CollectionList { get; set; }

        public static readonly DependencyProperty PermissionCreateProperty = DependencyProperty.Register("PermissionCreate", typeof(bool), typeof(CollectionControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(CollectionControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(CollectionControl), new PropertyMetadata(true));

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

        public CollectionControl()
        {
            CollectionList = new ObservableCollection<CollectionEntity>();
            InitializeComponent();
            formNewCollection.Visibility = Visibility.Collapsed;
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewCollection.Visibility = Visibility.Collapsed;
            tbName.Text = "";
            listCollection();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewCollection.Visibility = Visibility.Collapsed;
            if(string.IsNullOrEmpty(tbName.Text))
                listCollection();
            else
                searchCollection(tbName.Text);
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["name"] = tbNewName.Text;
            param["capacity"] = nudNewCapacity.Value;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as ICollectionViewBridge;
            bridge.OnMakeSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewCollection.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewCollection.Visibility = Visibility.Visible;
        }

        private void OnBrowseMemberClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgCollectionList.SelectedItem as CollectionEntity;
            if (null == item)
                return;

            controlMember.PageExtra["collection.uuid"] = item.uuid;
            controlMember.PageExtra["collection.name"] = item.name;
            controlMember.RefreshWithExtra();
            var bridge = facade.getViewBridge() as ICollectionExtendViewBridge;
            bridge.OnOpenMemberUi();
        }

        private void onCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void onEditCollectionClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void onDeleteCollectionClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void listCollection()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as ICollectionViewBridge;
            bridge.OnListSubmit(json);
        }
        private void searchCollection(string _name)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["name"] = _name;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as ICollectionViewBridge;
            bridge.OnSearchSubmit(json);
        }
    }
}
