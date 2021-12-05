
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncBaseView: View
    {
        protected Facade facade = null;
        protected SyncModel model = null;
        protected ISyncUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(SyncModel.NAME) as SyncModel;
            var service = findService(SyncService.NAME) as SyncService;
            facade = findFacade("ogm.actor.SyncFacade");
            SyncViewBridge vb = new SyncViewBridge();
            vb.view = this as SyncView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.SyncView");

            addObserver(SyncModel.NAME, "_.reply.arrived:ogm/actor/Sync/Push", this.handleReceiveSyncPush);

            addObserver(SyncModel.NAME, "_.reply.arrived:ogm/actor/Sync/Pull", this.handleReceiveSyncPull);

            addObserver(SyncModel.NAME, "_.reply.arrived:ogm/actor/Sync/Upload", this.handleReceiveSyncUpload);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as ISyncUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.actor.Sync"] = rootPanel;
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

        private void handleReceiveSyncPush(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SyncPushResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Sync/Push is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceivePush(json);
        }

        private void handleReceiveSyncPull(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SyncPullResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Sync/Pull is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceivePull(json);
        }

        private void handleReceiveSyncUpload(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BlankResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Sync/Upload is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpload(json);
        }

    }
}
