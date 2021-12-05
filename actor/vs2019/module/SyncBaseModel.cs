
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncBaseModel : Model
    {

        public class SyncBaseStatus : Model.Status
        {
            public const string NAME = "ogm.actor.SyncStatus";
        }

        protected SyncController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(SyncController.NAME) as SyncController;
            Error err;
            status_ = spawnStatus<SyncModel.SyncStatus>(SyncModel.SyncStatus.NAME, out err);
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
            killStatus(SyncModel.SyncStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected SyncModel.SyncStatus status
        {
            get
            {
                return status_ as SyncModel.SyncStatus;
            }
        }


        public virtual void SavePush(Proto.SyncPushResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Sync/Push", _rsp);
        }


        public virtual void SavePull(Proto.SyncPullResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Sync/Pull", _rsp);
        }


        public virtual void SaveUpload(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Sync/Upload", _rsp);
        }



    }
}
