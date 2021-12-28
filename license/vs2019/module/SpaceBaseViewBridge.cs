
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.license
{
    public class SpaceBaseViewBridge : ISpaceViewBridge
    {
        public SpaceView view{ get; set; }
        public SpaceService service{ get; set; }


            public void OnCreateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SpaceCreateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostCreate(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SpaceUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SpaceGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SpaceListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.SpaceSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }



    }
}
