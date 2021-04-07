
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
            req.bucket = Proto.Field.FromString(_bucket);
            req.uname = Proto.Field.FromString(_uname);
            req.size = Proto.Field.FromLong(_size);

            service.PostPrepare(req);
        }
        

        public void OnFlushSubmit(string _bucket, string _uname, string _path)
        {
            Proto.ObjectFlushRequest req = new Proto.ObjectFlushRequest();
            req.bucket = Proto.Field.FromString(_bucket);
            req.uname = Proto.Field.FromString(_uname);
            req.path = Proto.Field.FromString(_path);

            service.PostFlush(req);
        }
        

        public void OnLinkSubmit(string _bucket, string _filepath, string _url, bool _overwrite)
        {
            Proto.ObjectLinkRequest req = new Proto.ObjectLinkRequest();
            req.bucket = Proto.Field.FromString(_bucket);
            req.filepath = Proto.Field.FromString(_filepath);
            req.url = Proto.Field.FromString(_url);
            req.overwrite = Proto.Field.FromBool(_overwrite);

            service.PostLink(req);
        }
        

        public void OnGetSubmit(string _uuid)
        {
            Proto.ObjectGetRequest req = new Proto.ObjectGetRequest();
            req.uuid = Proto.Field.FromString(_uuid);

            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _bucket, string _filepath)
        {
            Proto.ObjectFindRequest req = new Proto.ObjectFindRequest();
            req.bucket = Proto.Field.FromString(_bucket);
            req.filepath = Proto.Field.FromString(_filepath);

            service.PostFind(req);
        }
        

        public void OnRemoveSubmit(string _uuid)
        {
            Proto.ObjectRemoveRequest req = new Proto.ObjectRemoveRequest();
            req.uuid = Proto.Field.FromString(_uuid);

            service.PostRemove(req);
        }
        

        public void OnListSubmit(long _offset, long _count, string _bucket)
        {
            Proto.ObjectListRequest req = new Proto.ObjectListRequest();
            req.offset = Proto.Field.FromLong(_offset);
            req.count = Proto.Field.FromLong(_count);
            req.bucket = Proto.Field.FromString(_bucket);

            service.PostList(req);
        }
        

        public void OnSearchSubmit(long _offset, long _count, string _bucket, string _prefix)
        {
            Proto.ObjectSearchRequest req = new Proto.ObjectSearchRequest();
            req.offset = Proto.Field.FromLong(_offset);
            req.count = Proto.Field.FromLong(_count);
            req.bucket = Proto.Field.FromString(_bucket);
            req.prefix = Proto.Field.FromString(_prefix);

            service.PostSearch(req);
        }
        

        public void OnPublishSubmit(string _uuid, long _expiry)
        {
            Proto.ObjectPublishRequest req = new Proto.ObjectPublishRequest();
            req.uuid = Proto.Field.FromString(_uuid);
            req.expiry = Proto.Field.FromLong(_expiry);

            service.PostPublish(req);
        }
        

        public void OnPreviewSubmit(string _uuid)
        {
            Proto.ObjectPreviewRequest req = new Proto.ObjectPreviewRequest();
            req.uuid = Proto.Field.FromString(_uuid);

            service.PostPreview(req);
        }
        

        public void OnRetractSubmit(string _uuid)
        {
            Proto.ObjectRetractRequest req = new Proto.ObjectRetractRequest();
            req.uuid = Proto.Field.FromString(_uuid);

            service.PostRetract(req);
        }
        


    }
}
