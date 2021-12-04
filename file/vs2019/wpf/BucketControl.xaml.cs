
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;

namespace ogm.file
{
    public partial class BucketControl : UserControl
    {
        public class BucketUiBridge : BaseBucketUiBridge, IBucketExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/file/Bucket/Make");
                control.PermissionEdit = _permission.ContainsKey("/ogm/file/Bucket/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/file/Bucket/Delete");
                // 未完成的功能
                control.PermissionDelete = false;
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);
                control.BucketList.Clear();
                var reply = JsonSerializer.Deserialize<BucketListReply>(_json);
                foreach (var e in reply.entity)
                {
                    e._totalSize = Utility.FormatSize(e.totalSize);
                    e._usedSize = Utility.FormatSize(e.usedSize);
                    e._engine = BucketEntity.engineToString(e.engine);
                    control.BucketList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public override void ReceiveMake(string _json)
            {
                base.ReceiveMake(_json);
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code == 0)
                {
                    control.formNewBucket.Visibility = Visibility.Collapsed;
                    control.listBucket();
                }
            }

            public override void ReceiveUpdate(string _json)
            {
                base.ReceiveMake(_json);
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code == 0)
                {
                    control.formEditBucket.Visibility = Visibility.Collapsed;
                    control.getBucket(reply.uuid);
                }
            }

            public override void ReceiveGet(string _json)
            {
                base.ReceiveGet(_json);
                var reply = JsonSerializer.Deserialize<BucketGetReply>(_json);
                if (reply.status.code != 0)
                    return;
                foreach(var e in control.BucketList)
                {
                    if(e.uuid.Equals(reply.entity.uuid))
                    {
                        e.CopyFromOther(reply.entity);
                        break;
                    }
                }
            }

            public override void ReceiveRemove(string _json)
            {
                base.ReceiveRemove(_json);
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code != 0)
                    return;
                control.listBucket();
            }

            public void HandleTabActivated()
            {
                if(string.IsNullOrEmpty(control.tbName.Text) && control.BucketList.Count == 0)
                {
                    control.listBucket();
                }
            }
        }

        public BucketFacade facade { get; set; }

        public ObjectControl controlObject { get; set; }
        public ObservableCollection<BucketEntity> BucketList { get; set; }

        public static readonly DependencyProperty PermissionCreateProperty = DependencyProperty.Register("PermissionCreate", typeof(bool), typeof(BucketControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(BucketControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(BucketControl), new PropertyMetadata(true));

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


        public BucketControl()
        {
            BucketList = new ObservableCollection<BucketEntity>();
            InitializeComponent();
            formEditBucket.Visibility = Visibility.Collapsed;
            formNewBucket.Visibility = Visibility.Collapsed;
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbName.Text = "";
            listBucket();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                listBucket();
            }
            else
            {
                searchBucket(tbName.Text);
            }
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditBucket.Visibility = Visibility.Collapsed;
            formNewBucket.Visibility = Visibility.Visible;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["name"] = tbNewName.Text;
            param["capacity"] = tbNewCapacity.Value * 1024 * 1024 * 1024;
            param["engine"] = cbNewEngine.SelectedIndex + 1;
            param["address"] = tbNewAddress.Text;
            param["scope"] = tbNewScope.Text;
            param["accessKey"] = tbNewKey.Text;
            param["accessSecret"] = tbNewSecret.Text;
            param["url"] = tbNewUrl.Text;

            var bridge = facade.getViewBridge() as IBucketViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnMakeSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewBucket.Visibility = Visibility.Collapsed;
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            param["name"] = tbEditName.Text;
            param["capacity"] = tbEditCapacity.Value * 1024 * 1024 * 1024;
            param["engine"] = cbEditEngine.SelectedIndex + 1;
            param["address"] = tbEditAddress.Text;
            param["scope"] = tbEditScope.Text;
            param["accessKey"] = tbEditKey.Text;
            param["accessSecret"] = tbEditSecret.Text;
            param["url"] = tbEditUrl.Text;

            var bridge = facade.getViewBridge() as IBucketViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnUpdateSubmit(json);
        }

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditBucket.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewBucket.Visibility = Visibility.Visible;
            formEditBucket.Visibility = Visibility.Collapsed;
        }

        private void onEditBucketClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;
            formEditBucket.Visibility = Visibility.Visible;
            formNewBucket.Visibility = Visibility.Collapsed;

            tbEditUUID.Text = item.uuid;
            tbEditName.Text = item.name;
            tbEditCapacity.Value = item.totalSize / 1024 / 1024 / 1024;
            cbEditEngine.SelectedIndex = item.engine - 1;
            tbEditAddress.Text = item.address;
            tbEditScope.Text = item.scope;
            tbEditKey.Text = item.accessKey;
            tbEditSecret.Text = item.accessSecret;
            tbEditUrl.Text = item.url;
        }

        private void OnBrowseObjectClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;

            controlObject.PageExtra["bucket.uuid"] = item.uuid;
            controlObject.PageExtra["bucket.name"] = item.name;
            controlObject.PageExtra["bucket.scope"] = item.scope;
            controlObject.RefreshWithExtra();
            var bridge = facade.getViewBridge() as IBucketExtendViewBridge;
            bridge.OnOpenObjectUi();
        }

        private void onDeleteBucketClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnRemoveSubmit(json);
        }

        private void onBucketSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formNewBucket.Visibility = Visibility.Collapsed;
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;

            tbEditName.Text = item.name;
        }

        private int engineFromStringToInt(string _engine)
        {
            if (_engine.Equals("ENGINE_LOCAL"))
                return 0;
            if (_engine.Equals("ENGINE_MINIO"))
                return 1;
            if (_engine.Equals("ENGINE_QINIU"))
                return 2;
            if (_engine.Equals("ENGINE_CUSTOM"))
                return 3;
            return -1;
        }

        private void listBucket()
        {
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void searchBucket(string _name)
        {
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["name"] = _name;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }

        private void getBucket(string _uuid)
        {
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = _uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnGetSubmit(json);
        }

    }
}
