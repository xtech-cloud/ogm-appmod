
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDeviceViewBridge : View.Facade.Bridge
    {
        void OnListSubmit(long _offset, long _count);

    }
}
