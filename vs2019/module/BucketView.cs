
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class BucketView: View
    {
        public const string NAME = "File.BucketView";

        private Facade facade = null;
        private BucketModel model = null;
        private IBucketUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(BucketModel.NAME) as BucketModel;
            var service = findService(BucketService.NAME) as BucketService;
            facade = findFacade("File.BucketFacade");
            BucketViewBridge vb = new BucketViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup BucketView");
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IBucketUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["/OGM/File/Bucket"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }
    }
}
