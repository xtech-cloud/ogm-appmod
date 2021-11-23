
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.group
{
    public interface IMemberViewBridge : View.Facade.Bridge
    {
        void OnAddSubmit(string _json);
        void OnListSubmit(string _json);
        void OnRemoveSubmit(string _json);
        void OnGetSubmit(string _json);
        void OnWhereSubmit(string _json);

    }
}
