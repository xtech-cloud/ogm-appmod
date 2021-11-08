
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncModel : SyncBaseModel
    {
        public class SyncStatus : SyncBaseStatus
        {
            public Proto.DeviceEntity[] device;
            public Dictionary<string, string> property;
            public Dictionary<string, string> alias;
        }
        public const string NAME = "ogm.actor.SyncModel";

        public void SavePush(Proto.SyncPushResponse _rsp) { }
        public void SavePull(Proto.SyncPullResponse _rsp)
        {
            status.device = _rsp._device;
            status.property = _rsp._property;
            status.alias = _rsp._alias;
            this.Bubble("/reply/sync/pull", _rsp._status);
        }


    }
}
