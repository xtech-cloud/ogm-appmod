
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.license
{
    public class KeyBaseViewBridge : IKeyViewBridge
    {
        public KeyView view{ get; set; }
        public KeyService service{ get; set; }


            public void OnGenerateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.KeyGenerateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGenerate(req);
            }


            public void OnActivateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.KeyActivateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostActivate(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.KeyUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.KeyGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.KeyListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.KeySearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }



    }
}
