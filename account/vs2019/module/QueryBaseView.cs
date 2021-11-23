
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryBaseView: View
    {
        protected Facade facade = null;
        protected QueryModel model = null;
        protected IQueryUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(QueryModel.NAME) as QueryModel;
            var service = findService(QueryService.NAME) as QueryService;
            facade = findFacade("ogm.account.QueryFacade");
            QueryViewBridge vb = new QueryViewBridge();
            vb.view = this as QueryView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.QueryView");

            addObserver(QueryModel.NAME, "_.reply.arrived:ogm/account/Query/List", this.handleReceiveQueryList);

            addObserver(QueryModel.NAME, "_.reply.arrived:ogm/account/Query/Single", this.handleReceiveQuerySingle);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IQueryUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.account.Query"] = rootPanel;
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

        private void handleReceiveQueryList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.QueryListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Query/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveQuerySingle(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.QuerySingleResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Query/Single is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSingle(json);
        }

    }
}
