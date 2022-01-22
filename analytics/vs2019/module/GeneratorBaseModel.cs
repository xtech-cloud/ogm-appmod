
using System;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class GeneratorBaseModel : Model
    {

        public class GeneratorBaseStatus : Model.Status
        {
            public const string NAME = "ogm.analytics.GeneratorStatus";
        }

        protected GeneratorController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(GeneratorController.NAME) as GeneratorController;
            Error err;
            status_ = spawnStatus<GeneratorModel.GeneratorStatus>(GeneratorModel.GeneratorStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.analytics.GeneratorStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.analytics.GeneratorModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(GeneratorModel.GeneratorStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected GeneratorModel.GeneratorStatus status
        {
            get
            {
                return status_ as GeneratorModel.GeneratorStatus;
            }
        }


        public virtual void SaveAgent(Proto.GeneratorAgentResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/analytics/Generator/Agent", _rsp);
        }


        public virtual void SaveRecord(Proto.GeneratorRecordResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/analytics/Generator/Record", _rsp);
        }



    }
}
