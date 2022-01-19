
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketBaseViewBridge : IBucketViewBridge
    {
        public BucketView view{ get; set; }
        public BucketService service{ get; set; }


            public void OnMakeSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketMakeRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostMake(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnRemoveSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketRemoveRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRemove(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnFindSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketFindRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostFind(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnResetTokenSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketResetTokenRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostResetToken(req);
            }


            public void OnGenerateManifestSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketGenerateManifestRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGenerateManifest(req);
            }


            public void OnCleanSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.BucketCleanRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostClean(req);
            }



    }
}
