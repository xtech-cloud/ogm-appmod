
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class RuleBaseView: View
    {
        protected Facade facade = null;
        protected RuleModel model = null;
        protected IRuleUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(RuleModel.NAME) as RuleModel;
            var service = findService(RuleService.NAME) as RuleService;
            facade = findFacade("ogm.permission.RuleFacade");
            RuleViewBridge vb = new RuleViewBridge();
            vb.view = this as RuleView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.permission.RuleView");

            addObserver(RuleModel.NAME, "_.reply.arrived:ogm/permission/Rule/Add", this.handleReceiveRuleAdd);

            addObserver(RuleModel.NAME, "_.reply.arrived:ogm/permission/Rule/Update", this.handleReceiveRuleUpdate);

            addObserver(RuleModel.NAME, "_.reply.arrived:ogm/permission/Rule/Delete", this.handleReceiveRuleDelete);

            addObserver(RuleModel.NAME, "_.reply.arrived:ogm/permission/Rule/Get", this.handleReceiveRuleGet);

            addObserver(RuleModel.NAME, "_.reply.arrived:ogm/permission/Rule/List", this.handleReceiveRuleList);

            addObserver(RuleModel.NAME, "_.reply.arrived:ogm/permission/Rule/Search", this.handleReceiveRuleSearch);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IRuleUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.permission.Rule"] = rootPanel;
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

        private void handleReceiveRuleAdd(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Rule/Add is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveAdd(json);
        }

        private void handleReceiveRuleUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Rule/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveRuleDelete(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Rule/Delete is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveDelete(json);
        }

        private void handleReceiveRuleGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.RuleGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Rule/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveRuleList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.RuleListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Rule/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveRuleSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.RuleListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Rule/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

    }
}
