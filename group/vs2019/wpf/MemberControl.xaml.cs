using System.Text.Json;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ogm.group
{
    public partial class MemberControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public class MemberUiBridge : BaseMemberUiBridge, IMemberExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionAdd = _permission.ContainsKey("/ogm/group/Member/Add");
                control.PermissionEdit = _permission.ContainsKey("/ogm/group/Member/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/group/Member/Remove");
            }

            public override void ReceiveAdd(string _json)
            {
                base.ReceiveAdd(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code == 0)
                {
                    control.formAddMember.Visibility = Visibility.Collapsed;
                    control.listMember(control.tbName.Uid);
                }
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                MemberListReply reply = JsonSerializer.Deserialize<MemberListReply>(_json);
                control.MemberList.Clear();
                foreach (var e in reply.entity)
                {
                    control.MemberList.Add(e);
                }
            }
        }

        public MemberFacade facade { get; set; }
        public ObservableCollection<MemberEntity> MemberList { get; set; }

        public static readonly DependencyProperty PermissionAddProperty = DependencyProperty.Register("PermissionAdd", typeof(bool), typeof(MemberControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(MemberControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(MemberControl), new PropertyMetadata(true));

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



        public MemberControl()
        {
            MemberList = new ObservableCollection<MemberEntity>();
            InitializeComponent();
            formAddMember.Visibility = Visibility.Collapsed;
        }

        public void RefreshWithExtra()
        {
            formAddMember.Visibility = Visibility.Collapsed;
            object o_uuid;
            if (!PageExtra.TryGetValue("collection.uuid", out o_uuid))
                return;
            object o_name;
            if (!PageExtra.TryGetValue("collection.name", out o_name))
                return;
            tbName.Uid = (string)o_uuid;
            tbName.Text = (string)o_name;
            tbName.IsEnabled = false;

            listMember(tbName.Uid);
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddMember.Visibility = Visibility.Collapsed;
            tbName.IsEnabled = true;
            tbName.Uid = "";
            tbName.Text = "";
            MemberList.Clear();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddMember.Visibility = Visibility.Collapsed;
            listMember(tbName.Uid);
        }

        private void onAddSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["collection"] = tbName.Uid;
            param["element"] = tbAddElement.Text;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IMemberViewBridge;
            bridge.OnAddSubmit(json);
        }

        private void onAddCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddMember.Visibility = Visibility.Collapsed;
        }

        private void onAddClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddMember.Visibility = Visibility.Visible;
        }

        private void onMemberSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void onEditMemberClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void onDeleteMemberClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void listMember(string _collection)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["collection"] = _collection;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IMemberViewBridge;
            bridge.OnListSubmit(json);
        }
    }
}
