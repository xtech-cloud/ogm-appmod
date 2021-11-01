
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainModel : DomainBaseModel
    {
        public class DomainStatus : DomainBaseStatus
        {
        }
        public const string NAME = "ogm.actor.DomainModel";

        public void SaveCreate(Proto.BlankResponse _rsp) { }
        public void SaveDelete(Proto.BlankResponse _rsp) { }
        public void SaveList(Proto.DomainListResponse _rsp) { }
        public void SaveExecute(Proto.BlankResponse _rsp) { }


    }
}
