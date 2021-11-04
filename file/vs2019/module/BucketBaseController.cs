
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketBaseController: Controller
    {

        protected BucketView view {get;set;}

        protected override void preSetup()
        {
            view = findView(BucketView.NAME) as BucketView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.BucketController");
        }
    }
}
