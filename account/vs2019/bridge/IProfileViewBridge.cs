
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IProfileViewBridge : View.Facade.Bridge
    {
        void OnQuerySubmit(string _json);
        void OnUpdateSubmit(string _json);

    }
}
