using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Controls;
using HandyControl.Controls;
using System.Linq;

namespace ogm.actor
{
    public partial class SyncControl : UserControl
    {
        public class SyncUiBridge : ISyncUiBridge
        {
            public SyncControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void RefreshList(string _reply)
            {
                /*
                control.cbDomainList.Items.Clear();
                DomainEntity[] domainList = JsonSerializer.Deserialize<DomainEntity[]>(_reply);
                foreach (var entity in domainList)
                {
                    var item = new ComboBoxItem();
                    item.Content = entity.name;
                    item.Uid = entity.uuid;
                    control.cbDomainList.Items.Add(item);
                }
                if (control.cbDomainList.Items.Count > 0)
                    control.cbDomainList.SelectedIndex = 0;
                */
            }

            public void UpdatePermission(Dictionary<string, string> _permission)
            {
            }
        }

        public class DeviceEntity
        {
            public string uuid { get; set; }
            public string serialNumber { get; set; }
            public string name { get; set; }
            public string operationSystem { get; set; }
            public string systemVersion { get; set; }
            public string shape { get; set; }
            public int battery { get; set; }
            public int volume { get; set; }
            public int brightness { get; set; }
            public string storage { get; set; }
            public long storageBlocks { get; set; }
            public long storageAvailable { get; set; }
            public string network { get; set; }
            public int networkStrength { get; set; }
            public Dictionary<string, string> program { get; set; }
            public int access { get; set; }
            public string alias { get; set; }

            public Visibility _acceptVisibility { get; set; }
            public Visibility _rejectVisibility { get; set; }
            public Visibility _waitVisibility { get; set; }
        }

        public class DomainEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
        }


        public SyncFacade facade { get; set; }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        //页面参数，用于页面间跳转时传递数据
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public SyncControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            InitializeComponent();
        }

        public void RefreshWithExtra()
        {

        }
    }
}
