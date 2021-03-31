using System;
using System.Collections.Generic;
using System.Text;


namespace OGM.Module.File.Proto
{
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

    public enum Engine
    {
        ENGINE_INVALID = 0,
        ENGINE_LOCAL = 1,
        ENGINE_MINIO = 2,
        ENGINE_QINIU = 3,
        ENGINE_CUSTOM = 100,
    }

    public class BucketEntity
    {
        public string uuid;
        public string name;
        public string tocken;
        public long totalSize;
        public long usedSize;
        public Engine engine;
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
