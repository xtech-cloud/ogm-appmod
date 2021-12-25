
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.permission
{
    public interface IRuleViewBridge : View.Facade.Bridge
    {
        void OnAddSubmit(string _json);
        void OnUpdateSubmit(string _json);
        void OnDeleteSubmit(string _json);
        void OnGetSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);

    }
}
