
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IAuthUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveSignup(string _json);
        void ReceiveSignin(string _json);
        void ReceiveSignout(string _json);
        void ReceiveChangePasswd(string _json);

    }
}
