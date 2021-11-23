
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileBaseViewBridge : IProfileViewBridge
    {
        public ProfileView view{ get; set; }
        public ProfileService service{ get; set; }


            public void OnQuerySubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.QueryProfileRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostQuery(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.UpdateProfileRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }



    }
}
