
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class TrackerBaseView: View
    {
        protected Facade facade = null;
        protected TrackerModel model = null;
        protected ITrackerUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(TrackerModel.NAME) as TrackerModel;
            var service = findService(TrackerService.NAME) as TrackerService;
            facade = findFacade("ogm.analytics.TrackerFacade");
            TrackerViewBridge vb = new TrackerViewBridge();
            vb.view = this as TrackerView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.analytics.TrackerView");

            addObserver(TrackerModel.NAME, "_.reply.arrived:ogm/analytics/Tracker/Wake", this.handleReceiveTrackerWake);

            addObserver(TrackerModel.NAME, "_.reply.arrived:ogm/analytics/Tracker/Record", this.handleReceiveTrackerRecord);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as ITrackerUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.analytics.Tracker"] = rootPanel;
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

        private void handleReceiveTrackerWake(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BlankResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Tracker/Wake is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveWake(json);
        }

        private void handleReceiveTrackerRecord(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BlankResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Tracker/Record is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRecord(json);
        }

    }
}
