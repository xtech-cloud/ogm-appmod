
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthBaseController: Controller
    {

        protected AuthView view {get;set;}

        protected override void preSetup()
        {
            view = findView(AuthView.NAME) as AuthView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.AuthController");
        }
    }
}
