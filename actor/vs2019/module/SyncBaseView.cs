
using System;
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

           addRouter("/ogm/actor/Sync/Push", this.handleSyncPush);
    
           addRouter("/ogm/actor/Sync/Pull", this.handleSyncPull);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as ISyncUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.actor.Sync"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleSyncPush(Model.Status _status, object _data)
        {
            var rsp = (Proto.SyncPushResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleSyncPull(Model.Status _status, object _data)
        {
            var rsp = (Proto.SyncPullResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
