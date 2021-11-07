
using System;
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardView : GuardBaseView
    {
        public const string NAME = "ogm.actor.GuardView";

        protected override void setup()
        {
            base.setup();

            addObserver(GuardModel.NAME, "/reply/device/fetch", this.receiveDeviceFetch);
            addObserver(GuardModel.NAME, "/reply/device/edit", this.receiveDeviceEdit);
        }

        private void receiveDeviceFetch(Model.Status _status, object _data)
        {
            GuardModel.GuardStatus status = _status as GuardModel.GuardStatus;
            if (null == status)
            {
                getLogger().Error("status [GuardModel.GuardStatus] is null");
                return;
            }

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["device"] = status.deviceList;
            param["access"] = status.accessList;
            param["alias"] = status.aliasList;
            var bridge = facade.getUiBridge() as IGuardUiBridge;
            var json = JsonSerializer.Serialize(param, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveFetch(json);
        }

        private void receiveDeviceEdit(Model.Status _status, object _data)
        {
            var json = JsonSerializer.Serialize(_data, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveEdit(json);
        }
    }
}
