
using System;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class HealthyBaseController: Controller
    {

        protected HealthyView view {get;set;}

        protected override void preSetup()
        {
            view = findView(HealthyView.NAME) as HealthyView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.startkit.HealthyController");
        }
    }
}
