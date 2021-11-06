
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IBucketViewBridge : View.Facade.Bridge
    {
        void OnMakeSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);
        void OnRemoveSubmit(string _json);
        void OnGetSubmit(string _json);
        void OnFindSubmit(string _json);
        void OnUpdateSubmit(string _json);

        void OnResetTokenSubmit(string _json);

        void OnOpenBucketUi();

    }
}
