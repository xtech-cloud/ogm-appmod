
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncBaseModel : Model
    {

        public class SyncStatus : Model.Status
        {
            public const string NAME = "ogm.actor.SyncStatus";
        }

        protected SyncController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(SyncController.NAME) as SyncController;
            Error err;
            status_ = spawnStatus<SyncStatus>(SyncStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.actor.SyncStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.SyncModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(SyncStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected SyncStatus status
        {
            get
            {
                return status_ as SyncStatus;
            }
        }
    }
}
