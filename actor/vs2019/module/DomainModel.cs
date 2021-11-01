using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainModel : DomainBaseModel
    {
        public class DomainStatus : DomainBaseStatus
        {
            public Proto.DomainEntity[] domainList;
        }
        public const string NAME = "ogm.actor.DomainModel";


        public void SaveCreate(Proto.BlankResponse _rsp) { }
        public void SaveDelete(Proto.BlankResponse _rsp) { }
        public void SaveExecute(Proto.BlankResponse _rsp) { }

        public void SaveList(Proto.DomainListResponse _rsp) 
        {
            if(_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.domainList = _rsp._domain;
            this.Bubble("/reply/domain/list", null);
        }


    }
}
