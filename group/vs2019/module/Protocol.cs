
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group.Proto
{

            public class CollectionMakeRequest
            {
                public CollectionMakeRequest()
                {
                    _name = Any.FromString("");
                _capacity = Any.FromInt64(0);

                }
                [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}

            }

            public class CollectionUpdateRequest
            {
                public CollectionUpdateRequest()
                {
                    _uuid = Any.FromString("");
                _name = Any.FromString("");
                _capacity = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}

            }

            public class CollectionListRequest
            {
                public CollectionListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}

            }

            public class CollectionSearchRequest
            {
                public CollectionSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _name = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

            }

            public class CollectionListResponse
            {
                public CollectionListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new CollectionEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public CollectionEntity[] _entity {get;set;}

            }

            public class CollectionRemoveRequest
            {
                public CollectionRemoveRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class CollectionGetRequest
            {
                public CollectionGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class CollectionGetResponse
            {
                public CollectionGetResponse()
                {
                    _status = new Status();
                _entity = new CollectionEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public CollectionEntity _entity {get;set;}

            }

            public class ElementAddRequest
            {
                public ElementAddRequest()
                {
                    _collection = Any.FromString("");
                _key = Any.FromString("");
                _alias = Any.FromString("");
                _label = Any.FromStringAry(new string[0]);

                }
                [JsonPropertyName("collection")]
            public Any _collection {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}
            [JsonPropertyName("label")]
            public Any _label {get;set;}

            }

            public class ElementUpdateRequest
            {
                public ElementUpdateRequest()
                {
                    _uuid = Any.FromString("");
                _key = Any.FromString("");
                _alias = Any.FromString("");
                _label = Any.FromStringAry(new string[0]);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}
            [JsonPropertyName("label")]
            public Any _label {get;set;}

            }

            public class ElementListRequest
            {
                public ElementListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _collection = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("collection")]
            public Any _collection {get;set;}

            }

            public class ElementSearchRequest
            {
                public ElementSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _collection = Any.FromString("");
                _key = Any.FromString("");
                _alias = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("collection")]
            public Any _collection {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}

            }

            public class ElementListResponse
            {
                public ElementListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new ElementEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public ElementEntity[] _entity {get;set;}

            }

            public class ElementRemoveRequest
            {
                public ElementRemoveRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ElementGetRequest
            {
                public ElementGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ElementGetResponse
            {
                public ElementGetResponse()
                {
                    _status = new Status();
                _entity = new ElementEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public ElementEntity _entity {get;set;}

            }

            public class ElementWhereRequest
            {
                public ElementWhereRequest()
                {
                    _key = Any.FromString("");

                }
                [JsonPropertyName("key")]
            public Any _key {get;set;}

            }

            public class ElementWhereResponse
            {
                public ElementWhereResponse()
                {
                    _status = new Status();
                _uuid = new Dictionary<string, string>();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("uuid")]
            public Dictionary<string, string> _uuid {get;set;}

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

            public class CollectionEntity
            {
                public CollectionEntity()
                {
                    _uuid = Any.FromString("");
                _name = Any.FromString("");
                _capacity = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}

            }

            public class ElementEntity
            {
                public ElementEntity()
                {
                    _uuid = Any.FromString("");
                _collection = Any.FromString("");
                _key = Any.FromString("");
                _alias = Any.FromString("");
                _label = Any.FromStringAry(new string[0]);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("collection")]
            public Any _collection {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("alias")]
            public Any _alias {get;set;}
            [JsonPropertyName("label")]
            public Any _label {get;set;}

            }

}
