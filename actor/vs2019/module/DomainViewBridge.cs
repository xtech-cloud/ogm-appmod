
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainViewBridge : IDomainViewBridge
    {
        public DomainView view{ get; set; }
        public DomainService service{ get; set; }


        public void OnCreateSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.DomainCreateRequest>(_json, options);
            service.PostCreate(req);
        }

        public void OnUpdateSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.DomainUpdateRequest>(_json, options);
            service.PostUpdate(req);
        }
        
        

        public void OnDeleteSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.DomainDeleteRequest>(_json, options);
            service.PostDelete(req);
        }
        

        public void OnListSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ListRequest>(_json, options);
            service.PostList(req);
        }
        

        public void OnExecuteSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.DomainExecuteRequest>(_json, options);
            service.PostExecute(req);
        }
        
        public void OnSearchSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.DomainSearchRequest>(_json, options);
            service.PostSearch(req);
        }

        public void OnFindSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.DomainFindRequest>(_json, options);
            service.PostFind(req);
        }

        public void OnOpenGuardUi()
        {
            view.OpenGuardUi();
        }

        public void OnOpenSyncUi()
        {
            view.OpenSyncUi();
        }
    }
}
