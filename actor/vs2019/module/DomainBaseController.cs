
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainBaseController: Controller
    {

        protected DomainView view {get;set;}

        protected override void preSetup()
        {
            view = findView(DomainView.NAME) as DomainView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.DomainController");
        }
    }
}
