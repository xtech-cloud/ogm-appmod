
using System;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class BucketModel : Model
    {
        public const string NAME = "File.BucketModel";

        public class BucketStatus : Model.Status
        {
            public const string NAME = "File.BucketStatus";
        }

        protected override void preSetup()
        {
            Error err;
            status_ = spawnStatus<BucketStatus>(BucketStatus.NAME, out err);
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
