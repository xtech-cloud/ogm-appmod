
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketViewBridge : IBucketViewBridge
    {
        public BucketView view{ get; set; }
        public BucketService service{ get; set; }


        public void OnMakeSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketMakeRequest>(_json, options);
            service.PostMake(req);
        }
        

        public void OnListSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketListRequest>(_json, options);
            service.PostList(req);
        }
        

        public void OnRemoveSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketRemoveRequest>(_json, options);
            service.PostRemove(req);
        }
        

        public void OnGetSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketGetRequest>(_json, options);
            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketFindRequest>(_json, options);
            service.PostFind(req);
        }
        

        public void OnUpdateSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketUpdateRequest>(_json, options);
            service.PostUpdate(req);
        }
        

        public void OnResetTokenSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketResetTokenRequest>(_json, options);
            service.PostResetToken(req);
        }

        public void OnOpenBucketUi()
        {
            view.OpenBucketUi();
        }

        public void OnSearchSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.BucketSearchRequest>(_json, options);
            service.PostSearch(req);
        }
    }
}
