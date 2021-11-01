
using System;
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceView : DeviceBaseView
    {
        public const string NAME = "ogm.actor.DeviceView";

        protected override void setup()
        {
            base.setup();

            addRouter("/sidemenu/tab/activated", this.handleTabActivated);
            addObserver(DeviceModel.NAME, "/reply/device/list", this.receiveDeviceList);
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string tab = (string)_data;
            if (!tab.Equals("ogm.actor.Device"))
                return;

            var bridge = facade.getViewBridge() as DeviceViewBridge;
            var req = new Proto.ListRequest();
            req._offset = Any.FromInt32(0);
            req._count = Any.FromInt32(int.MaxValue);
            bridge.service.PostList(req);
        }

        private void receiveDeviceList(Model.Status _status, object _data)
        {
            DeviceModel.DeviceStatus status = _status as DeviceModel.DeviceStatus;
            if(null == status)
            {
                getLogger().Error("status [DeviceModel.DeviceStatus] is null");
                return;
            }    
            var bridge = facade.getUiBridge() as IDeviceUiBridge;
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var json = JsonSerializer.Serialize(status.deviceList, options);
            bridge.RefreshList(json);

        }
    }
}
