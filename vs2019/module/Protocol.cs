
using System;
using System.Text;

namespace OGM.Module.File.Proto
{

        public class BucketMakeRequest
        {
            public string name {get;set;}
            public long capacity {get;set;}
            public int engine {get;set;}
            public string address {get;set;}
            public string scope {get;set;}
            public string accessKey {get;set;}
            public string accessSecret {get;set;}

        }
    
        public class BucketListRequest
        {
            public long offset {get;set;}
            public long count {get;set;}

        }
    
        public class BucketListResponse
        {
            public Status status {get;set;}
            public long total {get;set;}
            public BucketEntity[] entity {get;set;}

        }
    
        public class BucketRemoveRequest
        {
            public string uuid {get;set;}

        }
    
        public class BucketGetRequest
        {
            public string uuid {get;set;}

        }
    
        public class BucketGetResponse
        {
            public Status status {get;set;}
            public BucketEntity entity {get;set;}

        }
    
        public class BucketFindRequest
        {
            public string name {get;set;}

        }
    
        public class BucketFindResponse
        {
            public Status status {get;set;}
            public BucketEntity entity {get;set;}

        }
    
        public class BucketUpdateEngineRequest
        {
            public string uuid {get;set;}
            public int engine {get;set;}
            public string address {get;set;}
            public string scope {get;set;}
            public string accessKey {get;set;}
            public string accessSecret {get;set;}

        }
    
        public class BucketUpdateCapacityRequest
        {
            public string uuid {get;set;}
            public long capacity {get;set;}

        }
    
        public class BucketResetTokenRequest
        {
            public string uuid {get;set;}

        }
    
        public class ObjectPrepareRequest
        {
            public string bucket {get;set;}
            public string uname {get;set;}
            public long size {get;set;}

        }
    
        public class ObjectPrepareResponse
        {
            public Status status {get;set;}
            public int engine {get;set;}
            public string address {get;set;}
            public string accessToken {get;set;}

        }
    
        public class ObjectFlushRequest
        {
            public string bucket {get;set;}
            public string uname {get;set;}
            public string path {get;set;}

        }
    
        public class ObjectPublishRequest
        {
            public string uuid {get;set;}
            public long expiry {get;set;}

        }
    
        public class ObjectPublishResponse
        {
            public Status status {get;set;}
            public string url {get;set;}

        }
    
        public class ObjectPreviewRequest
        {
            public string uuid {get;set;}

        }
    
        public class ObjectPreviewResponse
        {
            public Status status {get;set;}
            public string url {get;set;}

        }
    
        public class ObjectRetractRequest
        {
            public string uuid {get;set;}

        }
    
        public class ObjectUploadRequest
        {
            public string bucket {get;set;}
            public string filepath {get;set;}
            public byte[] data {get;set;}
            public bool overwrite {get;set;}

        }
    
        public class ObjectDownloadRequest
        {
            public string bucket {get;set;}
            public string filepath {get;set;}

        }
    
        public class ObjectDownloadResponse
        {
            public Status status {get;set;}
            public byte[] data {get;set;}

        }
    
        public class ObjectLinkRequest
        {
            public string bucket {get;set;}
            public string filepath {get;set;}
            public string url {get;set;}
            public bool overwrite {get;set;}

        }
    
        public class ObjectGetRequest
        {
            public string uuid {get;set;}

        }
    
        public class ObjectGetResponse
        {
            public Status status {get;set;}
            public ObjectEntity entity {get;set;}

        }
    
        public class ObjectFindRequest
        {
            public string bucket {get;set;}
            public string filepath {get;set;}

        }
    
        public class ObjectFindResponse
        {
            public Status status {get;set;}
            public ObjectEntity entity {get;set;}

        }
    
        public class ObjectRemoveRequest
        {
            public string uuid {get;set;}

        }
    
        public class ObjectListRequest
        {
            public long offset {get;set;}
            public long count {get;set;}
            public string bucket {get;set;}

        }
    
        public class ObjectListResponse
        {
            public Status status {get;set;}
            public long total {get;set;}
            public ObjectEntity[] entity {get;set;}

        }
    
        public class ObjectSearchRequest
        {
            public long offset {get;set;}
            public long count {get;set;}
            public string bucket {get;set;}
            public string prefix {get;set;}

        }
    
        public class ObjectSearchResponse
        {
            public Status status {get;set;}
            public long total {get;set;}
            public ObjectEntity[] entity {get;set;}

        }
    
        public class Status
        {
            public int code {get;set;}
            public string message {get;set;}

        }
    
        public class BlankRequest
        {

        }
    
        public class BlankResponse
        {
            public Status status {get;set;}

        }
    
        public class BucketEntity
        {
            public string uuid {get;set;}
            public string name {get;set;}
            public string token {get;set;}
            public long totalSize {get;set;}
            public long usedSize {get;set;}
            public int engine {get;set;}
            public string address {get;set;}
            public string scope {get;set;}
            public string accessKey {get;set;}
            public string accessSecret {get;set;}

        }
    
        public class ObjectEntity
        {
            public string uuid {get;set;}
            public string filepath {get;set;}
            public string url {get;set;}
            public long size {get;set;}
            public string md5 {get;set;}

        }
    
}
