
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthView : View
    {
        public const string NAME = "ogm.account.AuthView";

        private Facade facade = null;
        private AuthModel model = null;
        private IAuthUiBridge bridge = null;
        private AuthService service = null;

        protected override void preSetup()
        {
            model = findModel(AuthModel.NAME) as AuthModel;
            service = findService(AuthService.NAME) as AuthService;
            facade = findFacade("ogm.account.AuthFacade");
            AuthViewBridge vb = new AuthViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.AuthView");

            addRouter("/Application/Auth/Signin/Success", handleAuthSigninSuccess);
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IAuthUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.account.Auth"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }
       
        private void handleAuthSignup(Model.Status _status, object _data)
        {
            var rsp = (Proto.SignupResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleAuthSignin(Model.Status _status, object _data)
        {
            var rsp = (Proto.SigninResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleAuthSignout(Model.Status _status, object _data)
        {
            var rsp = (Proto.SignoutResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleAuthChangePasswd(Model.Status _status, object _data)
        {
            var rsp = (Proto.ChangePasswdResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleAuthSigninSuccess(Model.Status _status, object _data)
        {
            Dictionary<string, Any> data = (Dictionary<string, Any>)_data;
            if (data["location"].AsString().Equals("public"))
            {
                service.domain = data["host"].AsString();
                service.accessToken = data["accessToken"].AsString();
                service.uuid = data["uuid"].AsString();
                //bridge.RefreshActivateLocation(data["location"].AsString());
            }
        }

        public void RefreshSignupSuccess(string _uuid)
        {
            bridge.RefreshSignupSuccess(_uuid);
        }
    }
}
