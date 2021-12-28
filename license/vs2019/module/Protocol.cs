
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license.Proto
{

            public class CerGetRequest
            {
                public CerGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class CerGetResponse
            {
                public CerGetResponse()
                {
                    _status = new Status();
                _cer = new CertificateEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("cer")]
            public CertificateEntity _cer {get;set;}

            }

            public class CerSearchRequest
            {
                public CerSearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _space = Any.FromString("");
                _number = Any.FromString("");
                _consumer = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("space")]
            public Any _space {get;set;}
            [JsonPropertyName("number")]
            public Any _number {get;set;}
            [JsonPropertyName("consumer")]
            public Any _consumer {get;set;}

            }

            public class CerListRequest
            {
                public CerListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _space = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("space")]
            public Any _space {get;set;}

            }

            public class CerListResponse
            {
                public CerListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _cer = new CertificateEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("cer")]
            public CertificateEntity[] _cer {get;set;}

            }

            public class KeyGenerateRequest
            {
                public KeyGenerateRequest()
                {
                    _space = Any.FromString("");
                _count = Any.FromInt32(0);
                _capacity = Any.FromInt32(0);
                _expiry = Any.FromInt32(0);
                _storage = Any.FromString("");
                _profile = Any.FromString("");

                }
                [JsonPropertyName("space")]
            public Any _space {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}
            [JsonPropertyName("expiry")]
            public Any _expiry {get;set;}
            [JsonPropertyName("storage")]
            public Any _storage {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}

            }

            public class KeyGenerateResponse
            {
                public KeyGenerateResponse()
                {
                    _status = new Status();
                _number = Any.FromStringAry(new string[0]);

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("number")]
            public Any _number {get;set;}

            }

            public class KeyActivateRequest
            {
                public KeyActivateRequest()
                {
                    _number = Any.FromString("");
                _consumer = Any.FromString("");
                _space = Any.FromString("");

                }
                [JsonPropertyName("number")]
            public Any _number {get;set;}
            [JsonPropertyName("consumer")]
            public Any _consumer {get;set;}
            [JsonPropertyName("space")]
            public Any _space {get;set;}

            }

            public class KeyActivateResponse
            {
                public KeyActivateResponse()
                {
                    _status = new Status();
                _uuid = Any.FromString("");
                _cerUID = Any.FromString("");
                _cerContent = Any.FromString("");

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("cerUID")]
            public Any _cerUID {get;set;}
            [JsonPropertyName("cerContent")]
            public Any _cerContent {get;set;}

            }

            public class KeyUpdateRequest
            {
                public KeyUpdateRequest()
                {
                    _uuid = Any.FromString("");
                _profile = Any.FromString("");
                _ban = Any.FromInt32(0);
                _reason = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}
            [JsonPropertyName("ban")]
            public Any _ban {get;set;}
            [JsonPropertyName("reason")]
            public Any _reason {get;set;}

            }

            public class KeyGetRequest
            {
                public KeyGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class KeyGetResponse
            {
                public KeyGetResponse()
                {
                    _status = new Status();
                _key = new KeyEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("key")]
            public KeyEntity _key {get;set;}

            }

            public class KeyListRequest
            {
                public KeyListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _space = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("space")]
            public Any _space {get;set;}

            }

            public class KeyListResponse
            {
                public KeyListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _key = new KeyEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("key")]
            public KeyEntity[] _key {get;set;}

            }

            public class KeySearchRequest
            {
                public KeySearchRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _space = Any.FromString("");
                _number = Any.FromString("");
                _capacity = Any.FromInt32(0);
                _expiry = Any.FromInt32(0);
                _storage = Any.FromString("");
                _profile = Any.FromString("");
                _ban = Any.FromInt32(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("space")]
            public Any _space {get;set;}
            [JsonPropertyName("number")]
            public Any _number {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}
            [JsonPropertyName("expiry")]
            public Any _expiry {get;set;}
            [JsonPropertyName("storage")]
            public Any _storage {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}
            [JsonPropertyName("ban")]
            public Any _ban {get;set;}

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

            public class SpaceEntity
            {
                public SpaceEntity()
                {
                    _uuid = Any.FromString("");
                _name = Any.FromString("");
                _spaceKey = Any.FromString("");
                _spaceSecret = Any.FromString("");
                _publicKey = Any.FromString("");
                _privateKey = Any.FromString("");
                _profile = Any.FromString("");
                _createdAt = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("spaceKey")]
            public Any _spaceKey {get;set;}
            [JsonPropertyName("spaceSecret")]
            public Any _spaceSecret {get;set;}
            [JsonPropertyName("publicKey")]
            public Any _publicKey {get;set;}
            [JsonPropertyName("privateKey")]
            public Any _privateKey {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}
            [JsonPropertyName("createdAt")]
            public Any _createdAt {get;set;}

            }

            public class KeyEntity
            {
                public KeyEntity()
                {
                    _uuid = Any.FromString("");
                _number = Any.FromString("");
                _space = Any.FromString("");
                _capacity = Any.FromInt32(0);
                _expiry = Any.FromInt32(0);
                _storage = Any.FromString("");
                _profile = Any.FromString("");
                _ban = Any.FromInt32(0);
                _reason = Any.FromString("");
                _consumer = Any.FromStringAry(new string[0]);
                _createdAt = Any.FromInt64(0);
                _updatedAt = Any.FromInt64(0);
                _activatedAt = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("number")]
            public Any _number {get;set;}
            [JsonPropertyName("space")]
            public Any _space {get;set;}
            [JsonPropertyName("capacity")]
            public Any _capacity {get;set;}
            [JsonPropertyName("expiry")]
            public Any _expiry {get;set;}
            [JsonPropertyName("storage")]
            public Any _storage {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}
            [JsonPropertyName("ban")]
            public Any _ban {get;set;}
            [JsonPropertyName("reason")]
            public Any _reason {get;set;}
            [JsonPropertyName("consumer")]
            public Any _consumer {get;set;}
            [JsonPropertyName("createdAt")]
            public Any _createdAt {get;set;}
            [JsonPropertyName("updatedAt")]
            public Any _updatedAt {get;set;}
            [JsonPropertyName("activatedAt")]
            public Any _activatedAt {get;set;}

            }

            public class CertificateEntity
            {
                public CertificateEntity()
                {
                    _uuid = Any.FromString("");
                _space = Any.FromString("");
                _number = Any.FromString("");
                _consumer = Any.FromString("");
                _content = Any.FromString("");
                _createdAt = Any.FromInt64(0);

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("space")]
            public Any _space {get;set;}
            [JsonPropertyName("number")]
            public Any _number {get;set;}
            [JsonPropertyName("consumer")]
            public Any _consumer {get;set;}
            [JsonPropertyName("content")]
            public Any _content {get;set;}
            [JsonPropertyName("createdAt")]
            public Any _createdAt {get;set;}

            }

            public class SpaceCreateRequest
            {
                public SpaceCreateRequest()
                {
                    _name = Any.FromString("");
                _profile = Any.FromString("");

                }
                [JsonPropertyName("name")]
            public Any _name {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}

            }

            public class SpaceUpdateRequest
            {
                public SpaceUpdateRequest()
                {
                    _uuid = Any.FromString("");
                _profile = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}

            }

            public class SpaceSearchRequest
            {
                public SpaceSearchRequest()
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

            public class SpaceListRequest
            {
                public SpaceListRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}

            }

            public class SpaceListResponse
            {
                public SpaceListResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _space = new SpaceEntity[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("space")]
            public SpaceEntity[] _space {get;set;}

            }

            public class SpaceGetRequest
            {
                public SpaceGetRequest()
                {
                    _uuid = Any.FromString("");

                }
                [JsonPropertyName("uuid")]
            public Any _uuid {get;set;}

            }

            public class SpaceGetResponse
            {
                public SpaceGetResponse()
                {
                    _status = new Status();
                _space = new SpaceEntity();

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("space")]
            public SpaceEntity _space {get;set;}

            }

}
