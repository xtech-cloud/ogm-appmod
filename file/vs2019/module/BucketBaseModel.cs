
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketBaseModel : Model
    {

        public class BucketBaseStatus : Model.Status
        {
            public const string NAME = "ogm.file.BucketStatus";
        }

        protected BucketController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(BucketController.NAME) as BucketController;
            Error err;
            status_ = spawnStatus<BucketModel.BucketStatus>(BucketModel.BucketStatus.NAME, out err);
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
            killStatus(BucketModel.BucketStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected BucketModel.BucketStatus status
        {
            get
            {
                return status_ as BucketModel.BucketStatus;
            }
        }
    }
}
