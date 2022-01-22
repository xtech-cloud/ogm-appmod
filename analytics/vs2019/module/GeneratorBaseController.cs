
using System;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class GeneratorBaseController: Controller
    {

        protected GeneratorView view {get;set;}

        protected override void preSetup()
        {
            view = findView(GeneratorView.NAME) as GeneratorView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.analytics.GeneratorController");
        }
    }
}
