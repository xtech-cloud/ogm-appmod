
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectBaseViewBridge : IObjectViewBridge
    {
        public ObjectView view{ get; set; }
        public ObjectService service{ get; set; }


            public void OnPrepareSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectPrepareRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostPrepare(req);
            }


            public void OnFlushSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectFlushRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostFlush(req);
            }


            public void OnLinkSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectLinkRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostLink(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnFindSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectFindRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostFind(req);
            }


            public void OnRemoveSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectRemoveRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRemove(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }


            public void OnPublishSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectPublishRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostPublish(req);
            }


            public void OnPreviewSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectPreviewRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostPreview(req);
            }


            public void OnRetractSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectRetractRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRetract(req);
            }


            public void OnConvertFromBase64Submit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectConvertFromBase64Request>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostConvertFromBase64(req);
            }


            public void OnConvertFromUrlSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ObjectConvertFromUrlRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostConvertFromUrl(req);
            }



    }
}
