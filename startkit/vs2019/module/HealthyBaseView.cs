
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class HealthyBaseView: View
    {
        protected Facade facade = null;
        protected HealthyModel model = null;
        protected IHealthyUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(HealthyModel.NAME) as HealthyModel;
            var service = findService(HealthyService.NAME) as HealthyService;
            facade = findFacade("ogm.startkit.HealthyFacade");
            HealthyViewBridge vb = new HealthyViewBridge();
            vb.view = this as HealthyView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.startkit.HealthyView");

           addRouter("/ogm/startkit/Healthy/Echo", this.handleHealthyEcho);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IHealthyUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.startkit.Healthy"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleHealthyEcho(Model.Status _status, object _data)
        {
            var rsp = (Proto.Response)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
