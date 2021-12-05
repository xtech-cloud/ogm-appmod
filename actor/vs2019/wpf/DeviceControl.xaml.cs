
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using HandyControl.Controls;

namespace ogm.actor
{
    public partial class DeviceControl : UserControl
    {
        public class DeviceUiBridge : BaseDeviceUiBridge, IDeviceExtendUiBridge
        {
            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<DeviceListReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.DeviceList.Clear();
                foreach (var e in reply.device)
                {
                    control.DeviceList.Add(e);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }
        }

        public DeviceFacade facade { get; set; }
        public ObservableCollection<DeviceEntity> DeviceList { get; set; }

        public DeviceControl()
        {
            DeviceList = new ObservableCollection<DeviceEntity>();
            InitializeComponent();
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbName.Text = "";
            tbSN.Text = "";
            listDevice();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text) || !string.IsNullOrEmpty(tbSN.Text))
            {
                searchDevice(tbName.Text, tbSN.Text);
            }
            else
            {
                listDevice();
            }
        }

        private void listDevice()
        {
            var bridge = facade.getViewBridge() as IDeviceViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void searchDevice(string _name, string _sn)
        {
            var bridge = facade.getViewBridge() as IDeviceViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["name"] = _name;
            param["serialNumber"] = _sn;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }
    }
}
