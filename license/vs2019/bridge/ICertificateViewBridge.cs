
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.license
{
    public interface ICertificateViewBridge : View.Facade.Bridge
    {
        void OnGetSubmit(string _json);
        void OnListSubmit(string _json);
        void OnSearchSubmit(string _json);

    }
}
