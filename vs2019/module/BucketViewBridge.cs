
using XTC.oelMVCS;
namespace OGM.Module.File
{
    public class BucketViewBridge : IBucketViewBridge
    {
        public BucketView view{ get; set; }
        public BucketService service{ get; set; }


        public void OnMakeSubmit(string _name, long _capacity, int _engine, string _address, string _scope, string _accessKey, string _accessSecret)
        {
            Proto.BucketMakeRequest req = new Proto.BucketMakeRequest();
            req.name = Proto.Field.FromString(_name);
            req.capacity = Proto.Field.FromLong(_capacity);
            req.engine = Proto.Field.FromInt(_engine);
            req.address = Proto.Field.FromString(_address);
            req.scope = Proto.Field.FromString(_scope);
            req.accessKey = Proto.Field.FromString(_accessKey);
            req.accessSecret = Proto.Field.FromString(_accessSecret);

            service.PostMake(req);
        }
        

        public void OnListSubmit(long _offset, long _count)
        {
            Proto.BucketListRequest req = new Proto.BucketListRequest();
            req.offset = Proto.Field.FromLong(_offset);
            req.count = Proto.Field.FromLong(_count);

            service.PostList(req);
        }
        

        public void OnRemoveSubmit(string _uuid)
        {
            Proto.BucketRemoveRequest req = new Proto.BucketRemoveRequest();
            req.uuid = Proto.Field.FromString(_uuid);

            service.PostRemove(req);
        }
        

        public void OnGetSubmit(string _uuid)
        {
            Proto.BucketGetRequest req = new Proto.BucketGetRequest();
            req.uuid = Proto.Field.FromString(_uuid);

            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _name)
        {
            Proto.BucketFindRequest req = new Proto.BucketFindRequest();
            req.name = Proto.Field.FromString(_name);

            service.PostFind(req);
        }
        

        public void OnUpdateEngineSubmit(string _uuid, int _engine, string _address, string _scope, string _accessKey, string _accessSecret)
        {
            Proto.BucketUpdateEngineRequest req = new Proto.BucketUpdateEngineRequest();
            req.uuid = Proto.Field.FromString(_uuid);
            req.engine = Proto.Field.FromInt(_engine);
            req.address = Proto.Field.FromString(_address);
            req.scope = Proto.Field.FromString(_scope);
            req.accessKey = Proto.Field.FromString(_accessKey);
            req.accessSecret = Proto.Field.FromString(_accessSecret);

            service.PostUpdateEngine(req);
        }
        

        public void OnUpdateCapacitySubmit(string _uuid, long _capacity)
        {
            Proto.BucketUpdateCapacityRequest req = new Proto.BucketUpdateCapacityRequest();
            req.uuid = Proto.Field.FromString(_uuid);
            req.capacity = Proto.Field.FromLong(_capacity);

            service.PostUpdateCapacity(req);
        }
        

        public void OnResetTokenSubmit(string _uuid)
        {
            Proto.BucketResetTokenRequest req = new Proto.BucketResetTokenRequest();
            req.uuid = Proto.Field.FromString(_uuid);

            service.PostResetToken(req);
        }
        


    }
}
