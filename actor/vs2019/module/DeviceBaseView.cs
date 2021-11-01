
using System;
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

           addRouter("/ogm/actor/Device/List", this.handleDeviceList);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IDeviceUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.actor.Device"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleDeviceList(Model.Status _status, object _data)
        {
            var rsp = (Proto.DeviceListResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
