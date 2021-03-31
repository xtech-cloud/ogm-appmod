
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class ObjectView: View
    {
        public const string NAME = "File.ObjectView";

        private Facade facade = null;
        private ObjectModel model = null;
        private IObjectUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ObjectModel.NAME) as ObjectModel;
            var service = findService(ObjectService.NAME) as ObjectService;
            facade = findFacade("File.ObjectFacade");
            ObjectViewBridge vb = new ObjectViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ObjectView");
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IObjectUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["/OGM/File/Object"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }
    }
}
