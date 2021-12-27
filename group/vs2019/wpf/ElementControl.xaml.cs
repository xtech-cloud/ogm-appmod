using System.Text.Json;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using HandyControl.Controls;

namespace ogm.group
{
    public partial class ElementControl : UserControl
    {
        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public class ElementUiBridge : BaseElementUiBridge, IElementExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionAdd = _permission.ContainsKey("/ogm/group/Element/Add");
                control.PermissionEdit = _permission.ContainsKey("/ogm/group/Element/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/group/Element/Remove");
                //未完成功能
                control.PermissionEdit = false;
                control.PermissionDelete = false;
            }

            public override void ReceiveAdd(string _json)
            {
                base.ReceiveAdd(_json);
                Reply reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code == 0)
                {
                    control.formAddElement.Visibility = Visibility.Collapsed;
                    control.listElement(control.tbName.Uid);
                }
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                ElementListReply reply = JsonSerializer.Deserialize<ElementListReply>(_json);
                control.ElementList.Clear();
                foreach (var e in reply.entity)
                {
                    control.ElementList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }
        }

        public ElementFacade facade { get; set; }
        public ObservableCollection<ElementEntity> ElementList { get; set; }

        public static readonly DependencyProperty PermissionAddProperty = DependencyProperty.Register("PermissionAdd", typeof(bool), typeof(ElementControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(ElementControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(ElementControl), new PropertyMetadata(true));

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



        public ElementControl()
        {
            ElementList = new ObservableCollection<ElementEntity>();
            InitializeComponent();
            formAddElement.Visibility = Visibility.Collapsed;
        }

        public void RefreshWithExtra()
        {
            formAddElement.Visibility = Visibility.Collapsed;
            object o_uuid;
            if (!PageExtra.TryGetValue("collection.uuid", out o_uuid))
                return;
            object o_name;
            if (!PageExtra.TryGetValue("collection.name", out o_name))
                return;
            tbName.Uid = (string)o_uuid;
            tbName.Text = (string)o_name;
            tbName.IsEnabled = false;

            listElement(tbName.Uid);
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddElement.Visibility = Visibility.Collapsed;
            tbElement.Text = "";
            tbAlias.Text = "";
            listElement(tbName.Uid);
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddElement.Visibility = Visibility.Collapsed;
            if(string.IsNullOrEmpty(tbName.Uid))
            {
                //TODO required tip
                return;
            }

            if (string.IsNullOrEmpty(tbElement.Text) && string.IsNullOrEmpty(tbAlias.Text))
                listElement(tbName.Uid);
            else
                searchElement(tbName.Uid, tbElement.Text, tbAlias.Text);
        }

        private void onAddSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            List<string> labelAry = new List<string>();
            foreach(var label in tbAddLabel.Text.Split(","))
            {
                if (string.IsNullOrEmpty(label))
                    continue;
                labelAry.Add(label);
            }
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["collection"] = tbName.Uid;
            param["key"] = tbAddKey.Text;
            param["alias"] = tbAddAlias.Text;
            param["label"] = labelAry.ToArray();
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IElementViewBridge;
            bridge.OnAddSubmit(json);
        }

        private void onAddCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddElement.Visibility = Visibility.Collapsed;
        }

        private void onAddClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formAddElement.Visibility = Visibility.Visible;
        }

        private void onElementSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void onEditElementClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void onDeleteElementClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void listElement(string _collection)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["collection"] = _collection;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IElementViewBridge;
            bridge.OnListSubmit(json);
        }
        private void searchElement(string _collection, string _element, string _alias)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["collection"] = _collection;
            param["element"] = _element;
            param["alias"] = _alias;
            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IElementViewBridge;
            bridge.OnSearchSubmit(json);
        }

        private void onCopyUUID(object sender, RoutedEventArgs e)
        {
            var item = dgElementList.SelectedItem as ElementEntity;
            if (null == item)
                return;
            Clipboard.SetDataObject(item.uuid);
        }
    }
}
