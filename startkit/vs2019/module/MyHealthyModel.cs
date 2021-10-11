
using System;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class MyHealthyModel : Model
    {
        public const string NAME = "ogm.startkit.MyHealthyModel";

        public class MyHealthyStatus : Model.Status
        {
            public const string NAME = "ogm.startkit.MyHealthyStatus";
        }

        private MyHealthyController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(MyHealthyController.NAME) as MyHealthyController;
            Error err;
            status_ = spawnStatus<MyHealthyStatus>(MyHealthyStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.startkit.MyHealthyStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.startkit.MyHealthyModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(MyHealthyStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        private MyHealthyStatus status
        {
            get
            {
                return status_ as MyHealthyStatus;
            }
        }
    }
}
