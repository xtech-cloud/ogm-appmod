
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectBaseModel : Model
    {

        public class ObjectBaseStatus : Model.Status
        {
            public const string NAME = "ogm.file.ObjectStatus";
        }

        protected ObjectController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(ObjectController.NAME) as ObjectController;
            Error err;
            status_ = spawnStatus<ObjectModel.ObjectStatus>(ObjectModel.ObjectStatus.NAME, out err);
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
            killStatus(ObjectModel.ObjectStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected ObjectModel.ObjectStatus status
        {
            get
            {
                return status_ as ObjectModel.ObjectStatus;
            }
        }
    }
}
