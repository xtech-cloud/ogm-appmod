
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IObjectViewBridge : View.Facade.Bridge
    {
        void OnPrepareSubmit(string _json);
        void OnFlushSubmit(string _json);
        void OnLinkSubmit(string _json);
        void OnGetSubmit(string _json);
        void OnFindSubmit(string _json);
        void OnRemoveSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);
        void OnPublishSubmit(string _json);
        void OnPreviewSubmit(string _json);
        void OnRetractSubmit(string _json);

    }
}
