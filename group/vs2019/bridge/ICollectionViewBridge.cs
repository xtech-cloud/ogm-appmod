
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.group
{
    public interface ICollectionViewBridge : View.Facade.Bridge
    {
        void OnMakeSubmit(string _json);
        void OnListSubmit(string _json);
        void OnRemoveSubmit(string _json);
        void OnGetSubmit(string _json);

    }
}
