
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class ScopeBaseViewBridge : IScopeViewBridge
    {
        public ScopeView view{ get; set; }
        public ScopeService service{ get; set; }


            public void OnCreateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ScopeCreateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostCreate(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ScopeUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnDeleteSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ScopeDeleteRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostDelete(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ScopeGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ScopeListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ScopeSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }



    }
}
