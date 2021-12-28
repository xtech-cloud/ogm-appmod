
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license
{
    public class KeyBaseService: Service
    {
        protected KeyModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(KeyModel.NAME) as KeyModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.KeyService");
        }

            public void PostGenerate(Proto.KeyGenerateRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["space"] = _request._space;
            paramMap["count"] = _request._count;
            paramMap["capacity"] = _request._capacity;
            paramMap["expiry"] = _request._expiry;
            paramMap["storage"] = _request._storage;
            paramMap["profile"] = _request._profile;

                post(string.Format("{0}/ogm/license/Key/Generate", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.KeyGenerateResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveGenerate(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostActivate(Proto.KeyActivateRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["number"] = _request._number;
            paramMap["consumer"] = _request._consumer;
            paramMap["space"] = _request._space;

                post(string.Format("{0}/ogm/license/Key/Activate", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.KeyActivateResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveActivate(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostUpdate(Proto.KeyUpdateRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;
            paramMap["profile"] = _request._profile;
            paramMap["ban"] = _request._ban;
            paramMap["reason"] = _request._reason;

                post(string.Format("{0}/ogm/license/Key/Update", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveUpdate(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostGet(Proto.KeyGetRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/license/Key/Get", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.KeyGetResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveGet(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostList(Proto.KeyListRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["space"] = _request._space;

                post(string.Format("{0}/ogm/license/Key/List", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.KeyListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveList(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostSearch(Proto.KeySearchRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["space"] = _request._space;
            paramMap["number"] = _request._number;
            paramMap["capacity"] = _request._capacity;
            paramMap["expiry"] = _request._expiry;
            paramMap["storage"] = _request._storage;
            paramMap["profile"] = _request._profile;
            paramMap["ban"] = _request._ban;

                post(string.Format("{0}/ogm/license/Key/Search", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.KeyListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveSearch(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }



        protected override void asyncRequest(string _url, string _method, Dictionary<string, Any> _params, OnReplyCallback _onReply, OnErrorCallback _onError, Options _options)
        {
            doAsyncRequest(_url, _method, _params, _onReply, _onError, _options);
        }

        protected async void doAsyncRequest(string _url, string _method, Dictionary<string, Any> _params, OnReplyCallback _onReply, OnErrorCallback _onError, Options _options)
        {
            string reply = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_url);
                req.Method = _method;
                req.ContentType = "application/json;charset=utf-8";
                foreach (var pair in options.header)
                    req.Headers.Add(pair.Key, pair.Value);
                byte[] data = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_params, JsonOptions.DefaultSerializerOptions);
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                HttpWebResponse rsp = await req.GetResponseAsync() as HttpWebResponse;
                if (rsp == null)
                {
                    _onError(Error.NewNullErr("HttpWebResponse is null"));
                    return;
                }
                if (rsp.StatusCode != HttpStatusCode.OK)
                {
                    rsp.Close();
                    _onError(new Error(rsp.StatusCode.GetHashCode(), "HttpStatusCode != 200"));
                    return;
                }
                StreamReader sr;
                using (sr = new StreamReader(rsp.GetResponseStream()))
                {
                    reply = sr.ReadToEnd();
                }
                sr.Close();
            }
            catch (System.Exception ex)
            {
                _onError(Error.NewException(ex));
                return;
            }
            _onReply(reply);
        }
    }
}
