
using System;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class ScopeBaseModel : Model
    {

        public class ScopeBaseStatus : Model.Status
        {
            public const string NAME = "ogm.permission.ScopeStatus";
        }

        protected ScopeController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(ScopeController.NAME) as ScopeController;
            Error err;
            status_ = spawnStatus<ScopeModel.ScopeStatus>(ScopeModel.ScopeStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.permission.ScopeStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.permission.ScopeModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(ScopeModel.ScopeStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected ScopeModel.ScopeStatus status
        {
            get
            {
                return status_ as ScopeModel.ScopeStatus;
            }
        }


        public virtual void SaveCreate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Scope/Create", _rsp);
        }


        public virtual void SaveUpdate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Scope/Update", _rsp);
        }


        public virtual void SaveDelete(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Scope/Delete", _rsp);
        }


        public virtual void SaveGet(Proto.ScopeGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Scope/Get", _rsp);
        }


        public virtual void SaveList(Proto.ScopeListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Scope/List", _rsp);
        }


        public virtual void SaveSearch(Proto.ScopeListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/permission/Scope/Search", _rsp);
        }



    }
}
