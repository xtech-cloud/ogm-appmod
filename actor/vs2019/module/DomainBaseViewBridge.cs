
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainBaseViewBridge : IDomainViewBridge
    {
        public DomainView view{ get; set; }
        public DomainService service{ get; set; }


            public void OnCreateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DomainCreateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostCreate(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DomainUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnDeleteSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DomainDeleteRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostDelete(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DomainGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnFindSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DomainFindRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostFind(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DomainSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }


            public void OnExecuteSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DomainExecuteRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostExecute(req);
            }



    }
}
