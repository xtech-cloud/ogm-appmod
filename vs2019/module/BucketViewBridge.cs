
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
            req.name = _name;
            req.capacity = _capacity;
            req.engine = _engine;
            req.address = _address;
            req.scope = _scope;
            req.accessKey = _accessKey;
            req.accessSecret = _accessSecret;

            service.PostMake(req);
        }
        

        public void OnListSubmit(long _offset, long _count)
        {
            Proto.BucketListRequest req = new Proto.BucketListRequest();
            req.offset = _offset;
            req.count = _count;

            service.PostList(req);
        }
        

        public void OnRemoveSubmit(string _uuid)
        {
            Proto.BucketRemoveRequest req = new Proto.BucketRemoveRequest();
            req.uuid = _uuid;

            service.PostRemove(req);
        }
        

        public void OnGetSubmit(string _uuid)
        {
            Proto.BucketGetRequest req = new Proto.BucketGetRequest();
            req.uuid = _uuid;

            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _name)
        {
            Proto.BucketFindRequest req = new Proto.BucketFindRequest();
            req.name = _name;

            service.PostFind(req);
        }
        

        public void OnUpdateEngineSubmit(string _uuid, int _engine, string _address, string _scope, string _accessKey, string _accessSecret)
        {
            Proto.BucketUpdateEngineRequest req = new Proto.BucketUpdateEngineRequest();
            req.uuid = _uuid;
            req.engine = _engine;
            req.address = _address;
            req.scope = _scope;
            req.accessKey = _accessKey;
            req.accessSecret = _accessSecret;

            service.PostUpdateEngine(req);
        }
        

        public void OnUpdateCapacitySubmit(string _uuid, long _capacity)
        {
            Proto.BucketUpdateCapacityRequest req = new Proto.BucketUpdateCapacityRequest();
            req.uuid = _uuid;
            req.capacity = _capacity;

            service.PostUpdateCapacity(req);
        }
        

        public void OnResetTokenSubmit(string _uuid)
        {
            Proto.BucketResetTokenRequest req = new Proto.BucketResetTokenRequest();
            req.uuid = _uuid;

            service.PostResetToken(req);
        }
        


    }
}
