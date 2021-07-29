
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IProfileViewBridge : View.Facade.Bridge
    {
        void OnQuerySubmit(int _strategy, string _accessToken);
        void OnUpdateSubmit(int _strategy, string _accessToken, string _profile);

    }
}
