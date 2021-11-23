
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileBaseController: Controller
    {

        protected ProfileView view {get;set;}

        protected override void preSetup()
        {
            view = findView(ProfileView.NAME) as ProfileView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.ProfileController");
        }
    }
}
