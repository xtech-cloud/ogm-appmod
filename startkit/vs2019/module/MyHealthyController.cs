
using System;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class MyHealthyController: Controller
    {
        public const string NAME = "ogm.startkit.MyHealthyController";

        private MyHealthyView view {get;set;}

        protected override void preSetup()
        {
            view = findView(MyHealthyView.NAME) as MyHealthyView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.startkit.MyHealthyController");
        }
    }
}
