using System;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class BucketModel : Model
    {
        public const string NAME = "File.BucketModel";

        private BucketController controller = null;

        public class BucketStatus : Model.Status
        {
            public const string NAME = "BucketStatus";
        }

        protected override void preSetup()
        {
            Error err;
            status_ = spawnStatus<BucketStatus>(BucketStatus.NAME, out err);
            controller = findController(BucketController.NAME) as BucketController;
        }

        protected override void setup()
        {
            getLogger().Trace("setup BucketModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(BucketStatus.NAME, out err);
        }

        private BucketStatus status
        {
            get
            {
                return status_ as BucketStatus;
            }
        }
    }
}
