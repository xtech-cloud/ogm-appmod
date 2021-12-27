
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.group
{
    public class ElementBaseViewBridge : IElementViewBridge
    {
        public ElementView view{ get; set; }
        public ElementService service{ get; set; }


            public void OnAddSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ElementAddRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostAdd(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ElementUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ElementListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ElementSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }


            public void OnRemoveSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ElementRemoveRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRemove(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ElementGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnWhereSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ElementWhereRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostWhere(req);
            }



    }
}
