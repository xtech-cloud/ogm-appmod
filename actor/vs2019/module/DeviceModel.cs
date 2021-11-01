
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceModel : DeviceBaseModel
    {
        public class DeviceStatus : DeviceBaseStatus
        {
            public Proto.DeviceEntity[] deviceList;
        }
        public const string NAME = "ogm.actor.DeviceModel";

        private DeviceController controller_ { get; set; }

        protected override void setup()
        {
            base.setup();
            controller_ = findController(DeviceController.NAME) as DeviceController;
        }

        public void SaveList(Proto.DeviceListResponse _rsp) 
        {
            if(_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.deviceList = _rsp._device;
            this.Bubble("/reply/device/list", null);
        }


    }
}
