
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardModel : GuardBaseModel
    {
        public class GuardStatus : GuardBaseStatus
        {
            public long total;
            public Proto.DeviceEntity[] deviceList;
            public Dictionary<string, int> accessList;
            public Dictionary<string, string> aliasList;
        }

        public const string NAME = "ogm.actor.GuardModel";

        public void SaveFetch(Proto.GuardFetchResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.total = _rsp._total.AsInt64();
            status.deviceList = _rsp._device;
            status.accessList = _rsp._access;
            status.aliasList = _rsp._alias;
            this.Bubble("/reply/device/fetch", null);
        }
        public void SaveEdit(Proto.BlankResponse _rsp)
        {
            this.Bubble("/reply/device/edit", _rsp._status);
        }
        public void SaveDelete(Proto.BlankResponse _rsp) { }


    }
}
