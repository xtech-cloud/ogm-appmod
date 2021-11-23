
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthBaseView: View
    {
        protected Facade facade = null;
        protected AuthModel model = null;
        protected IAuthUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(AuthModel.NAME) as AuthModel;
            var service = findService(AuthService.NAME) as AuthService;
            facade = findFacade("ogm.account.AuthFacade");
            AuthViewBridge vb = new AuthViewBridge();
            vb.view = this as AuthView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.AuthView");

            addObserver(AuthModel.NAME, "_.reply.arrived:ogm/account/Auth/Signup", this.handleReceiveAuthSignup);

            addObserver(AuthModel.NAME, "_.reply.arrived:ogm/account/Auth/Signin", this.handleReceiveAuthSignin);

            addObserver(AuthModel.NAME, "_.reply.arrived:ogm/account/Auth/Signout", this.handleReceiveAuthSignout);

            addObserver(AuthModel.NAME, "_.reply.arrived:ogm/account/Auth/ChangePasswd", this.handleReceiveAuthChangePasswd);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IAuthUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.account.Auth"] = rootPanel;
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

        private void handleReceiveAuthSignup(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SignupResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Auth/Signup is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSignup(json);
        }

        private void handleReceiveAuthSignin(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SigninResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Auth/Signin is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSignin(json);
        }

        private void handleReceiveAuthSignout(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.SignoutResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Auth/Signout is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSignout(json);
        }

        private void handleReceiveAuthChangePasswd(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ChangePasswdResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Auth/ChangePasswd is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveChangePasswd(json);
        }

    }
}
