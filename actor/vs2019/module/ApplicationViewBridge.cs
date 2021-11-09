
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationViewBridge : IApplicationViewBridge
    {
        public ApplicationView view{ get; set; }
        public ApplicationService service{ get; set; }


        public void OnAddSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ApplicationAddRequest>(_json, options);
            service.PostAdd(req);
        }
        

        public void OnRemoveSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ApplicationRemoveRequest>(_json, options);
            service.PostRemove(req);
        }
        

        public void OnListSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ApplicationListRequest>(_json, options);
            service.PostList(req);
        }
        

        public void OnUpdateSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ApplicationUpdateRequest>(_json, options);
            service.PostUpdate(req);
        }
        


    }
}
