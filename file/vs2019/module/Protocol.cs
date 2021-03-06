
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file.Proto
{

            public class BucketMakeRequest
            {
                public BucketMakeRequest()
                {
                    _name = Any.FromString("");
                _capacity = Any.FromInt64(0);
                _engine = Any.FromInt32(0);
                _address = Any.FromString("");
                _scope = Any.FromString("");
                _accessKey = Any.FromString("");
                _accessSecret = Any.FromString("");
                _url = Any.FromString("");
                _mode = Any.FromString("");
                _alias = Any.FromString("");

                }
                [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}
            [JsonPropertyName("engine")]
            public Any _engine {get;set;}
            [JsonPropertyName("address")]
            public Any _address {get;set;}
            [JsonPropertyName("scope")]
            public Any _scope {get;set;}
            [JsonPropertyName("accessKey")]
            public Any _accessKey {get;set;}
            [JsonPropertyName("accessSecret")]
            public Any _accessSecret {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("mode")]
            public Any _mode {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}

            }

            public class BucketListRequest
            {
                public BucketListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}

            }

            public class BucketListResponse
            {
                public BucketListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new BucketEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public BucketEntity[] _entity {get;set;}

            }

            public class BucketRemoveRequest
            {
                public BucketRemoveRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class BucketGetRequest
            {
                public BucketGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class BucketGetResponse
            {
                public BucketGetResponse()
                {
                    _status = new Status();
                _entity = new BucketEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public BucketEntity _entity {get;set;}

            }

            public class BucketFindRequest
            {
                public BucketFindRequest()
                {
                    _name = Any.FromString("");

                }
                [JsonPropertyName("name")]
            public Any _name {get;set;}

            }

            public class BucketFindResponse
            {
                public BucketFindResponse()
                {
                    _status = new Status();
                _entity = new BucketEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public BucketEntity _entity {get;set;}

            }

            public class BucketSearchRequest
            {
                public BucketSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _name = Any.FromString("");
                _alias = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}

            }

            public class BucketSearchResponse
            {
                public BucketSearchResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new BucketEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public BucketEntity[] _entity {get;set;}

            }

            public class BucketUpdateRequest
            {
                public BucketUpdateRequest()
                {
                    _uuid = Any.FromString("");
                _name = Any.FromString("");
                _capacity = Any.FromInt64(0);
                _engine = Any.FromInt32(0);
                _address = Any.FromString("");
                _scope = Any.FromString("");
                _accessKey = Any.FromString("");
                _accessSecret = Any.FromString("");
                _url = Any.FromString("");
                _alias = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}
            [JsonPropertyName("engine")]
            public Any _engine {get;set;}
            [JsonPropertyName("address")]
            public Any _address {get;set;}
            [JsonPropertyName("scope")]
            public Any _scope {get;set;}
            [JsonPropertyName("accessKey")]
            public Any _accessKey {get;set;}
            [JsonPropertyName("accessSecret")]
            public Any _accessSecret {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}

            }

            public class BucketResetTokenRequest
            {
                public BucketResetTokenRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class BucketGenerateManifestRequest
            {
                public BucketGenerateManifestRequest()
                {
                    _uuid = Any.FromString("");
                _field = Any.FromStringAry(new string[0]);
                _format = Any.FromString("");
                _template = Any.FromString("");
                _saveAs = Any.FromString("");
                _include = Any.FromStringAry(new string[0]);
                _exclude = Any.FromStringAry(new string[0]);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("field")]
            public Any _field {get;set;}
            [JsonPropertyName("format")]
            public Any _format {get;set;}
            [JsonPropertyName("template")]
            public Any _template {get;set;}
            [JsonPropertyName("saveAs")]
            public Any _saveAs {get;set;}
            [JsonPropertyName("include")]
            public Any _include {get;set;}
            [JsonPropertyName("exclude")]
            public Any _exclude {get;set;}

            }

            public class BucketGenerateManifestResponse
            {
                public BucketGenerateManifestResponse()
                {
                    _status = new Status();
                _result = Any.FromString("");

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("result")]
            public Any _result {get;set;}

            }

            public class BucketCleanRequest
            {
                public BucketCleanRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ObjectPrepareRequest
            {
                public ObjectPrepareRequest()
                {
                    _bucket = Any.FromString("");
                _hash = Any.FromString("");
                _path = Any.FromString("");
                _size = Any.FromInt64(0);
                _expiry = Any.FromInt64(0);
                _override = Any.FromBool(false);

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("hash")]
            public Any _hash {get;set;}
            [JsonPropertyName("path")]
            public Any _path {get;set;}
            [JsonPropertyName("size")]
            public Any _size {get;set;}
            [JsonPropertyName("expiry")]
            public Any _expiry {get;set;}
            [JsonPropertyName("override")]
            public Any _override {get;set;}

            }

            public class ObjectPrepareResponse
            {
                public ObjectPrepareResponse()
                {
                    _status = new Status();
                _engine = Any.FromInt32(0);
                _url = Any.FromString("");
                _accessToken = Any.FromString("");

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("engine")]
            public Any _engine {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("accessToken")]
            public Any _accessToken {get;set;}

            }

            public class ObjectFlushRequest
            {
                public ObjectFlushRequest()
                {
                    _bucket = Any.FromString("");
                _hash = Any.FromString("");
                _path = Any.FromString("");

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("hash")]
            public Any _hash {get;set;}
            [JsonPropertyName("path")]
            public Any _path {get;set;}

            }

            public class ObjectPublishRequest
            {
                public ObjectPublishRequest()
                {
                    _uuid = Any.FromString("");
                _expiry = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("expiry")]
            public Any _expiry {get;set;}

            }

            public class ObjectPublishResponse
            {
                public ObjectPublishResponse()
                {
                    _status = new Status();
                _url = Any.FromString("");

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}

            }

            public class ObjectPreviewRequest
            {
                public ObjectPreviewRequest()
                {
                    _uuid = Any.FromString("");
                _expiry = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("expiry")]
            public Any _expiry {get;set;}

            }

            public class ObjectPreviewResponse
            {
                public ObjectPreviewResponse()
                {
                    _status = new Status();
                _url = Any.FromString("");

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}

            }

            public class ObjectRetractRequest
            {
                public ObjectRetractRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ObjectUploadRequest
            {
                public ObjectUploadRequest()
                {
                    _bucket = Any.FromString("");
                _filepath = Any.FromString("");
                _data = Any.FromBytes(new byte[0]);
                _overwrite = Any.FromBool(false);

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("filepath")]
            public Any _filepath {get;set;}
            [JsonPropertyName("data")]
            public Any _data {get;set;}
            [JsonPropertyName("overwrite")]
            public Any _overwrite {get;set;}

            }

            public class ObjectDownloadRequest
            {
                public ObjectDownloadRequest()
                {
                    _bucket = Any.FromString("");
                _filepath = Any.FromString("");

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("filepath")]
            public Any _filepath {get;set;}

            }

            public class ObjectDownloadResponse
            {
                public ObjectDownloadResponse()
                {
                    _status = new Status();
                _data = Any.FromBytes(new byte[0]);

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("data")]
            public Any _data {get;set;}

            }

            public class ObjectLinkRequest
            {
                public ObjectLinkRequest()
                {
                    _bucket = Any.FromString("");
                _filepath = Any.FromString("");
                _url = Any.FromString("");
                _overwrite = Any.FromBool(false);

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("filepath")]
            public Any _filepath {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("overwrite")]
            public Any _overwrite {get;set;}

            }

            public class ObjectGetRequest
            {
                public ObjectGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ObjectGetResponse
            {
                public ObjectGetResponse()
                {
                    _status = new Status();
                _entity = new ObjectEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public ObjectEntity _entity {get;set;}

            }

            public class ObjectFindRequest
            {
                public ObjectFindRequest()
                {
                    _bucket = Any.FromString("");
                _path = Any.FromString("");

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("path")]
            public Any _path {get;set;}

            }

            public class ObjectFindResponse
            {
                public ObjectFindResponse()
                {
                    _status = new Status();
                _entity = new ObjectEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public ObjectEntity _entity {get;set;}

            }

            public class ObjectRemoveRequest
            {
                public ObjectRemoveRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ObjectListRequest
            {
                public ObjectListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _bucket = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}

            }

            public class ObjectListResponse
            {
                public ObjectListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new ObjectEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public ObjectEntity[] _entity {get;set;}

            }

            public class ObjectSearchRequest
            {
                public ObjectSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _bucket = Any.FromString("");
                _prefix = Any.FromString("");
                _name = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("prefix")]
            public Any _prefix {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

            }

            public class ObjectSearchResponse
            {
                public ObjectSearchResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new ObjectEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public ObjectEntity[] _entity {get;set;}

            }

            public class ObjectConvertFromBase64Request
            {
                public ObjectConvertFromBase64Request()
                {
                    _bucket = Any.FromString("");
                _source = new Base64Source[0];

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("source")]
            public Base64Source[] _source {get;set;}

            }

            public class ObjectConvertFromBase64Response
            {
                public ObjectConvertFromBase64Response()
                {
                    _status = new Status();
                _failure = Any.FromStringAry(new string[0]);

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("failure")]
            public Any _failure {get;set;}

            }

            public class ObjectConvertFromUrlRequest
            {
                public ObjectConvertFromUrlRequest()
                {
                    _bucket = Any.FromString("");
                _source = new UrlSource[0];

                }
                [JsonPropertyName("bucket")]
            public Any _bucket {get;set;}
            [JsonPropertyName("source")]
            public UrlSource[] _source {get;set;}

            }

            public class ObjectConvertFromUrlResponse
            {
                public ObjectConvertFromUrlResponse()
                {
                    _status = new Status();
                _failure = Any.FromStringAry(new string[0]);

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("failure")]
            public Any _failure {get;set;}

            }

            public class Status
            {
                public Status()
                {
                    _code = Any.FromInt32(0);
                _message = Any.FromString("");

                }
                [JsonPropertyName("code")]
            public Any _code {get;set;}
            [JsonPropertyName("message")]
            public Any _message {get;set;}

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
                    _status = new Status();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}

            }

            public class UuidResponse
            {
                public UuidResponse()
                {
                    _status = new Status();
                _uuid = Any.FromString("");

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class BucketEntity
            {
                public BucketEntity()
                {
                    _uuid = Any.FromString("");
                _name = Any.FromString("");
                _token = Any.FromString("");
                _totalSize = Any.FromInt64(0);
                _usedSize = Any.FromInt64(0);
                _engine = Any.FromInt32(0);
                _address = Any.FromString("");
                _scope = Any.FromString("");
                _accessKey = Any.FromString("");
                _accessSecret = Any.FromString("");
                _url = Any.FromString("");
                _mode = Any.FromString("");
                _alias = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("token")]
            public Any _token {get;set;}
            [JsonPropertyName("totalSize")]
            public Any _totalSize {get;set;}
            [JsonPropertyName("usedSize")]
            public Any _usedSize {get;set;}
            [JsonPropertyName("engine")]
            public Any _engine {get;set;}
            [JsonPropertyName("address")]
            public Any _address {get;set;}
            [JsonPropertyName("scope")]
            public Any _scope {get;set;}
            [JsonPropertyName("accessKey")]
            public Any _accessKey {get;set;}
            [JsonPropertyName("accessSecret")]
            public Any _accessSecret {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("mode")]
            public Any _mode {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}

            }

            public class ObjectEntity
            {
                public ObjectEntity()
                {
                    _uuid = Any.FromString("");
                _path = Any.FromString("");
                _hash = Any.FromString("");
                _url = Any.FromString("");
                _size = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("path")]
            public Any _path {get;set;}
            [JsonPropertyName("hash")]
            public Any _hash {get;set;}
            [JsonPropertyName("url")]
            public Any _url {get;set;}
            [JsonPropertyName("size")]
            public Any _size {get;set;}

            }

            public class Base64Source
            {
                public Base64Source()
                {
                    _path = Any.FromString("");
                _hash = Any.FromString("");
                _size = Any.FromInt64(0);
                _content = Any.FromString("");

                }
                [JsonPropertyName("path")]
            public Any _path {get;set;}
            [JsonPropertyName("hash")]
            public Any _hash {get;set;}
            [JsonPropertyName("size")]
            public Any _size {get;set;}
            [JsonPropertyName("content")]
            public Any _content {get;set;}

            }

            public class UrlSource
            {
                public UrlSource()
                {
                    _path = Any.FromString("");
                _hash = Any.FromString("");
                _size = Any.FromInt64(0);
                _content = Any.FromString("");

                }
                [JsonPropertyName("path")]
            public Any _path {get;set;}
            [JsonPropertyName("hash")]
            public Any _hash {get;set;}
            [JsonPropertyName("size")]
            public Any _size {get;set;}
            [JsonPropertyName("content")]
            public Any _content {get;set;}

            }

}
