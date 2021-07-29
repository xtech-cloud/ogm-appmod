
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileViewBridge : IProfileViewBridge
    {
        public ProfileView view{ get; set; }
        public ProfileService service{ get; set; }


        public void OnQuerySubmit(int _strategy, string _accessToken)
        {
            Proto.QueryProfileRequest req = new Proto.QueryProfileRequest();
            req._strategy = Any.FromInt32(_strategy);
            req._accessToken = Any.FromString(_accessToken);

            service.PostQuery(req);
        }
        

        public void OnUpdateSubmit(int _strategy, string _accessToken, string _profile)
        {
            Proto.UpdateProfileRequest req = new Proto.UpdateProfileRequest();
            req._strategy = Any.FromInt32(_strategy);
            req._accessToken = Any.FromString(_accessToken);
            req._profile = Any.FromString(_profile);

            service.PostUpdate(req);
        }
        


    }
}
