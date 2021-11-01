
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncViewBridge : ISyncViewBridge
    {
        public SyncView view{ get; set; }
        public SyncService service{ get; set; }


        public void OnPushSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.SyncPushRequest>(_json, options);
            service.PostPush(req);
        }
        

        public void OnPullSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.SyncPullRequest>(_json, options);
            service.PostPull(req);
        }
        


    }
}
