
using System;
using XTC.oelMVCS;

namespace ogm.license
{
    public class KeyBaseModel : Model
    {

        public class KeyBaseStatus : Model.Status
        {
            public const string NAME = "ogm.license.KeyStatus";
        }

        protected KeyController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(KeyController.NAME) as KeyController;
            Error err;
            status_ = spawnStatus<KeyModel.KeyStatus>(KeyModel.KeyStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.license.KeyStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.KeyModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(KeyModel.KeyStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected KeyModel.KeyStatus status
        {
            get
            {
                return status_ as KeyModel.KeyStatus;
            }
        }


        public virtual void SaveGenerate(Proto.KeyGenerateResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Key/Generate", _rsp);
        }


        public virtual void SaveActivate(Proto.KeyActivateResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Key/Activate", _rsp);
        }


        public virtual void SaveUpdate(Proto.UuidResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Key/Update", _rsp);
        }


        public virtual void SaveGet(Proto.KeyGetResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Key/Get", _rsp);
        }


        public virtual void SaveList(Proto.KeyListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Key/List", _rsp);
        }


        public virtual void SaveSearch(Proto.KeyListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/license/Key/Search", _rsp);
        }



    }
}
