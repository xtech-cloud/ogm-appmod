
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketView : BucketBaseView
    {
        public const string NAME = "ogm.file.BucketView";
        private BucketService service_ { get; set; }

        protected override void preSetup()
        {
            base.preSetup();
            service_ = findService(BucketService.NAME) as BucketService;
        }

        protected override void postSetup()
        {
            base.postSetup();
            addRouter("/sidemenu/tab/activated", handleTabActivated);
        }

        public void OpenObjectUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.file.Object");
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string target = _data as string;
            if (!target.Equals("ogm.file.Bucket"))
                return;

            var extendBridge = facade.getUiBridge() as IBucketExtendUiBridge;
            extendBridge.HandleTabActivated();
        }
    }
}
