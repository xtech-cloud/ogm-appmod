
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryView: View
    {
        public const string NAME = "ogm.account.QueryView";

        private Facade facade = null;
        private QueryModel model = null;
        private IQueryUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(QueryModel.NAME) as QueryModel;
            var service = findService(QueryService.NAME) as QueryService;
            facade = findFacade("ogm.account.QueryFacade");
            QueryViewBridge vb = new QueryViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.QueryView");

           addRouter("/ogm/account/Query/List", this.handleQueryList);
    
           addRouter("/ogm/account/Query/Single", this.handleQuerySingle);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IQueryUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.account.Query"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleQueryList(Model.Status _status, object _data)
        {
            var rsp = (Proto.QueryListResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleQuerySingle(Model.Status _status, object _data)
        {
            var rsp = (Proto.QuerySingleResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
