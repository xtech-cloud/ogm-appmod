
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectViewBridge : IObjectViewBridge
    {
        public ObjectView view{ get; set; }
        public ObjectService service{ get; set; }


        public void OnPrepareSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectPrepareRequest>(_json, options);
            service.PostPrepare(req);
        }
        

        public void OnFlushSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectFlushRequest>(_json, options);
            service.PostFlush(req);
        }
        

        public void OnLinkSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectLinkRequest>(_json, options);
            service.PostLink(req);
        }
        

        public void OnGetSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectGetRequest>(_json, options);
            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectFindRequest>(_json, options);
            service.PostFind(req);
        }
        

        public void OnRemoveSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectRemoveRequest>(_json, options);
            service.PostRemove(req);
        }
        

        public void OnListSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectListRequest>(_json, options);
            service.PostList(req);
        }
        

        public void OnSearchSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectSearchRequest>(_json, options);
            service.PostSearch(req);
        }
        

        public void OnPublishSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectPublishRequest>(_json, options);
            service.PostPublish(req);
        }
        

        public void OnPreviewSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectPreviewRequest>(_json, options);
            service.PostPreview(req);
        }
        

        public void OnRetractSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.ObjectRetractRequest>(_json, options);
            service.PostRetract(req);
        }
        


    }
}
