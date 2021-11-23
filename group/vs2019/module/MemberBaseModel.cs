
using System;
using XTC.oelMVCS;

namespace ogm.group
{
    public class MemberBaseModel : Model
    {

        public class MemberBaseStatus : Model.Status
        {
            public const string NAME = "ogm.group.MemberStatus";
        }

        protected MemberController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(MemberController.NAME) as MemberController;
            Error err;
            status_ = spawnStatus<MemberModel.MemberStatus>(MemberModel.MemberStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.group.MemberStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.MemberModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(MemberModel.MemberStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected MemberModel.MemberStatus status
        {
            get
            {
                return status_ as MemberModel.MemberStatus;
            }
        }


        public virtual void SaveAdd(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Member/Add", _rsp);
        }


        public virtual void SaveList(Proto.MemberListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Member/List", _rsp);
        }


        public virtual void SaveRemove(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Member/Remove", _rsp);
        }


        public virtual void SaveGet(Proto.MemberGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Member/Get", _rsp);
        }


        public virtual void SaveWhere(Proto.MemberWhereResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Member/Where", _rsp);
        }



    }
}
