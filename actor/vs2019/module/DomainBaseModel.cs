
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
    }
}
