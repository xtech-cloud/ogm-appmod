
using XTC.oelMVCS;
namespace OGM.Module.File
{
    public class ObjectViewBridge : IObjectViewBridge
    {
        public ObjectView view{ get; set; }
        public ObjectService service{ get; set; }


        public void OnPrepareSubmit(string _bucket, string _uname, long _size)
        {
            Proto.ObjectPrepareRequest req = new Proto.ObjectPrepareRequest();
            req.bucket = _bucket;
            req.uname = _uname;
            req.size = _size;

            service.PostPrepare(req);
        }
        

        public void OnFlushSubmit(string _bucket, string _uname, string _path)
        {
            Proto.ObjectFlushRequest req = new Proto.ObjectFlushRequest();
            req.bucket = _bucket;
            req.uname = _uname;
            req.path = _path;

            service.PostFlush(req);
        }
        

        public void OnLinkSubmit(string _bucket, string _filepath, string _url, bool _overwrite)
        {
            Proto.ObjectLinkRequest req = new Proto.ObjectLinkRequest();
            req.bucket = _bucket;
            req.filepath = _filepath;
            req.url = _url;
            req.overwrite = _overwrite;

            service.PostLink(req);
        }
        

        public void OnGetSubmit(string _uuid)
        {
            Proto.ObjectGetRequest req = new Proto.ObjectGetRequest();
            req.uuid = _uuid;

            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _bucket, string _filepath)
        {
            Proto.ObjectFindRequest req = new Proto.ObjectFindRequest();
            req.bucket = _bucket;
            req.filepath = _filepath;

            service.PostFind(req);
        }
        

        public void OnRemoveSubmit(string _uuid)
        {
            Proto.ObjectRemoveRequest req = new Proto.ObjectRemoveRequest();
            req.uuid = _uuid;

            service.PostRemove(req);
        }
        

        public void OnListSubmit(long _offset, long _count, string _bucket)
        {
            Proto.ObjectListRequest req = new Proto.ObjectListRequest();
            req.offset = _offset;
            req.count = _count;
            req.bucket = _bucket;

            service.PostList(req);
        }
        

        public void OnSearchSubmit(long _offset, long _count, string _bucket, string _prefix)
        {
            Proto.ObjectSearchRequest req = new Proto.ObjectSearchRequest();
            req.offset = _offset;
            req.count = _count;
            req.bucket = _bucket;
            req.prefix = _prefix;

            service.PostSearch(req);
        }
        

        public void OnPublishSubmit(string _uuid, long _expiry)
        {
            Proto.ObjectPublishRequest req = new Proto.ObjectPublishRequest();
            req.uuid = _uuid;
            req.expiry = _expiry;

            service.PostPublish(req);
        }
        

        public void OnPreviewSubmit(string _uuid)
        {
            Proto.ObjectPreviewRequest req = new Proto.ObjectPreviewRequest();
            req.uuid = _uuid;

            service.PostPreview(req);
        }
        

        public void OnRetractSubmit(string _uuid)
        {
            Proto.ObjectRetractRequest req = new Proto.ObjectRetractRequest();
            req.uuid = _uuid;

            service.PostRetract(req);
        }
        


    }
}
