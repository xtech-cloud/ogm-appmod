
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface ISyncViewBridge : View.Facade.Bridge
    {
        void OnPushSubmit(string _json);
        void OnPullSubmit(string _json);
        void OnUploadSubmit(string _json);

    }
}
