
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface ISyncViewBridge : View.Facade.Bridge
    {
        void OnPushSubmit(string _domain, DeviceEntity _device, Dictionary<string,string> _upProperty, Dictionary<string,string> _downProperty);
        void OnPullSubmit(string _domain);

    }
}
