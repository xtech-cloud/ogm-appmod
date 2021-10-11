
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class MyHealthyView: View
    {
        public const string NAME = "ogm.startkit.MyHealthyView";

        private Facade facade = null;
        private MyHealthyModel model = null;
        private IMyHealthyUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(MyHealthyModel.NAME) as MyHealthyModel;
            var service = findService(MyHealthyService.NAME) as MyHealthyService;
            facade = findFacade("ogm.startkit.MyHealthyFacade");
            MyHealthyViewBridge vb = new MyHealthyViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.startkit.MyHealthyView");

           addRouter("/ogm/startkit/MyHealthy/Echo", this.handleMyHealthyEcho);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IMyHealthyUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.startkit.MyHealthy"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleMyHealthyEcho(Model.Status _status, object _data)
        {
            var rsp = (Proto.Response)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
