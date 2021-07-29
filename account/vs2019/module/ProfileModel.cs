
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileModel : Model
    {
        public const string NAME = "ogm.account.ProfileModel";

        public class ProfileStatus : Model.Status
        {
            public const string NAME = "ogm.account.ProfileStatus";
        }

        private ProfileController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(ProfileController.NAME) as ProfileController;
            Error err;
            status_ = spawnStatus<ProfileStatus>(ProfileStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
            else
            {
                getLogger().Trace("setup ogm.account.ProfileStatus");
            }
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.ProfileModel");
        }

        protected override void preDismantle()
        {
            Error err;
            killStatus(ProfileStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        private ProfileStatus status
        {
            get
            {
                return status_ as ProfileStatus;
            }
        }
    }
}
