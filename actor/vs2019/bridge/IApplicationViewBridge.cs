
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IApplicationViewBridge : View.Facade.Bridge
    {
        void OnAddSubmit(string _json);
        void OnRemoveSubmit(string _json);
        void OnListSubmit(string _json);

    }
}
