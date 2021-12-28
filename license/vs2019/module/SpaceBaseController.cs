
using System;
using XTC.oelMVCS;

namespace ogm.license
{
    public class SpaceBaseController: Controller
    {

        protected SpaceView view {get;set;}

        protected override void preSetup()
        {
            view = findView(SpaceView.NAME) as SpaceView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.SpaceController");
        }
    }
}
