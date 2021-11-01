
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ogm.actor
{
    public partial class DeviceControl: UserControl
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
        }

        public DeviceFacade facade { get; set; }

        public class DeviceEntity
        {
            public string Name { get; set; }
            public string OS { get; set; }
            public string Ver { get; set; }
            public string Shape { get; set; }
        }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        public DeviceControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            InitializeComponent();
            DeviceEntity entity = new DeviceEntity();
            entity.Name = "sdsd";
            DeviceList.Add(entity);
        }
    }
}
