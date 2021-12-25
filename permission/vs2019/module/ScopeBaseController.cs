
using System;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class ScopeBaseController: Controller
    {

        protected ScopeView view {get;set;}

        protected override void preSetup()
        {
            view = findView(ScopeView.NAME) as ScopeView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.permission.ScopeController");
        }
    }
}
