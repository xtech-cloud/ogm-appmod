
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthBaseModel : Model
    {

        public class AuthBaseStatus : Model.Status
        {
            public const string NAME = "ogm.account.AuthStatus";
        }

        protected AuthController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(AuthController.NAME) as AuthController;
            Error err;
            status_ = spawnStatus<AuthModel.AuthStatus>(AuthModel.AuthStatus.NAME, out err);
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
            killStatus(AuthModel.AuthStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected AuthModel.AuthStatus status
        {
            get
            {
                return status_ as AuthModel.AuthStatus;
            }
        }


        public virtual void SaveSignup(Proto.SignupResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Auth/Signup", _rsp);
        }


        public virtual void SaveSignin(Proto.SigninResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Auth/Signin", _rsp);
        }


        public virtual void SaveSignout(Proto.SignoutResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Auth/Signout", _rsp);
        }


        public virtual void SaveChangePasswd(Proto.ChangePasswdResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Auth/ChangePasswd", _rsp);
        }



    }
}
