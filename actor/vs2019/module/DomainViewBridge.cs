
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
        


    }
}
