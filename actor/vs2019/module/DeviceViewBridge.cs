
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceViewBridge : IDeviceViewBridge
    {
        public DeviceView view{ get; set; }
        public DeviceService service{ get; set; }


        public void OnListSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ListRequest>(_json, options);
            service.PostList(req);
        }

        public void OnSearchSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.DeviceSearchRequest>(_json, options);
            service.PostSearch(req);
        }
    }
}
