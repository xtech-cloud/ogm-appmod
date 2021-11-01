
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Controls;

namespace ogm.actor
{
    public partial class DeviceControl : UserControl
    {
        public class DeviceUiBridge : IDeviceUiBridge
        {
            public DeviceControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void RefreshList(string _reply)
            {
                control.DeviceList.Clear();
                DeviceEntity[] deviceList = JsonSerializer.Deserialize<DeviceEntity[]>(_reply);
                foreach (var entity in deviceList)
                {
                    control.DeviceList.Add(entity);
                }
            }
        }

        public DeviceFacade facade { get; set; }

        public class DeviceEntity
        {
            public string serialNumber{ get; set; }
            public string name { get; set; }
            public string operatingSystem{ get; set; }
            public string systemVersion{ get; set; }
            public string shape{ get; set; }
        }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        public DeviceControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            InitializeComponent();
        }
    }
}
