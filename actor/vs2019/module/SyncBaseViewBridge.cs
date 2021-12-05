
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncBaseViewBridge : ISyncViewBridge
    {
        public SyncView view{ get; set; }
        public SyncService service{ get; set; }


            public void OnPushSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SyncPushRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostPush(req);
            }


            public void OnPullSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SyncPullRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostPull(req);
            }


            public void OnUploadSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SyncUploadRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpload(req);
            }



    }
}
