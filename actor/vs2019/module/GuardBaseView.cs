
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardBaseView: View
    {
        protected Facade facade = null;
        protected GuardModel model = null;
        protected IGuardUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(GuardModel.NAME) as GuardModel;
            var service = findService(GuardService.NAME) as GuardService;
            facade = findFacade("ogm.actor.GuardFacade");
            GuardViewBridge vb = new GuardViewBridge();
            vb.view = this as GuardView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.GuardView");

            addObserver(GuardModel.NAME, "_.reply.arrived:ogm/actor/Guard/Fetch", this.handleReceiveGuardFetch);

            addObserver(GuardModel.NAME, "_.reply.arrived:ogm/actor/Guard/Edit", this.handleReceiveGuardEdit);

            addObserver(GuardModel.NAME, "_.reply.arrived:ogm/actor/Guard/Delete", this.handleReceiveGuardDelete);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IGuardUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.actor.Guard"] = rootPanel;
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

        private void handleReceiveGuardFetch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.GuardFetchResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Guard/Fetch is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveFetch(json);
        }

        private void handleReceiveGuardEdit(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BlankResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Guard/Edit is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveEdit(json);
        }

        private void handleReceiveGuardDelete(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BlankResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Guard/Delete is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveDelete(json);
        }

    }
}
