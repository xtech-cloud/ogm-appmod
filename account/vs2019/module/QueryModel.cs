
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryModel : Model
    {
        public const string NAME = "ogm.account.QueryModel";

        public class QueryStatus : Model.Status
        {
            public const string NAME = "ogm.account.QueryStatus";
        }

        private QueryController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(QueryController.NAME) as QueryController;
            Error err;
            status_ = spawnStatus<QueryStatus>(QueryStatus.NAME, out err);
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
            killStatus(QueryStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        private QueryStatus status
        {
            get
            {
                return status_ as QueryStatus;
            }
        }
    }
}
