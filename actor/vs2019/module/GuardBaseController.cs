
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardBaseController: Controller
    {

        protected GuardView view {get;set;}

        protected override void preSetup()
        {
            view = findView(GuardView.NAME) as GuardView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.GuardController");
        }
    }
}
