
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketViewBridge : IBucketViewBridge
    {
        public BucketView view{ get; set; }
        public BucketService service{ get; set; }


        public void OnMakeSubmit(string _name, ulong _capacity, int _engine, string _address, string _scope, string _accessKey, string _accessSecret)
        {
            Proto.BucketMakeRequest req = new Proto.BucketMakeRequest();
            req._name = Any.FromString(_name);
            req._capacity = Any.FromInt64((long)_capacity);
            req._engine = Any.FromInt32(_engine);
            req._address = Any.FromString(_address);
            req._scope = Any.FromString(_scope);
            req._accessKey = Any.FromString(_accessKey);
            req._accessSecret = Any.FromString(_accessSecret);

            service.PostMake(req);
        }
        

        public void OnListSubmit(long _offset, long _count)
        {
            Proto.BucketListRequest req = new Proto.BucketListRequest();
            req._offset = Any.FromInt64(_offset);
            req._count = Any.FromInt64(_count);

            service.PostList(req);
        }
        

        public void OnRemoveSubmit(string _uuid)
        {
            Proto.BucketRemoveRequest req = new Proto.BucketRemoveRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostRemove(req);
        }
        

        public void OnGetSubmit(string _uuid)
        {
            Proto.BucketGetRequest req = new Proto.BucketGetRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _name)
        {
            Proto.BucketFindRequest req = new Proto.BucketFindRequest();
            req._name = Any.FromString(_name);

            service.PostFind(req);
        }
        

        public void OnUpdateEngineSubmit(string _uuid, int _engine, string _address, string _scope, string _accessKey, string _accessSecret)
        {
            Proto.BucketUpdateEngineRequest req = new Proto.BucketUpdateEngineRequest();
            req._uuid = Any.FromString(_uuid);
            req._engine = Any.FromInt32(_engine);
            req._address = Any.FromString(_address);
            req._scope = Any.FromString(_scope);
            req._accessKey = Any.FromString(_accessKey);
            req._accessSecret = Any.FromString(_accessSecret);

            service.PostUpdateEngine(req);
        }
        

        public void OnUpdateCapacitySubmit(string _uuid, ulong _capacity)
        {
            Proto.BucketUpdateCapacityRequest req = new Proto.BucketUpdateCapacityRequest();
            req._uuid = Any.FromString(_uuid);
            req._capacity = Any.FromInt64((long)_capacity);

            service.PostUpdateCapacity(req);
        }
        

        public void OnResetTokenSubmit(string _uuid)
        {
            Proto.BucketResetTokenRequest req = new Proto.BucketResetTokenRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostResetToken(req);
        }
        


    }
}
