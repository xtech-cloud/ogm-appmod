
using System;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class HealthyBaseModel : Model
    {

        public class HealthyStatus : Model.Status
        {
            public const string NAME = "ogm.startkit.HealthyStatus";
        }

        protected HealthyController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(HealthyController.NAME) as HealthyController;
            Error err;
            status_ = spawnStatus<HealthyStatus>(HealthyStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.startkit.HealthyStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.startkit.HealthyModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(HealthyStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected HealthyStatus status
        {
            get
            {
                return status_ as HealthyStatus;
            }
        }
    }
}
