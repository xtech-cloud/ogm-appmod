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
            req.engine= (Proto.Engine)_engine;
            req.address= _address;
            req.scope= _scope;
            req.accessKey= _accessKey;
            req.accessSecret= _accessSecret;
            service.PostBuckeMake(req);
        }

        public void OnListSubmit(long _offset, long _count)
        {
        }
    }
}
