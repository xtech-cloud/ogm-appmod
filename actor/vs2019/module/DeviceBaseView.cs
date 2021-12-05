
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceBaseView: View
    {
        protected Facade facade = null;
        protected DeviceModel model = null;
        protected IDeviceUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(DeviceModel.NAME) as DeviceModel;
            var service = findService(DeviceService.NAME) as DeviceService;
            facade = findFacade("ogm.actor.DeviceFacade");
            DeviceViewBridge vb = new DeviceViewBridge();
            vb.view = this as DeviceView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.DeviceView");

            addObserver(DeviceModel.NAME, "_.reply.arrived:ogm/actor/Device/List", this.handleReceiveDeviceList);

            addObserver(DeviceModel.NAME, "_.reply.arrived:ogm/actor/Device/Search", this.handleReceiveDeviceSearch);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IDeviceUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.actor.Device"] = rootPanel;
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

        private void handleReceiveDeviceList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.DeviceListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Device/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveDeviceSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.DeviceSearchResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Device/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

    }
}
