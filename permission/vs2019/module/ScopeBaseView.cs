
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class ScopeBaseView: View
    {
        protected Facade facade = null;
        protected ScopeModel model = null;
        protected IScopeUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ScopeModel.NAME) as ScopeModel;
            var service = findService(ScopeService.NAME) as ScopeService;
            facade = findFacade("ogm.permission.ScopeFacade");
            ScopeViewBridge vb = new ScopeViewBridge();
            vb.view = this as ScopeView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.permission.ScopeView");

            addObserver(ScopeModel.NAME, "_.reply.arrived:ogm/permission/Scope/Create", this.handleReceiveScopeCreate);

            addObserver(ScopeModel.NAME, "_.reply.arrived:ogm/permission/Scope/Update", this.handleReceiveScopeUpdate);

            addObserver(ScopeModel.NAME, "_.reply.arrived:ogm/permission/Scope/Delete", this.handleReceiveScopeDelete);

            addObserver(ScopeModel.NAME, "_.reply.arrived:ogm/permission/Scope/Get", this.handleReceiveScopeGet);

            addObserver(ScopeModel.NAME, "_.reply.arrived:ogm/permission/Scope/List", this.handleReceiveScopeList);

            addObserver(ScopeModel.NAME, "_.reply.arrived:ogm/permission/Scope/Search", this.handleReceiveScopeSearch);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IScopeUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.permission.Scope"] = rootPanel;
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

        private void handleReceiveScopeCreate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Scope/Create is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveCreate(json);
        }

        private void handleReceiveScopeUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Scope/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveScopeDelete(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Scope/Delete is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveDelete(json);
        }

        private void handleReceiveScopeGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ScopeGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Scope/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveScopeList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ScopeListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Scope/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveScopeSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ScopeListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Scope/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

    }
}
