
using System;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class RuleBaseModel : Model
    {

        public class RuleBaseStatus : Model.Status
        {
            public const string NAME = "ogm.permission.RuleStatus";
        }

        protected RuleController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(RuleController.NAME) as RuleController;
            Error err;
            status_ = spawnStatus<RuleModel.RuleStatus>(RuleModel.RuleStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.permission.RuleStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.permission.RuleModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(RuleModel.RuleStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected RuleModel.RuleStatus status
        {
            get
            {
                return status_ as RuleModel.RuleStatus;
            }
        }


        public virtual void SaveAdd(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Rule/Add", _rsp);
        }


        public virtual void SaveUpdate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Rule/Update", _rsp);
        }


        public virtual void SaveDelete(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Rule/Delete", _rsp);
        }


        public virtual void SaveGet(Proto.RuleGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Rule/Get", _rsp);
        }


        public virtual void SaveList(Proto.RuleListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Rule/List", _rsp);
        }


        public virtual void SaveSearch(Proto.RuleListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Rule/Search", _rsp);
        }



    }
}
