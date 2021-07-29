
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class AuthViewBridge : IAuthViewBridge
    {
        public AuthView view{ get; set; }
        public AuthService service{ get; set; }


        public void OnSignupSubmit(string _username, string _password)
        {
            if(string.IsNullOrEmpty(_username))
            {
                view.Alert("username is required");
                return;
            }
            if(string.IsNullOrEmpty(_password))
            {
                view.Alert("password is required");
                return;
            }

            Proto.SignupRequest req = new Proto.SignupRequest();
            req._username = Any.FromString(_username);
            req._password = Any.FromString(_password);

            service.PostSignup(req);
        }
        

        public void OnSigninSubmit(string _username, string _password, int _strategy)
        {
            Proto.SigninRequest req = new Proto.SigninRequest();
            req._username = Any.FromString(_username);
            req._password = Any.FromString(_password);
            req._strategy = Any.FromInt32(_strategy);

            service.PostSignin(req);
        }
        

        public void OnSignoutSubmit(string _accessToken, int _strategy)
        {
            Proto.SignoutRequest req = new Proto.SignoutRequest();
            req._accessToken = Any.FromString(_accessToken);
            req._strategy = Any.FromInt32(_strategy);

            service.PostSignout(req);
        }
        

        public void OnChangePasswdSubmit(string _accessToken, string _password, int _strategy)
        {
            Proto.ChangePasswdRequest req = new Proto.ChangePasswdRequest();
            req._accessToken = Any.FromString(_accessToken);
            req._password = Any.FromString(_password);
            req._strategy = Any.FromInt32(_strategy);

            service.PostChangePasswd(req);
        }
        


    }
}
