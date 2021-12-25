
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.permission
{
    public interface IScopeViewBridge : View.Facade.Bridge
    {
        void OnCreateSubmit(string _json);
        void OnUpdateSubmit(string _json);
        void OnDeleteSubmit(string _json);
        void OnGetSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);

    }
}
