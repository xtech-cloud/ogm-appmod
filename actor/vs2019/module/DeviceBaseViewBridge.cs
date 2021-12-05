
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceBaseViewBridge : IDeviceViewBridge
    {
        public DeviceView view{ get; set; }
        public DeviceService service{ get; set; }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DeviceSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }



    }
}
