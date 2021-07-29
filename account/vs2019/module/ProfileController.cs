
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileController: Controller
    {
        public const string NAME = "ogm.account.ProfileController";

        private ProfileView view {get;set;}

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
