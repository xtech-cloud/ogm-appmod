
using System.Text.Json;
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

            addObserver(ApplicationModel.NAME, "_.reply.arrived:ogm/actor/Application/Add", this.handleReceiveApplicationAdd);

            addObserver(ApplicationModel.NAME, "_.reply.arrived:ogm/actor/Application/Remove", this.handleReceiveApplicationRemove);

            addObserver(ApplicationModel.NAME, "_.reply.arrived:ogm/actor/Application/List", this.handleReceiveApplicationList);

            addObserver(ApplicationModel.NAME, "_.reply.arrived:ogm/actor/Application/Get", this.handleReceiveApplicationGet);

            addObserver(ApplicationModel.NAME, "_.reply.arrived:ogm/actor/Application/Update", this.handleReceiveApplicationUpdate);

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

        private void handleReceiveApplicationAdd(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Application/Add is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveAdd(json);
        }

        private void handleReceiveApplicationRemove(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Application/Remove is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRemove(json);
        }

        private void handleReceiveApplicationList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ApplicationListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Application/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveApplicationGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ApplicationGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Application/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveApplicationUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Application/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

    }
}
