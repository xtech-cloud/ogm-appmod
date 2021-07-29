
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthController: Controller
    {
        public const string NAME = "ogm.account.AuthController";

        private AuthView view {get;set;}

        protected override void preSetup()
        {
            view = findView(AuthView.NAME) as AuthView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.AuthController");
        }

        public void Signup(Model.Status _reply, AuthModel.Status _status, string _uuid)
        {
            if (_reply.getCode() != 0)
            {
                view.Alert(_reply.getMessage());
                return;
            }
            view.RefreshSignupSuccess(_uuid);
        }
    }
}
