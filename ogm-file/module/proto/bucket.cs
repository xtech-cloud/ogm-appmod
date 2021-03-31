using System;
using System.Collections.Generic;
using System.Text;


namespace OGM.Module.File.Proto
{
    public class BucketMakeRequest
    {
        public string name;
        public long capacity;
        public Engine engine;
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
}
