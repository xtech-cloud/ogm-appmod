
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketController: Controller
    {
        public const string NAME = "ogm.file.BucketController";

        private BucketView view {get;set;}

        protected override void preSetup()
        {
            view = findView(BucketView.NAME) as BucketView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.BucketController");
        }

        public void BucketList(Model.Status _reply, BucketModel.BucketStatus _status)
        {
            if(_reply.getCode() != 0)
            {
                view.Alert(_reply.getMessage());
            }
            view.RefreshBucketList(_status);
        }
    }
}
