
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.group
{
    public class CollectionBaseViewBridge : ICollectionViewBridge
    {
        public CollectionView view{ get; set; }
        public CollectionService service{ get; set; }


            public void OnMakeSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.CollectionMakeRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostMake(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.CollectionListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnRemoveSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.CollectionRemoveRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRemove(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.CollectionGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }



    }
}
