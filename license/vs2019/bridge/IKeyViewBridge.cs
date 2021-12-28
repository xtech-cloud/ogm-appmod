
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.license
{
    public interface IKeyViewBridge : View.Facade.Bridge
    {
        void OnGenerateSubmit(string _json);
        void OnActivateSubmit(string _json);
        void OnUpdateSubmit(string _json);
        void OnGetSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);

    }
}
