
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceBaseModel : Model
    {

        public class DeviceBaseStatus : Model.Status
        {
            public const string NAME = "ogm.actor.DeviceStatus";
        }

        protected DeviceController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(DeviceController.NAME) as DeviceController;
            Error err;
            status_ = spawnStatus<DeviceModel.DeviceStatus>(DeviceModel.DeviceStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.actor.DeviceStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.DeviceModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(DeviceModel.DeviceStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected DeviceModel.DeviceStatus status
        {
            get
            {
                return status_ as DeviceModel.DeviceStatus;
            }
        }


        public virtual void SaveList(Proto.DeviceListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Device/List", _rsp);
        }


        public virtual void SaveSearch(Proto.DeviceSearchResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/actor/Device/Search", _rsp);
        }



    }
}
