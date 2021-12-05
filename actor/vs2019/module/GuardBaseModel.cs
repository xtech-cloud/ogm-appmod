
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardBaseModel : Model
    {

        public class GuardBaseStatus : Model.Status
        {
            public const string NAME = "ogm.actor.GuardStatus";
        }

        protected GuardController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(GuardController.NAME) as GuardController;
            Error err;
            status_ = spawnStatus<GuardModel.GuardStatus>(GuardModel.GuardStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.actor.GuardStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.GuardModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(GuardModel.GuardStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected GuardModel.GuardStatus status
        {
            get
            {
                return status_ as GuardModel.GuardStatus;
            }
        }


        public virtual void SaveFetch(Proto.GuardFetchResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Guard/Fetch", _rsp);
        }


        public virtual void SaveEdit(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Guard/Edit", _rsp);
        }


        public virtual void SaveDelete(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Guard/Delete", _rsp);
        }



    }
}
