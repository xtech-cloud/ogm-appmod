
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectViewBridge : IObjectViewBridge
    {
        public ObjectView view{ get; set; }
        public ObjectService service{ get; set; }


        public void OnPrepareSubmit(string _bucket, string _uname, ulong _size)
        {
            Proto.ObjectPrepareRequest req = new Proto.ObjectPrepareRequest();
            req._bucket = Any.FromString(_bucket);
            req._uname = Any.FromString(_uname);
            req._size = Any.FromInt64((long)_size);

            service.PostPrepare(req);
        }
        

        public void OnFlushSubmit(string _bucket, string _uname, string _path)
        {
            Proto.ObjectFlushRequest req = new Proto.ObjectFlushRequest();
            req._bucket = Any.FromString(_bucket);
            req._uname = Any.FromString(_uname);
            req._path = Any.FromString(_path);

            service.PostFlush(req);
        }
        

        public void OnLinkSubmit(string _bucket, string _filepath, string _url, bool _overwrite)
        {
            Proto.ObjectLinkRequest req = new Proto.ObjectLinkRequest();
            req._bucket = Any.FromString(_bucket);
            req._filepath = Any.FromString(_filepath);
            req._url = Any.FromString(_url);
            req._overwrite = Any.FromBool(_overwrite);

            service.PostLink(req);
        }
        

        public void OnGetSubmit(string _uuid)
        {
            Proto.ObjectGetRequest req = new Proto.ObjectGetRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostGet(req);
        }
        

        public void OnFindSubmit(string _bucket, string _filepath)
        {
            Proto.ObjectFindRequest req = new Proto.ObjectFindRequest();
            req._bucket = Any.FromString(_bucket);
            req._filepath = Any.FromString(_filepath);

            service.PostFind(req);
        }
        

        public void OnRemoveSubmit(string _uuid)
        {
            Proto.ObjectRemoveRequest req = new Proto.ObjectRemoveRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostRemove(req);
        }
        

        public void OnListSubmit(long _offset, long _count, string _bucket)
        {
            Proto.ObjectListRequest req = new Proto.ObjectListRequest();
            req._offset = Any.FromInt64(_offset);
            req._count = Any.FromInt64(_count);
            req._bucket = Any.FromString(_bucket);

            service.PostList(req);
        }
        

        public void OnSearchSubmit(long _offset, long _count, string _bucket, string _prefix)
        {
            Proto.ObjectSearchRequest req = new Proto.ObjectSearchRequest();
            req._offset = Any.FromInt64(_offset);
            req._count = Any.FromInt64(_count);
            req._bucket = Any.FromString(_bucket);
            req._prefix = Any.FromString(_prefix);

            service.PostSearch(req);
        }
        

        public void OnPublishSubmit(string _uuid, ulong _expiry)
        {
            Proto.ObjectPublishRequest req = new Proto.ObjectPublishRequest();
            req._uuid = Any.FromString(_uuid);
            req._expiry = Any.FromInt64((long)_expiry);

            service.PostPublish(req);
        }
        

        public void OnPreviewSubmit(string _uuid)
        {
            Proto.ObjectPreviewRequest req = new Proto.ObjectPreviewRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostPreview(req);
        }
        

        public void OnRetractSubmit(string _uuid)
        {
            Proto.ObjectRetractRequest req = new Proto.ObjectRetractRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostRetract(req);
        }
        


    }
}
