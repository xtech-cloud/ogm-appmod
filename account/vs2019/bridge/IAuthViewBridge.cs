
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IAuthViewBridge : View.Facade.Bridge
    {
        void OnSignupSubmit(string _json);
        void OnSigninSubmit(string _json);
        void OnSignoutSubmit(string _json);
        void OnChangePasswdSubmit(string _json);

    }
}
