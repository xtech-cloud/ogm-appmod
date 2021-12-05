
using System.Text.Json;
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

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/Create", this.handleReceiveDomainCreate);

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/Update", this.handleReceiveDomainUpdate);

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/Delete", this.handleReceiveDomainDelete);

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/List", this.handleReceiveDomainList);

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/Get", this.handleReceiveDomainGet);

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/Find", this.handleReceiveDomainFind);

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/Search", this.handleReceiveDomainSearch);

            addObserver(DomainModel.NAME, "_.reply.arrived:ogm/actor/Domain/Execute", this.handleReceiveDomainExecute);

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

        private void handleReceiveDomainCreate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/Create is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveCreate(json);
        }

        private void handleReceiveDomainUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveDomainDelete(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/Delete is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveDelete(json);
        }

        private void handleReceiveDomainList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.DomainListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveDomainGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.DomainGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveDomainFind(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.DomainFindResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/Find is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveFind(json);
        }

        private void handleReceiveDomainSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.DomainSearchResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

        private void handleReceiveDomainExecute(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BlankResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Domain/Execute is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveExecute(json);
        }

    }
}
