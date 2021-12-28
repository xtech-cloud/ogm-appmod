
using System;
using XTC.oelMVCS;

namespace ogm.license
{
    public class SpaceBaseModel : Model
    {

        public class SpaceBaseStatus : Model.Status
        {
            public const string NAME = "ogm.license.SpaceStatus";
        }

        protected SpaceController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(SpaceController.NAME) as SpaceController;
            Error err;
            status_ = spawnStatus<SpaceModel.SpaceStatus>(SpaceModel.SpaceStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.license.SpaceStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.SpaceModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(SpaceModel.SpaceStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected SpaceModel.SpaceStatus status
        {
            get
            {
                return status_ as SpaceModel.SpaceStatus;
            }
        }


        public virtual void SaveCreate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Space/Create", _rsp);
        }


        public virtual void SaveUpdate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Space/Update", _rsp);
        }


        public virtual void SaveGet(Proto.SpaceGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Space/Get", _rsp);
        }


        public virtual void SaveList(Proto.SpaceListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Space/List", _rsp);
        }


        public virtual void SaveSearch(Proto.SpaceListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Space/Search", _rsp);
        }



    }
}
