
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationModel : ApplicationBaseModel
    {
        public class ApplicationStatus : ApplicationBaseStatus
        {
            public Proto.ApplicationEntity[] applicationList { get; set; }
            public long applicationTotal { get; set; }
        }

        public const string NAME = "ogm.actor.ApplicationModel";

        public void SaveAdd(Proto.BlankResponse _rsp)
        {
            this.Bubble("/reply/application/add", _rsp._status);
        }
        public void SaveRemove(Proto.BlankResponse _rsp)
        {
            this.Bubble("/reply/application/remove", _rsp._status);
        }
        public void SaveList(Proto.ApplicationListResponse _rsp)
        {
            status.applicationList = _rsp._application;
            status.applicationTotal = _rsp._total.AsInt64();
            this.Bubble("/reply/application/list", _rsp._status);
        }

        public void SaveUpdate(Proto.BlankResponse _rsp)
        {
            this.Bubble("/reply/application/update", _rsp._status);
        }



    }
}
