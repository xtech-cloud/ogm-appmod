using System;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class BucketController: Controller
    {
        public const string NAME = "File.BucketController";
        private BucketView view = null;

        protected override void preSetup()
        {
            view = findView(BucketView.NAME) as BucketView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup BucketController");
        }
    }
}
