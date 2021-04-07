
using System;
using System.Text;
using XTC.oelMVCS;

namespace OGM.Module.File.Proto
{
    public class Field
    {
        public enum Tag
        {
            NULL = 0,
            StringValue = 1,
            IntValue = 2,
            LongValue = 3,
            FloatValue = 4,
            DoubleValue = 5,
            BoolValue = 6
        }

        private string value_ = "";
        private Tag tag_ = Tag.NULL;

        public Field()
        {
        }

        public static Field FromString(string _value)
        {
            Field any = new Field();
            any.tag_ = Tag.StringValue;
            any.value_ = _value;
            return any;
        }

        public static Field FromFloat(float _value)
        {
            Field any = new Field();
            any.tag_ = Tag.FloatValue;
            any.value_ = _value.ToString();
            return any;
        }

        public static Field FromDouble(double _value)
        {
            Field any = new Field();
            any.tag_ = Tag.DoubleValue;
            any.value_ = _value.ToString(); ;
            return any;
        }

        public static Field FromBool(bool _value)
        {
            Field any = new Field();
            any.tag_ = Tag.BoolValue;
            any.value_ = _value.ToString(); ;
            return any;
        }

        public static Field FromInt(int _value)
        {
            Field any = new Field();
            any.tag_ = Tag.IntValue;
            any.value_ = _value.ToString(); ;
            return any;
        }

        public static Field FromLong(long _value)
        {
            Field any = new Field();
            any.tag_ = Tag.LongValue;
            any.value_ = _value.ToString(); ;
            return any;
        }

        public bool IsNull()
        {
            return tag_ == Tag.NULL;
        }

        public bool IsString()
        {
            return tag_ == Tag.StringValue;
        }

        public bool IsInt()
        {
            return tag_ == Tag.IntValue;
        }

        public bool IsLong()
        {
            return tag_ == Tag.LongValue;
        }

        public bool IsFloat()
        {
            return tag_ == Tag.FloatValue;
        }

        public bool IsDouble()
        {
            return tag_ == Tag.DoubleValue;
        }

        public bool IsBool()
        {
            return tag_ == Tag.BoolValue;
        }

        public string AsString()
        {
            return value_;
        }


        public int AsInt()
        {
            int value = 0;
            int.TryParse(value_, out value);
            return value;
        }

        public long AsLong()
        {
            long value = 0;
            long.TryParse(value_, out value);
            return value;
        }

        public float AsFloat()
        {
            float value = 0;
            float.TryParse(value_, out value);
            return value;
        }

        public double AsDouble()
        {
            double value = 0;
            double.TryParse(value_, out value);
            return value;
        }

        public bool AsBool()
        {
            bool value = false;
            bool.TryParse(value_, out value);
            return value;
        }

        public Any AsAny()
        {
            if(IsString())
                return Any.FromString(AsString());
            if(IsInt())
                return Any.FromInt(AsInt());
            if(IsLong())
                return Any.FromLong(AsLong());
            if(IsFloat())
                return Any.FromFloat(AsFloat());
            if(IsDouble())
                return Any.FromDouble(AsDouble());
            if(IsBool())
                return Any.FromBool(AsBool());
            return new Any();
        }

    }//class

        public class BucketMakeRequest
        {
            public BucketMakeRequest()
            {
                name = new Field();
                capacity = new Field();
                engine = new Field();
                address = new Field();
                scope = new Field();
                accessKey = new Field();
                accessSecret = new Field();

            }
            public Field name {get;set;}
            public Field capacity {get;set;}
            public Field engine {get;set;}
            public Field address {get;set;}
            public Field scope {get;set;}
            public Field accessKey {get;set;}
            public Field accessSecret {get;set;}

        }
    
        public class BucketListRequest
        {
            public BucketListRequest()
            {
                offset = new Field();
                count = new Field();

            }
            public Field offset {get;set;}
            public Field count {get;set;}

        }
    
        public class BucketListResponse
        {
            public BucketListResponse()
            {
                status = new Status();
                total = new Field();
                entity = new BucketEntity[0];

            }
            public Status status {get;set;}
            public Field total {get;set;}
            public BucketEntity[] entity {get;set;}

        }
    
        public class BucketRemoveRequest
        {
            public BucketRemoveRequest()
            {
                uuid = new Field();

            }
            public Field uuid {get;set;}

        }
    
        public class BucketGetRequest
        {
            public BucketGetRequest()
            {
                uuid = new Field();

            }
            public Field uuid {get;set;}

        }
    
        public class BucketGetResponse
        {
            public BucketGetResponse()
            {
                status = new Status();
                entity = new BucketEntity();

            }
            public Status status {get;set;}
            public BucketEntity entity {get;set;}

        }
    
        public class BucketFindRequest
        {
            public BucketFindRequest()
            {
                name = new Field();

            }
            public Field name {get;set;}

        }
    
        public class BucketFindResponse
        {
            public BucketFindResponse()
            {
                status = new Status();
                entity = new BucketEntity();

            }
            public Status status {get;set;}
            public BucketEntity entity {get;set;}

        }
    
        public class BucketUpdateEngineRequest
        {
            public BucketUpdateEngineRequest()
            {
                uuid = new Field();
                engine = new Field();
                address = new Field();
                scope = new Field();
                accessKey = new Field();
                accessSecret = new Field();

            }
            public Field uuid {get;set;}
            public Field engine {get;set;}
            public Field address {get;set;}
            public Field scope {get;set;}
            public Field accessKey {get;set;}
            public Field accessSecret {get;set;}

        }
    
        public class BucketUpdateCapacityRequest
        {
            public BucketUpdateCapacityRequest()
            {
                uuid = new Field();
                capacity = new Field();

            }
            public Field uuid {get;set;}
            public Field capacity {get;set;}

        }
    
        public class BucketResetTokenRequest
        {
            public BucketResetTokenRequest()
            {
                uuid = new Field();

            }
            public Field uuid {get;set;}

        }
    
        public class ObjectPrepareRequest
        {
            public ObjectPrepareRequest()
            {
                bucket = new Field();
                uname = new Field();
                size = new Field();

            }
            public Field bucket {get;set;}
            public Field uname {get;set;}
            public Field size {get;set;}

        }
    
        public class ObjectPrepareResponse
        {
            public ObjectPrepareResponse()
            {
                status = new Status();
                engine = new Field();
                address = new Field();
                accessToken = new Field();

            }
            public Status status {get;set;}
            public Field engine {get;set;}
            public Field address {get;set;}
            public Field accessToken {get;set;}

        }
    
        public class ObjectFlushRequest
        {
            public ObjectFlushRequest()
            {
                bucket = new Field();
                uname = new Field();
                path = new Field();

            }
            public Field bucket {get;set;}
            public Field uname {get;set;}
            public Field path {get;set;}

        }
    
        public class ObjectPublishRequest
        {
            public ObjectPublishRequest()
            {
                uuid = new Field();
                expiry = new Field();

            }
            public Field uuid {get;set;}
            public Field expiry {get;set;}

        }
    
        public class ObjectPublishResponse
        {
            public ObjectPublishResponse()
            {
                status = new Status();
                url = new Field();

            }
            public Status status {get;set;}
            public Field url {get;set;}

        }
    
        public class ObjectPreviewRequest
        {
            public ObjectPreviewRequest()
            {
                uuid = new Field();

            }
            public Field uuid {get;set;}

        }
    
        public class ObjectPreviewResponse
        {
            public ObjectPreviewResponse()
            {
                status = new Status();
                url = new Field();

            }
            public Status status {get;set;}
            public Field url {get;set;}

        }
    
        public class ObjectRetractRequest
        {
            public ObjectRetractRequest()
            {
                uuid = new Field();

            }
            public Field uuid {get;set;}

        }
    
        public class ObjectUploadRequest
        {
            public ObjectUploadRequest()
            {
                bucket = new Field();
                filepath = new Field();
                data = new Field();
                overwrite = new Field();

            }
            public Field bucket {get;set;}
            public Field filepath {get;set;}
            public Field data {get;set;}
            public Field overwrite {get;set;}

        }
    
        public class ObjectDownloadRequest
        {
            public ObjectDownloadRequest()
            {
                bucket = new Field();
                filepath = new Field();

            }
            public Field bucket {get;set;}
            public Field filepath {get;set;}

        }
    
        public class ObjectDownloadResponse
        {
            public ObjectDownloadResponse()
            {
                status = new Status();
                data = new Field();

            }
            public Status status {get;set;}
            public Field data {get;set;}

        }
    
        public class ObjectLinkRequest
        {
            public ObjectLinkRequest()
            {
                bucket = new Field();
                filepath = new Field();
                url = new Field();
                overwrite = new Field();

            }
            public Field bucket {get;set;}
            public Field filepath {get;set;}
            public Field url {get;set;}
            public Field overwrite {get;set;}

        }
    
        public class ObjectGetRequest
        {
            public ObjectGetRequest()
            {
                uuid = new Field();

            }
            public Field uuid {get;set;}

        }
    
        public class ObjectGetResponse
        {
            public ObjectGetResponse()
            {
                status = new Status();
                entity = new ObjectEntity();

            }
            public Status status {get;set;}
            public ObjectEntity entity {get;set;}

        }
    
        public class ObjectFindRequest
        {
            public ObjectFindRequest()
            {
                bucket = new Field();
                filepath = new Field();

            }
            public Field bucket {get;set;}
            public Field filepath {get;set;}

        }
    
        public class ObjectFindResponse
        {
            public ObjectFindResponse()
            {
                status = new Status();
                entity = new ObjectEntity();

            }
            public Status status {get;set;}
            public ObjectEntity entity {get;set;}

        }
    
        public class ObjectRemoveRequest
        {
            public ObjectRemoveRequest()
            {
                uuid = new Field();

            }
            public Field uuid {get;set;}

        }
    
        public class ObjectListRequest
        {
            public ObjectListRequest()
            {
                offset = new Field();
                count = new Field();
                bucket = new Field();

            }
            public Field offset {get;set;}
            public Field count {get;set;}
            public Field bucket {get;set;}

        }
    
        public class ObjectListResponse
        {
            public ObjectListResponse()
            {
                status = new Status();
                total = new Field();
                entity = new ObjectEntity[0];

            }
            public Status status {get;set;}
            public Field total {get;set;}
            public ObjectEntity[] entity {get;set;}

        }
    
        public class ObjectSearchRequest
        {
            public ObjectSearchRequest()
            {
                offset = new Field();
                count = new Field();
                bucket = new Field();
                prefix = new Field();

            }
            public Field offset {get;set;}
            public Field count {get;set;}
            public Field bucket {get;set;}
            public Field prefix {get;set;}

        }
    
        public class ObjectSearchResponse
        {
            public ObjectSearchResponse()
            {
                status = new Status();
                total = new Field();
                entity = new ObjectEntity[0];

            }
            public Status status {get;set;}
            public Field total {get;set;}
            public ObjectEntity[] entity {get;set;}

        }
    
        public class Status
        {
            public Status()
            {
                code = new Field();
                message = new Field();

            }
            public Field code {get;set;}
            public Field message {get;set;}

        }
    
        public class BlankRequest
        {
            public BlankRequest()
            {

            }

        }
    
        public class BlankResponse
        {
            public BlankResponse()
            {
                status = new Status();

            }
            public Status status {get;set;}

        }
    
        public class BucketEntity
        {
            public BucketEntity()
            {
                uuid = new Field();
                name = new Field();
                token = new Field();
                totalSize = new Field();
                usedSize = new Field();
                engine = new Field();
                address = new Field();
                scope = new Field();
                accessKey = new Field();
                accessSecret = new Field();

            }
            public Field uuid {get;set;}
            public Field name {get;set;}
            public Field token {get;set;}
            public Field totalSize {get;set;}
            public Field usedSize {get;set;}
            public Field engine {get;set;}
            public Field address {get;set;}
            public Field scope {get;set;}
            public Field accessKey {get;set;}
            public Field accessSecret {get;set;}

        }
    
        public class ObjectEntity
        {
            public ObjectEntity()
            {
                uuid = new Field();
                filepath = new Field();
                url = new Field();
                size = new Field();
                md5 = new Field();

            }
            public Field uuid {get;set;}
            public Field filepath {get;set;}
            public Field url {get;set;}
            public Field size {get;set;}
            public Field md5 {get;set;}

        }
    
}
