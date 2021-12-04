
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group
{
    public class MemberBaseView: View
    {
        protected Facade facade = null;
        protected MemberModel model = null;
        protected IMemberUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(MemberModel.NAME) as MemberModel;
            var service = findService(MemberService.NAME) as MemberService;
            facade = findFacade("ogm.group.MemberFacade");
            MemberViewBridge vb = new MemberViewBridge();
            vb.view = this as MemberView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.MemberView");

            addObserver(MemberModel.NAME, "_.reply.arrived:ogm/group/Member/Add", this.handleReceiveMemberAdd);

            addObserver(MemberModel.NAME, "_.reply.arrived:ogm/group/Member/Update", this.handleReceiveMemberUpdate);

            addObserver(MemberModel.NAME, "_.reply.arrived:ogm/group/Member/List", this.handleReceiveMemberList);

            addObserver(MemberModel.NAME, "_.reply.arrived:ogm/group/Member/Search", this.handleReceiveMemberSearch);

            addObserver(MemberModel.NAME, "_.reply.arrived:ogm/group/Member/Remove", this.handleReceiveMemberRemove);

            addObserver(MemberModel.NAME, "_.reply.arrived:ogm/group/Member/Get", this.handleReceiveMemberGet);

            addObserver(MemberModel.NAME, "_.reply.arrived:ogm/group/Member/Where", this.handleReceiveMemberWhere);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IMemberUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.group.Member"] = rootPanel;
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

        private void handleReceiveMemberAdd(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Member/Add is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveAdd(json);
        }

        private void handleReceiveMemberUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Member/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveMemberList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.MemberListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Member/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveMemberSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.MemberListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Member/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

        private void handleReceiveMemberRemove(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Member/Remove is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRemove(json);
        }

        private void handleReceiveMemberGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.MemberGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Member/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveMemberWhere(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.MemberWhereResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Member/Where is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveWhere(json);
        }

    }
}
