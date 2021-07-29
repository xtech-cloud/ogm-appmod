
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IAuthViewBridge : View.Facade.Bridge
    {
        void OnSignupSubmit(string _username, string _password);
        void OnSigninSubmit(string _username, string _password, int _strategy);
        void OnSignoutSubmit(string _accessToken, int _strategy);
        void OnChangePasswdSubmit(string _accessToken, string _password, int _strategy);

    }
}
