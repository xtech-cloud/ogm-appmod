
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainBaseView: View
    {
        protected Facade facade = null;
        protected DomainModel model = null;
        protected IDomainUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(DomainModel.NAME) as DomainModel;
            var service = findService(DomainService.NAME) as DomainService;
            facade = findFacade("ogm.actor.DomainFacade");
            DomainViewBridge vb = new DomainViewBridge();
            vb.view = this as DomainView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.DomainView");

           addRouter("/ogm/actor/Domain/Create", this.handleDomainCreate);
    
           addRouter("/ogm/actor/Domain/Delete", this.handleDomainDelete);
    
           addRouter("/ogm/actor/Domain/List", this.handleDomainList);
    
           addRouter("/ogm/actor/Domain/Find", this.handleDomainFind);
    
           addRouter("/ogm/actor/Domain/Search", this.handleDomainSearch);
    
           addRouter("/ogm/actor/Domain/Execute", this.handleDomainExecute);
    
           addRouter("/ogm/actor/Domain/FetchDevice", this.handleDomainFetchDevice);
    
           addRouter("/ogm/actor/Domain/EditDevice", this.handleDomainEditDevice);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IDomainUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.actor.Domain"] = rootPanel;
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

        private void handleDomainCreate(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleDomainDelete(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleDomainList(Model.Status _status, object _data)
        {
            var rsp = (Proto.DomainListResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleDomainFind(Model.Status _status, object _data)
        {
            var rsp = (Proto.DomainFindResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleDomainSearch(Model.Status _status, object _data)
        {
            var rsp = (Proto.DomainSearchResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleDomainExecute(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleDomainFetchDevice(Model.Status _status, object _data)
        {
            var rsp = (Proto.DomainFetchDeviceResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleDomainEditDevice(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
