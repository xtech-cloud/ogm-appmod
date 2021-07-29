
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectModel : Model
    {
        public const string NAME = "ogm.file.ObjectModel";

        public class ObjectStatus : Model.Status
        {
            public const string NAME = "ogm.file.ObjectStatus";
        }

        private ObjectController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(ObjectController.NAME) as ObjectController;
            Error err;
            status_ = spawnStatus<ObjectStatus>(ObjectStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.file.ObjectStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.ObjectModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(ObjectStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        private ObjectStatus status
        {
            get
            {
                return status_ as ObjectStatus;
            }
        }
    }
}
