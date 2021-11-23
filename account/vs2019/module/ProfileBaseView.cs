
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileBaseView: View
    {
        protected Facade facade = null;
        protected ProfileModel model = null;
        protected IProfileUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ProfileModel.NAME) as ProfileModel;
            var service = findService(ProfileService.NAME) as ProfileService;
            facade = findFacade("ogm.account.ProfileFacade");
            ProfileViewBridge vb = new ProfileViewBridge();
            vb.view = this as ProfileView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.ProfileView");

            addObserver(ProfileModel.NAME, "_.reply.arrived:ogm/account/Profile/Query", this.handleReceiveProfileQuery);

            addObserver(ProfileModel.NAME, "_.reply.arrived:ogm/account/Profile/Update", this.handleReceiveProfileUpdate);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IProfileUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.account.Profile"] = rootPanel;
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

        private void handleReceiveProfileQuery(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.QueryProfileResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Profile/Query is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveQuery(json);
        }

        private void handleReceiveProfileUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UpdateProfileResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Profile/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

    }
}
