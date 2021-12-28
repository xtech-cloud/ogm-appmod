
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license
{
    public class SpaceBaseView: View
    {
        protected Facade facade = null;
        protected SpaceModel model = null;
        protected ISpaceUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(SpaceModel.NAME) as SpaceModel;
            var service = findService(SpaceService.NAME) as SpaceService;
            facade = findFacade("ogm.license.SpaceFacade");
            SpaceViewBridge vb = new SpaceViewBridge();
            vb.view = this as SpaceView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.SpaceView");

            addObserver(SpaceModel.NAME, "_.reply.arrived:ogm/license/Space/Create", this.handleReceiveSpaceCreate);

            addObserver(SpaceModel.NAME, "_.reply.arrived:ogm/license/Space/Update", this.handleReceiveSpaceUpdate);

            addObserver(SpaceModel.NAME, "_.reply.arrived:ogm/license/Space/Get", this.handleReceiveSpaceGet);

            addObserver(SpaceModel.NAME, "_.reply.arrived:ogm/license/Space/List", this.handleReceiveSpaceList);

            addObserver(SpaceModel.NAME, "_.reply.arrived:ogm/license/Space/Search", this.handleReceiveSpaceSearch);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as ISpaceUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.license.Space"] = rootPanel;
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

        private void handleReceiveSpaceCreate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Space/Create is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveCreate(json);
        }

        private void handleReceiveSpaceUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Space/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveSpaceGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SpaceGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Space/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveSpaceList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SpaceListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Space/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveSpaceSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SpaceListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Space/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

    }
}
