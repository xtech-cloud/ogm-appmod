
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectBaseController: Controller
    {

        protected ObjectView view {get;set;}

        protected override void preSetup()
        {
            view = findView(ObjectView.NAME) as ObjectView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.ObjectController");
        }
    }
}
