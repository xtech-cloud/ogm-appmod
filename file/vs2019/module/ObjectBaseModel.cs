
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


        public virtual void SavePrepare(Proto.ObjectPrepareResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Prepare", _rsp);
        }


        public virtual void SaveFlush(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Flush", _rsp);
        }


        public virtual void SaveLink(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Link", _rsp);
        }


        public virtual void SaveGet(Proto.ObjectGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Get", _rsp);
        }


        public virtual void SaveFind(Proto.ObjectFindResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Find", _rsp);
        }


        public virtual void SaveRemove(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Remove", _rsp);
        }


        public virtual void SaveList(Proto.ObjectListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/List", _rsp);
        }


        public virtual void SaveSearch(Proto.ObjectSearchResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Search", _rsp);
        }


        public virtual void SavePublish(Proto.ObjectPublishResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Publish", _rsp);
        }


        public virtual void SavePreview(Proto.ObjectPreviewResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Preview", _rsp);
        }


        public virtual void SaveRetract(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/file/Object/Retract", _rsp);
        }



    }
}
