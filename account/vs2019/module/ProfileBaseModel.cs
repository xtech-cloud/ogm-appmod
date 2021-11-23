
using System;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileBaseModel : Model
    {

        public class ProfileBaseStatus : Model.Status
        {
            public const string NAME = "ogm.account.ProfileStatus";
        }

        protected ProfileController controller {get;set;}

        protected override void preSetup()
        {
            controller = findController(ProfileController.NAME) as ProfileController;
            Error err;
            status_ = spawnStatus<ProfileModel.ProfileStatus>(ProfileModel.ProfileStatus.NAME, out err);
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
            killStatus(ProfileModel.ProfileStatus.NAME, out err);
            if(0 != err.getCode())
            {
                getLogger().Error(err.getMessage());
            }
        }

        protected ProfileModel.ProfileStatus status
        {
            get
            {
                return status_ as ProfileModel.ProfileStatus;
            }
        }


        public virtual void SaveQuery(Proto.QueryProfileResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Profile/Query", _rsp);
        }


        public virtual void SaveUpdate(Proto.UpdateProfileResponse _rsp) 
        {
             this.Bubble("_.reply.arrived:ogm/account/Profile/Update", _rsp);
        }



    }
}
