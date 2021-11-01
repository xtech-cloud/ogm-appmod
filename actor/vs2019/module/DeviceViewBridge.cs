
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceViewBridge : IDeviceViewBridge
    {
        public DeviceView view{ get; set; }
        public DeviceService service{ get; set; }


        public void OnListSubmit(long _offset, long _count)
        {
            Proto.ListRequest req = new Proto.ListRequest();
            req._offset = Any.FromInt64(_offset);
            req._count = Any.FromInt64(_count);

            service.PostList(req);
        }
        


    }
}
