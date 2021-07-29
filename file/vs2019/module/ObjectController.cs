
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectController: Controller
    {
        public const string NAME = "ogm.file.ObjectController";

        private ObjectView view {get;set;}

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
