
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainBaseModel : Model
    {

        public class DomainBaseStatus : Model.Status
        {
            public const string NAME = "ogm.actor.DomainStatus";
        }

        protected DomainController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(DomainController.NAME) as DomainController;
            Error err;
            status_ = spawnStatus<DomainModel.DomainStatus>(DomainModel.DomainStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.actor.DomainStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.DomainModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(DomainModel.DomainStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected DomainModel.DomainStatus status
        {
            get
            {
                return status_ as DomainModel.DomainStatus;
            }
        }


        public virtual void SaveCreate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/Create", _rsp);
        }


        public virtual void SaveUpdate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/Update", _rsp);
        }


        public virtual void SaveDelete(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/Delete", _rsp);
        }


        public virtual void SaveList(Proto.DomainListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/List", _rsp);
        }


        public virtual void SaveGet(Proto.DomainGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/Get", _rsp);
        }


        public virtual void SaveFind(Proto.DomainFindResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/Find", _rsp);
        }


        public virtual void SaveSearch(Proto.DomainSearchResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/Search", _rsp);
        }


        public virtual void SaveExecute(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Domain/Execute", _rsp);
        }



    }
}
