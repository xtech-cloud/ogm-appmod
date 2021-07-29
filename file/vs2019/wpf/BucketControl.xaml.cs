
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using XTC.oelMVCS;

namespace ogm.file
{
    public partial class BucketControl : UserControl
    {
        public class BucketUiBridge : IBucketUiBridge
        {
            public BucketControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
                HandyControl.Controls.Growl.Warning(_message, "StatusGrowl");
            }

            public void RefreshBucketList(long _total, List<Dictionary<string, Any>> _list)
            {
                control.BucketList.Clear();
                foreach (var entity in _list)
                {
                    BucketModel bucket = new BucketModel();
                    control.BucketList.Add(bucket);
                    bucket.UUID = entity["uuid"].AsString();
                    bucket.Name = entity["name"].AsString();
                    bucket.Capacity = entity["totalSize"].AsInt64();
                    //bucket.Capacity = entity["usedSize"].AsInt64();
                    bucket.Engine = entity["engine"].AsString();
                    bucket.Scope = entity["scope"].AsString();
                    bucket.Address = entity["address"].AsString();
                    bucket.AccessKey = entity["accessKey"].AsString();
                    bucket.AccessSecret = entity["accessSecret"].AsString();
                }
            }
        }

        public BucketFacade facade { get; set; }

        public class BucketModel
        {
            public string UUID { get; set; }
            public string Name { get; set; }
            public long Capacity { get; set; }
            public string Engine { get; set; }
            public string Scope { get; set; }
            public string AccessKey { get; set; }
            public string AccessSecret { get; set; }
            public string Address { get; set; }
        }

        public int PageIndex { get; set; }
        public ObservableCollection<BucketModel> BucketList { get; set; }

        public BucketControl()
        {
            PageIndex = 1;
            BucketList = new ObservableCollection<BucketModel>();
            InitializeComponent();
        }

        private void onCreateBucketClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DrawerCreateBucket.IsOpen = true;
            clearCreateBucketForm();
        }

        private void onCloseCreateBucketClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.DrawerCreateBucket.IsOpen = false;
        }

        private void onCreateBucketSubmitClick(object sender, System.Windows.RoutedEventArgs e)
        {
            string name = tbBucketName.Text;
            ulong capacity = (ulong)nudBucketCapacity.Value * 1024 * 1024 * 1024;
            int engine = cbBucketEngine.SelectedIndex;
            string address = tbEngineAddress.Text;
            string scope = tbEngineScope.Text;
            string accessKey = tbEngineAccessKey.Text;
            string accessSecret = tbEngineAccessSecret.Text;

            var bridge = facade.getViewBridge() as IBucketViewBridge;
            bridge.OnMakeSubmit(name, capacity, engine, address, scope, accessKey, accessSecret);
        }
        private void onResetListClick(object sender, System.Windows.RoutedEventArgs e)
        {
            sbBucketFilter.Text = "";
            var bridge = facade.getViewBridge() as IBucketViewBridge;
            bridge.OnListSubmit(0, 200);
        }

        private void clearCreateBucketForm()
        {

        }

    }
}
