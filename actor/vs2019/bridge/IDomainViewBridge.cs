
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDomainViewBridge : View.Facade.Bridge
    {
        void OnCreateSubmit(string _json);
        void OnUpdateSubmit(string _json);
        void OnDeleteSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);
        void OnFindSubmit(string _json);
        void OnExecuteSubmit(string _json);

        void OnOpenGuardUi();
        void OnOpenSyncUi();
    }
}
