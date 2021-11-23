
using System;
using XTC.oelMVCS;

namespace ogm.group
{
    public class CollectionBaseModel : Model
    {

        public class CollectionBaseStatus : Model.Status
        {
            public const string NAME = "ogm.group.CollectionStatus";
        }

        protected CollectionController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(CollectionController.NAME) as CollectionController;
            Error err;
            status_ = spawnStatus<CollectionModel.CollectionStatus>(CollectionModel.CollectionStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.group.CollectionStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.CollectionModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(CollectionModel.CollectionStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected CollectionModel.CollectionStatus status
        {
            get
            {
                return status_ as CollectionModel.CollectionStatus;
            }
        }


        public virtual void SaveMake(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Collection/Make", _rsp);
        }


        public virtual void SaveList(Proto.CollectionListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Collection/List", _rsp);
        }


        public virtual void SaveRemove(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Collection/Remove", _rsp);
        }


        public virtual void SaveGet(Proto.CollectionGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Collection/Get", _rsp);
        }



    }
}
