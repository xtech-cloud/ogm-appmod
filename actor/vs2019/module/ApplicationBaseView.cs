
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationBaseView: View
    {
        protected Facade facade = null;
        protected ApplicationModel model = null;
        protected IApplicationUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ApplicationModel.NAME) as ApplicationModel;
            var service = findService(ApplicationService.NAME) as ApplicationService;
            facade = findFacade("ogm.actor.ApplicationFacade");
            ApplicationViewBridge vb = new ApplicationViewBridge();
            vb.view = this as ApplicationView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.ApplicationView");

           addRouter("/ogm/actor/Application/Add", this.handleApplicationAdd);
    
           addRouter("/ogm/actor/Application/Remove", this.handleApplicationRemove);
    
           addRouter("/ogm/actor/Application/List", this.handleApplicationList);
    
           addRouter("/ogm/actor/Application/Update", this.handleApplicationUpdate);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IApplicationUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.actor.Application"] = rootPanel;
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

        private void handleApplicationAdd(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleApplicationRemove(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleApplicationList(Model.Status _status, object _data)
        {
            var rsp = (Proto.ApplicationListResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleApplicationUpdate(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
