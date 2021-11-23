
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryBaseController: Controller
    {

        protected QueryView view {get;set;}

        protected override void preSetup()
        {
            view = findView(QueryView.NAME) as QueryView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.QueryController");
        }
    }
}
