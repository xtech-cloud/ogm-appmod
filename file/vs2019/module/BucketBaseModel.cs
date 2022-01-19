
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


        public virtual void SaveMake(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/Make", _rsp);
        }


        public virtual void SaveList(Proto.BucketListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/List", _rsp);
        }


        public virtual void SaveRemove(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/Remove", _rsp);
        }


        public virtual void SaveGet(Proto.BucketGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/Get", _rsp);
        }


        public virtual void SaveFind(Proto.BucketFindResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/Find", _rsp);
        }


        public virtual void SaveSearch(Proto.BucketSearchResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/Search", _rsp);
        }


        public virtual void SaveUpdate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/Update", _rsp);
        }


        public virtual void SaveResetToken(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/ResetToken", _rsp);
        }


        public virtual void SaveGenerateManifest(Proto.BucketGenerateManifestResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/GenerateManifest", _rsp);
        }


        public virtual void SaveClean(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Bucket/Clean", _rsp);
        }



    }
}
