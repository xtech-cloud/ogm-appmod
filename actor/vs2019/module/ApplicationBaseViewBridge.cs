
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationBaseViewBridge : IApplicationViewBridge
    {
        public ApplicationView view{ get; set; }
        public ApplicationService service{ get; set; }


            public void OnAddSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ApplicationAddRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostAdd(req);
            }


            public void OnRemoveSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ApplicationRemoveRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRemove(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ApplicationListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ApplicationGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ApplicationUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }



    }
}
