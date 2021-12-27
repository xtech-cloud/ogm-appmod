
using System;
using XTC.oelMVCS;

namespace ogm.group
{
    public class ElementBaseModel : Model
    {

        public class ElementBaseStatus : Model.Status
        {
            public const string NAME = "ogm.group.ElementStatus";
        }

        protected ElementController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(ElementController.NAME) as ElementController;
            Error err;
            status_ = spawnStatus<ElementModel.ElementStatus>(ElementModel.ElementStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.group.ElementStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.ElementModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(ElementModel.ElementStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected ElementModel.ElementStatus status
        {
            get
            {
                return status_ as ElementModel.ElementStatus;
            }
        }


        public virtual void SaveAdd(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Element/Add", _rsp);
        }


        public virtual void SaveUpdate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Element/Update", _rsp);
        }


        public virtual void SaveList(Proto.ElementListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Element/List", _rsp);
        }


        public virtual void SaveSearch(Proto.ElementListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Element/Search", _rsp);
        }


        public virtual void SaveRemove(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Element/Remove", _rsp);
        }


        public virtual void SaveGet(Proto.ElementGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Element/Get", _rsp);
        }


        public virtual void SaveWhere(Proto.ElementWhereResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/group/Element/Where", _rsp);
        }



    }
}
