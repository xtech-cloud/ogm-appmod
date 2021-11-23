
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryBaseModel : Model
    {

        public class QueryBaseStatus : Model.Status
        {
            public const string NAME = "ogm.account.QueryStatus";
        }

        protected QueryController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(QueryController.NAME) as QueryController;
            Error err;
            status_ = spawnStatus<QueryModel.QueryStatus>(QueryModel.QueryStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.account.QueryStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.QueryModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(QueryModel.QueryStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected QueryModel.QueryStatus status
        {
            get
            {
                return status_ as QueryModel.QueryStatus;
            }
        }


        public virtual void SaveList(Proto.QueryListResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Query/List", _rsp);
        }


        public virtual void SaveSingle(Proto.QuerySingleResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Query/Single", _rsp);
        }



    }
}
