
using System;
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

           addRouter("/ogm/actor/Guard/Fetch", this.handleGuardFetch);
    
           addRouter("/ogm/actor/Guard/Edit", this.handleGuardEdit);
    
           addRouter("/ogm/actor/Guard/Delete", this.handleGuardDelete);
    
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

        private void handleGuardFetch(Model.Status _status, object _data)
        {
            var rsp = (Proto.GuardFetchResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleGuardEdit(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleGuardDelete(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
