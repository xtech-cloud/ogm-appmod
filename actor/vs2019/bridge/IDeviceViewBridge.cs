
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDeviceViewBridge : View.Facade.Bridge
    {
        void OnListSubmit(string _json);

    }
}
