
using System;
using XTC.oelMVCS;

namespace ogm.group
{
    public class ElementBaseController: Controller
    {

        protected ElementView view {get;set;}

        protected override void preSetup()
        {
            view = findView(ElementView.NAME) as ElementView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.ElementController");
        }
    }
}
