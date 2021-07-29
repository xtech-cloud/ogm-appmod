
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthModel : Model
    {
        public const string NAME = "ogm.account.AuthModel";

        public class ActiveAccount
        {
            public string uuid = "";
            public string accessToken = "";
        }
        public class AuthStatus : Model.Status
        {
            public const string NAME = "ogm.account.AuthStatus";
            public ActiveAccount activeAccount = null;
        }

        private AuthController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(AuthController.NAME) as AuthController;
            Error err;
            status_ = spawnStatus<AuthStatus>(AuthStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.account.AuthStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.AuthModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(AuthStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        private AuthStatus status
        {
            get
            {
                return status_ as AuthStatus;
            }
        }

        public void UpdateSignup(Model.Status _reply, string _uuid)
        {
            controller.Signup(_reply, status, _uuid);
        }
    }
}
