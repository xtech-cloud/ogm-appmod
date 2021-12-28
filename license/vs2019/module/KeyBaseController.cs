
using System;
using XTC.oelMVCS;

namespace ogm.license
{
    public class KeyBaseController: Controller
    {

        protected KeyView view {get;set;}

        protected override void preSetup()
        {
            view = findView(KeyView.NAME) as KeyView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.KeyController");
        }
    }
}
