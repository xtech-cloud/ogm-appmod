
using System;
using System.Text;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.startkit.Proto
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
    
        public class Request
        {
            public Request()
            {
                _msg = Any.FromString("");

            }
            [JsonPropertyName("msg")]
            public Any _msg {get;set;}

        }
    
        public class Response
        {
            public Response()
            {
                _status = new Status();
                _msg = Any.FromString("");

            }
            [JsonPropertyName("status")]
            public Status _status {get;set;}
            [JsonPropertyName("msg")]
            public Any _msg {get;set;}

        }
    
}
