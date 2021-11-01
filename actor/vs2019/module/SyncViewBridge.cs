
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncViewBridge : ISyncViewBridge
    {
        public SyncView view{ get; set; }
        public SyncService service{ get; set; }


        public void OnPushSubmit(string _domain, DeviceEntity _device, Dictionary<string, string> _upProperty, Dictionary<string, string> _downProperty)
        {
            Proto.SyncPushRequest req = new Proto.SyncPushRequest();
            req._domain = Any.FromString(_domain);
            req._upProperty = Any.FromStringMap(_upProperty);
            req._downProperty = Any.FromStringMap(_downProperty);

            service.PostPush(req);
        }
        

        public void OnPullSubmit(string _domain)
        {
            Proto.SyncPullRequest req = new Proto.SyncPullRequest();
            req._domain = Any.FromString(_domain);

            service.PostPull(req);
        }
        


    }
}
