
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

        public DeviceControl()
        {
            InitializeComponent();
        }
    }
}
