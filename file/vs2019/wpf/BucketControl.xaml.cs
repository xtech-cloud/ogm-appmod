
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ogm.file
{
    public partial class BucketControl : UserControl
    {
        public class BucketEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
            public string token { get; set; }
            public long totalSize { get; set; }
            public long usedSize { get; set; }
            public string engine { get; set; }
            public string address { get; set; }
            public string scope { get; set; }
            public string accessKey { get; set; }
            public string accessSecret { get; set; }
            public string url { get; set; }

            public string _totalSize { get; set; }
            public string _usedSize { get; set; }
        }

        public class BucketUiBridge : IBucketUiBridge
        {
            public BucketControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void RefreshList(string _reply)
            {
                control.BucketList.Clear();
                var list = JsonSerializer.Deserialize<BucketEntity[]>(_reply);
                foreach (var e in list)
                {
                    e._totalSize = formatSize(e.totalSize);
                    e._usedSize = formatSize(e.usedSize);
                    control.BucketList.Add(e);
                }
            }

            private string formatSize(long _size)
            {
                if (_size < 1024)
                    return string.Format("{0} B", _size);
                if (_size < 1024 * 1024)
                    return string.Format("{0} K", _size / 1024);
                if (_size < 1024 * 1024 * 1024)
                    return string.Format("{0} M", _size / 1024 / 1024);
                if (_size < (long)1024 * 1024 * 1024 * 1024)
                    return string.Format("{0} G", _size / 1024 / 1024 / 1024);
                if (_size < (long)1024 * 1024 * 1024 * 1024 * 1024)
                    return string.Format("{0} T", _size / 1024 / 1024 / 1024 / 1024);
                return "?";
            }
        }

        public BucketFacade facade { get; set; }
        public ObservableCollection<BucketEntity> BucketList { get; set; }

        public BucketControl()
        {
            BucketList = new ObservableCollection<BucketEntity>();
            InitializeComponent();
            formEditBucket.Visibility = Visibility.Collapsed;
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

        private void onBucketSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formNewBucket.Visibility = Visibility.Collapsed;
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;

            tbEditName.Text = item.name;
        }

        private void onEditBucketClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;
            formEditBucket.Visibility = Visibility.Visible;
            formNewBucket.Visibility = Visibility.Collapsed;

            tbEditName.Text = item.name;
            tbEditCapacity.Value = item.totalSize / 1024 / 1024 / 1024;
            cbEditEngine.SelectedIndex = engineFromStringToInt(item.engine);
            tbEditAddress.Text = item.address;
            tbEditScope.Text = item.scope;
            tbEditKey.Text = item.accessKey;
            tbEditSecret.Text = item.accessSecret;
            tbEditUrl.Text = item.url;
        }

        private void onCreateClicked(object sender, RoutedEventArgs e)
        {
            formNewBucket.Visibility = Visibility.Visible;
            formEditBucket.Visibility = Visibility.Collapsed;
        }

        private void onRefreshCliked(object sender, RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void onSearchClicked(object sender, RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void onNewSubmitClicked(object sender, RoutedEventArgs e)
        {
            formEditBucket.Visibility = Visibility.Collapsed;
            formNewBucket.Visibility = Visibility.Visible;
            //TODO

        }

        private void onNewCancelClicked(object sender, RoutedEventArgs e)
        {
            formNewBucket.Visibility = Visibility.Collapsed;
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

        private void onBucketDoubleClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = dgBucketList.SelectedItem as BucketEntity;
            if (null == item)
                return;

            ObjectControl.PageExtra["bucket.uuid"] = item.uuid;
            ObjectControl.PageExtra["bucket.scope"] = item.scope;
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            bridge.OnEnterBucket(item.uuid);
        }
    }
}
