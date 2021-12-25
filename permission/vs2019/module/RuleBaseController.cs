
using System;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class RuleBaseController: Controller
    {

        protected RuleView view {get;set;}

        protected override void preSetup()
        {
            view = findView(RuleView.NAME) as RuleView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.permission.RuleController");
        }
    }
}
