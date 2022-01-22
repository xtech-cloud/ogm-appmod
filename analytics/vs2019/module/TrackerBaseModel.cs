
using System;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class TrackerBaseModel : Model
    {

        public class TrackerBaseStatus : Model.Status
        {
            public const string NAME = "ogm.analytics.TrackerStatus";
        }

        protected TrackerController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(TrackerController.NAME) as TrackerController;
            Error err;
            status_ = spawnStatus<TrackerModel.TrackerStatus>(TrackerModel.TrackerStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.analytics.TrackerStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.analytics.TrackerModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(TrackerModel.TrackerStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected TrackerModel.TrackerStatus status
        {
            get
            {
                return status_ as TrackerModel.TrackerStatus;
            }
        }


        public virtual void SaveWake(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/analytics/Tracker/Wake", _rsp);
        }


        public virtual void SaveRecord(Proto.BlankResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/analytics/Tracker/Record", _rsp);
        }



    }
}
