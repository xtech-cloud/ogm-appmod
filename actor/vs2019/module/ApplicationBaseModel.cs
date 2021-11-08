
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationBaseModel : Model
    {

        public class ApplicationBaseStatus : Model.Status
        {
            public const string NAME = "ogm.actor.ApplicationStatus";
        }

        protected ApplicationController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(ApplicationController.NAME) as ApplicationController;
            Error err;
            status_ = spawnStatus<ApplicationModel.ApplicationStatus>(ApplicationModel.ApplicationStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.actor.ApplicationStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.ApplicationModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(ApplicationModel.ApplicationStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected ApplicationModel.ApplicationStatus status
        {
            get
            {
                return status_ as ApplicationModel.ApplicationStatus;
            }
        }
    }
}
