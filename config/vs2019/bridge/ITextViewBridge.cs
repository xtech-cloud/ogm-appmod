
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.config
{
    public interface ITextViewBridge : View.Facade.Bridge
    {
        void OnWriteSubmit(string _json);
        void OnReadSubmit(string _json);
        void OnDeleteSubmit(string _json);
        void OnGetSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);

    }
}
