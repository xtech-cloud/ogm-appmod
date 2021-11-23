
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthBaseViewBridge : IAuthViewBridge
    {
        public AuthView view{ get; set; }
        public AuthService service{ get; set; }


            public void OnSignupSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SignupRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSignup(req);
            }


            public void OnSigninSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SigninRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSignin(req);
            }


            public void OnSignoutSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SignoutRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSignout(req);
            }


            public void OnChangePasswdSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ChangePasswdRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostChangePasswd(req);
            }



    }
}
