
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.permission.Proto
{

            public class RuleAddRequest
            {
                public RuleAddRequest()
                {
                    _key = Any.FromString("");
                _name = Any.FromString("");
                _scope = Any.FromString("");
                _state = Any.FromInt32(0);

                }
                [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("scope")]
            public Any _scope {get;set;}
            [JsonPropertyName("state")]
            public Any _state {get;set;}

            }

            public class RuleUpdateRequest
            {
                public RuleUpdateRequest()
                {
                    _uuid = Any.FromString("");
                _key = Any.FromString("");
                _name = Any.FromString("");
                _state = Any.FromInt32(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("state")]
            public Any _state {get;set;}

            }

            public class RuleDeleteRequest
            {
                public RuleDeleteRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class RuleListRequest
            {
                public RuleListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _scope = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("scope")]
            public Any _scope {get;set;}

            }

            public class RuleSearchRequest
            {
                public RuleSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _scope = Any.FromString("");
                _key = Any.FromString("");
                _name = Any.FromString("");
                _state = Any.FromInt32(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("scope")]
            public Any _scope {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("state")]
            public Any _state {get;set;}

            }

            public class RuleListResponse
            {
                public RuleListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new RuleEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public RuleEntity[] _entity {get;set;}

            }

            public class RuleGetRequest
            {
                public RuleGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class RuleGetResponse
            {
                public RuleGetResponse()
                {
                    _status = new Status();
                _entity = new RuleEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public RuleEntity _entity {get;set;}

            }

            public class ScopeCreateRequest
            {
                public ScopeCreateRequest()
                {
                    _key = Any.FromString("");
                _name = Any.FromString("");

                }
                [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

            }

            public class ScopeUpdateRequest
            {
                public ScopeUpdateRequest()
                {
                    _uuid = Any.FromString("");
                _key = Any.FromString("");
                _name = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

            }

            public class ScopeDeleteRequest
            {
                public ScopeDeleteRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ScopeListRequest
            {
                public ScopeListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}

            }

            public class ScopeSearchRequest
            {
                public ScopeSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _key = Any.FromString("");
                _name = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

            }

            public class ScopeListResponse
            {
                public ScopeListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _entity = new ScopeEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("entity")]
            public ScopeEntity[] _entity {get;set;}

            }

            public class ScopeGetRequest
            {
                public ScopeGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class ScopeGetResponse
            {
                public ScopeGetResponse()
                {
                    _status = new Status();
                _entity = new ScopeEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("entity")]
            public ScopeEntity _entity {get;set;}

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

            public class ScopeEntity
            {
                public ScopeEntity()
                {
                    _uuid = Any.FromString("");
                _key = Any.FromString("");
                _name = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}

            }

            public class RuleEntity
            {
                public RuleEntity()
                {
                    _uuid = Any.FromString("");
                _scope = Any.FromString("");
                _key = Any.FromString("");
                _name = Any.FromString("");
                _state = Any.FromInt32(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("scope")]
            public Any _scope {get;set;}
            [JsonPropertyName("key")]
            public Any _key {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("state")]
            public Any _state {get;set;}

            }

}
