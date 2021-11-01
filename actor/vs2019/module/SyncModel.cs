
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncModel : SyncBaseModel
    {
        public class SyncStatus : SyncBaseStatus
        {
        }
        public const string NAME = "ogm.actor.SyncModel";

        public void SavePush(Proto.SyncPushResponse _rsp) { }
        public void SavePull(Proto.SyncPullResponse _rsp) { }


    }
}
