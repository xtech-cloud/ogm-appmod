
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketModel : Model
    {
        public const string NAME = "ogm.file.BucketModel";

        public class BucketStatus : Model.Status
        {
            public const string NAME = "ogm.file.BucketStatus";
            public long total = 0;
            public Proto.BucketEntity[] entity = new Proto.BucketEntity[0];
        }

        private BucketController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(BucketController.NAME) as BucketController;
            Error err;
            status_ = spawnStatus<BucketStatus>(BucketStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.file.BucketStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.BucketModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(BucketStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        private BucketStatus status
        {
            get
            {
                return status_ as BucketStatus;
            }
        }

        public void UpdateBucketList(Status _reply, long _total, Proto.BucketEntity[] _entity)
        {
            status.total = _total;
            status.entity = _entity;
            controller.BucketList(_reply, status);
        }
    }
}
