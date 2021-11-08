
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationBaseController: Controller
    {

        protected ApplicationView view {get;set;}

        protected override void preSetup()
        {
            view = findView(ApplicationView.NAME) as ApplicationView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.ApplicationController");
        }
    }
}
