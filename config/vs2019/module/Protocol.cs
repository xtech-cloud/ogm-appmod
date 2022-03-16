
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.config.Proto
{

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

            public class TextEntity
            {
                public TextEntity()
                {
                    _uuid = Any.FromString("");
                _path = Any.FromString("");
                _content = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("path")]
            public Any _path {get;set;}
            [JsonPropertyName("content")]
            public Any _content {get;set;}

            }

            public class ListRequest
            {
                public ListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}

            }

            public class GetRequest
            {
                public GetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class DeleteRequest
            {
                public DeleteRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class TextWriteRequest
            {
                public TextWriteRequest()
                {
                    _path = Any.FromString("");
                _content = Any.FromString("");

                }
                [JsonPropertyName("path")]
            public Any _path {get;set;}
            [JsonPropertyName("content")]
            public Any _content {get;set;}

            }

            public class TextReadRequest
            {
                public TextReadRequest()
                {
                    _path = Any.FromString("");

                }
                [JsonPropertyName("path")]
            public Any _path {get;set;}

            }

            public class TextReadResponse
            {
                public TextReadResponse()
                {
                    _status = new Status();
                _entity = new TextEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public TextEntity _entity {get;set;}

            }

            public class TextGetResponse
            {
                public TextGetResponse()
                {
                    _status = new Status();
                _entity = new TextEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public TextEntity _entity {get;set;}

            }

            public class TextListResponse
            {
                public TextListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new TextEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public TextEntity[] _entity {get;set;}

            }

            public class TextSearchRequest
            {
                public TextSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _path = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("path")]
            public Any _path {get;set;}

            }

            public class TextSearchResponse
            {
                public TextSearchResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new TextEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public TextEntity[] _entity {get;set;}

            }

}
