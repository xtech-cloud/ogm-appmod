
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license
{
    public class KeyBaseView: View
    {
        protected Facade facade = null;
        protected KeyModel model = null;
        protected IKeyUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(KeyModel.NAME) as KeyModel;
            var service = findService(KeyService.NAME) as KeyService;
            facade = findFacade("ogm.license.KeyFacade");
            KeyViewBridge vb = new KeyViewBridge();
            vb.view = this as KeyView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.KeyView");

            addObserver(KeyModel.NAME, "_.reply.arrived:ogm/license/Key/Generate", this.handleReceiveKeyGenerate);

            addObserver(KeyModel.NAME, "_.reply.arrived:ogm/license/Key/Activate", this.handleReceiveKeyActivate);

            addObserver(KeyModel.NAME, "_.reply.arrived:ogm/license/Key/Update", this.handleReceiveKeyUpdate);

            addObserver(KeyModel.NAME, "_.reply.arrived:ogm/license/Key/Get", this.handleReceiveKeyGet);

            addObserver(KeyModel.NAME, "_.reply.arrived:ogm/license/Key/List", this.handleReceiveKeyList);

            addObserver(KeyModel.NAME, "_.reply.arrived:ogm/license/Key/Search", this.handleReceiveKeySearch);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IKeyUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.license.Key"] = rootPanel;
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

        private void handleReceiveKeyGenerate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.KeyGenerateResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Key/Generate is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGenerate(json);
        }

        private void handleReceiveKeyActivate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.KeyActivateResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Key/Activate is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveActivate(json);
        }

        private void handleReceiveKeyUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Key/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveKeyGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.KeyGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Key/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveKeyList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.KeyListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Key/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveKeySearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.KeyListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Key/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

    }
}
