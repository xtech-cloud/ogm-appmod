
using System;
using System.Text;

namespace OGM.Module.File.Proto
{

        public class BucketMakeRequest
        {
            public string name;
            public long capacity;
            public int engine;
            public string address;
            public string scope;
            public string accessKey;
            public string accessSecret;

        }
    
        public class BucketListRequest
        {
            public long offset;
            public long count;

        }
    
        public class BucketListResponse
        {
            public Status status;
            public long total;
            public BucketEntity[] entity;

        }
    
        public class BucketRemoveRequest
        {
            public string uuid;

        }
    
        public class BucketGetRequest
        {
            public string uuid;

        }
    
        public class BucketGetResponse
        {
            public Status status;
            public BucketEntity entity;

        }
    
        public class BucketFindRequest
        {
            public string name;

        }
    
        public class BucketFindResponse
        {
            public Status status;
            public BucketEntity entity;

        }
    
        public class BucketUpdateEngineRequest
        {
            public string uuid;
            public int engine;
            public string address;
            public string scope;
            public string accessKey;
            public string accessSecret;

        }
    
        public class BucketUpdateCapacityRequest
        {
            public string uuid;
            public long capacity;

        }
    
        public class BucketResetTokenRequest
        {
            public string uuid;

        }
    
        public class ObjectPrepareRequest
        {
            public string bucket;
            public string uname;
            public long size;

        }
    
        public class ObjectPrepareResponse
        {
            public Status status;
            public int engine;
            public string address;
            public string accessToken;

        }
    
        public class ObjectFlushRequest
        {
            public string bucket;
            public string uname;
            public string path;

        }
    
        public class ObjectPublishRequest
        {
            public string uuid;
            public long expiry;

        }
    
        public class ObjectPublishResponse
        {
            public Status status;
            public string url;

        }
    
        public class ObjectPreviewRequest
        {
            public string uuid;

        }
    
        public class ObjectPreviewResponse
        {
            public Status status;
            public string url;

        }
    
        public class ObjectRetractRequest
        {
            public string uuid;

        }
    
        public class ObjectUploadRequest
        {
            public string bucket;
            public string filepath;
            public byte[] data;
            public bool overwrite;

        }
    
        public class ObjectDownloadRequest
        {
            public string bucket;
            public string filepath;

        }
    
        public class ObjectDownloadResponse
        {
            public Status status;
            public byte[] data;

        }
    
        public class ObjectLinkRequest
        {
            public string bucket;
            public string filepath;
            public string url;
            public bool overwrite;

        }
    
        public class ObjectGetRequest
        {
            public string uuid;

        }
    
        public class ObjectGetResponse
        {
            public Status status;
            public ObjectEntity entity;

        }
    
        public class ObjectFindRequest
        {
            public string bucket;
            public string filepath;

        }
    
        public class ObjectFindResponse
        {
            public Status status;
            public ObjectEntity entity;

        }
    
        public class ObjectRemoveRequest
        {
            public string uuid;

        }
    
        public class ObjectListRequest
        {
            public long offset;
            public long count;
            public string bucket;

        }
    
        public class ObjectListResponse
        {
            public Status status;
            public long total;
            public ObjectEntity[] entity;

        }
    
        public class ObjectSearchRequest
        {
            public long offset;
            public long count;
            public string bucket;
            public string prefix;

        }
    
        public class ObjectSearchResponse
        {
            public Status status;
            public long total;
            public ObjectEntity[] entity;

        }
    
        public class Status
        {
            public int code;
            public string message;

        }
    
        public class BlankRequest
        {

        }
    
        public class BlankResponse
        {
            public Status status;

        }
    
        public class BucketEntity
        {
            public string uuid;
            public string name;
            public string token;
            public long totalSize;
            public long usedSize;
            public int engine;
            public string address;
            public string scope;
            public string accessKey;
            public string accessSecret;

        }
    
        public class ObjectEntity
        {
            public string uuid;
            public string filepath;
            public string url;
            public long size;
            public string md5;

        }
    
}
