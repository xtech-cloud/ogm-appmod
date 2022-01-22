
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class GeneratorBaseView: View
    {
        protected Facade facade = null;
        protected GeneratorModel model = null;
        protected IGeneratorUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(GeneratorModel.NAME) as GeneratorModel;
            var service = findService(GeneratorService.NAME) as GeneratorService;
            facade = findFacade("ogm.analytics.GeneratorFacade");
            GeneratorViewBridge vb = new GeneratorViewBridge();
            vb.view = this as GeneratorView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.analytics.GeneratorView");

            addObserver(GeneratorModel.NAME, "_.reply.arrived:ogm/analytics/Generator/Agent", this.handleReceiveGeneratorAgent);

            addObserver(GeneratorModel.NAME, "_.reply.arrived:ogm/analytics/Generator/Record", this.handleReceiveGeneratorRecord);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IGeneratorUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.analytics.Generator"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
            // 监听权限更新
            addRouter("/permission/updated", this.handlePermissionUpdated);
        }

        protected void handlePermissionUpdated(Model.Status _status, object _data)
        {
            Dictionary<string, string> permission = (Dictionary<string,string>) _data;
            bridge.UpdatePermission(permission);
        }


        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleReceiveGeneratorAgent(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.GeneratorAgentResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Generator/Agent is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveAgent(json);
        }

        private void handleReceiveGeneratorRecord(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.GeneratorRecordResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Generator/Record is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRecord(json);
        }

    }
}
