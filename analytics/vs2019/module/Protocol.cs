
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.analytics.Proto
{

            public class GeneratorAgentRequest
            {
                public GeneratorAgentRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}

            }

            public class GeneratorAgentResponse
            {
                public GeneratorAgentResponse()
                {
                    _status = new Status();
                _total = Any.FromInt64(0);
                _agent = new Agent[0];

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("total")]
            public Any _total {get;set;}
            [JsonPropertyName("agent")]
            public Agent[] _agent {get;set;}

            }

            public class GeneratorRecordRequest
            {
                public GeneratorRecordRequest()
                {
                    _offset = Any.FromInt64(0);
                _count = Any.FromInt64(0);
                _startTime = Any.FromInt64(0);
                _endTime = Any.FromInt64(0);
                _appID = Any.FromString("");
                _deviceID = Any.FromString("");
                _userID = Any.FromString("");
                _eventID = Any.FromString("");
                _eventParameter = Any.FromString("");
                _template = Any.FromString("");

                }
                [JsonPropertyName("offset")]
            public Any _offset {get;set;}
            [JsonPropertyName("count")]
            public Any _count {get;set;}
            [JsonPropertyName("startTime")]
            public Any _startTime {get;set;}
            [JsonPropertyName("endTime")]
            public Any _endTime {get;set;}
            [JsonPropertyName("appID")]
            public Any _appID {get;set;}
            [JsonPropertyName("deviceID")]
            public Any _deviceID {get;set;}
            [JsonPropertyName("userID")]
            public Any _userID {get;set;}
            [JsonPropertyName("eventID")]
            public Any _eventID {get;set;}
            [JsonPropertyName("eventParameter")]
            public Any _eventParameter {get;set;}
            [JsonPropertyName("template")]
            public Any _template {get;set;}

            }

            public class GeneratorRecordResponse
            {
                public GeneratorRecordResponse()
                {
                    _status = new Status();
                _content = Any.FromString("");

                }
                [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("content")]
            public Any _content {get;set;}

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

            public class Agent
            {
                public Agent()
                {
                    _serialNumber = Any.FromString("");
                _softwareFamily = Any.FromString("");
                _softwareVersion = Any.FromString("");
                _systemFamily = Any.FromString("");
                _systemVersion = Any.FromString("");
                _deviceModel = Any.FromString("");
                _deviceType = Any.FromString("");
                _profile = Any.FromString("");

                }
                [JsonPropertyName("serialNumber")]
            public Any _serialNumber {get;set;}
            [JsonPropertyName("softwareFamily")]
            public Any _softwareFamily {get;set;}
            [JsonPropertyName("softwareVersion")]
            public Any _softwareVersion {get;set;}
            [JsonPropertyName("systemFamily")]
            public Any _systemFamily {get;set;}
            [JsonPropertyName("systemVersion")]
            public Any _systemVersion {get;set;}
            [JsonPropertyName("deviceModel")]
            public Any _deviceModel {get;set;}
            [JsonPropertyName("deviceType")]
            public Any _deviceType {get;set;}
            [JsonPropertyName("profile")]
            public Any _profile {get;set;}

            }

            public class TrackerRecordRequest
            {
                public TrackerRecordRequest()
                {
                    _appID = Any.FromString("");
                _deviceID = Any.FromString("");
                _userID = Any.FromString("");
                _eventID = Any.FromString("");
                _parameter = Any.FromString("");

                }
                [JsonPropertyName("appID")]
            public Any _appID {get;set;}
            [JsonPropertyName("deviceID")]
            public Any _deviceID {get;set;}
            [JsonPropertyName("userID")]
            public Any _userID {get;set;}
            [JsonPropertyName("eventID")]
            public Any _eventID {get;set;}
            [JsonPropertyName("parameter")]
            public Any _parameter {get;set;}

            }

}
