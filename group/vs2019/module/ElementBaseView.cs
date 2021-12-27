
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group
{
    public class ElementBaseView: View
    {
        protected Facade facade = null;
        protected ElementModel model = null;
        protected IElementUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ElementModel.NAME) as ElementModel;
            var service = findService(ElementService.NAME) as ElementService;
            facade = findFacade("ogm.group.ElementFacade");
            ElementViewBridge vb = new ElementViewBridge();
            vb.view = this as ElementView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.ElementView");

            addObserver(ElementModel.NAME, "_.reply.arrived:ogm/group/Element/Add", this.handleReceiveElementAdd);

            addObserver(ElementModel.NAME, "_.reply.arrived:ogm/group/Element/Update", this.handleReceiveElementUpdate);

            addObserver(ElementModel.NAME, "_.reply.arrived:ogm/group/Element/List", this.handleReceiveElementList);

            addObserver(ElementModel.NAME, "_.reply.arrived:ogm/group/Element/Search", this.handleReceiveElementSearch);

            addObserver(ElementModel.NAME, "_.reply.arrived:ogm/group/Element/Remove", this.handleReceiveElementRemove);

            addObserver(ElementModel.NAME, "_.reply.arrived:ogm/group/Element/Get", this.handleReceiveElementGet);

            addObserver(ElementModel.NAME, "_.reply.arrived:ogm/group/Element/Where", this.handleReceiveElementWhere);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IElementUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.group.Element"] = rootPanel;
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

        private void handleReceiveElementAdd(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Element/Add is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveAdd(json);
        }

        private void handleReceiveElementUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Element/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveElementList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ElementListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Element/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveElementSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ElementListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Element/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

        private void handleReceiveElementRemove(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Element/Remove is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRemove(json);
        }

        private void handleReceiveElementGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ElementGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Element/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveElementWhere(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ElementWhereResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Element/Where is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveWhere(json);
        }

    }
}
