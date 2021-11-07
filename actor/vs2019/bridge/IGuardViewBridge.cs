
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IGuardViewBridge : View.Facade.Bridge
    {
        void OnFetchSubmit(string _json);
        void OnEditSubmit(string _json);
        void OnDeleteSubmit(string _json);

    }
}
