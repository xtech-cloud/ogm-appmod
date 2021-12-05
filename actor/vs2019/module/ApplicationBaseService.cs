
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationBaseService: Service
    {
        protected ApplicationModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(ApplicationModel.NAME) as ApplicationModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.ApplicationService");
        }

            public void PostAdd(Proto.ApplicationAddRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["domain"] = _request._domain;
            paramMap["name"] = _request._name;
            paramMap["version"] = _request._version;
            paramMap["program"] = _request._program;
            paramMap["location"] = _request._location;
            paramMap["url"] = _request._url;
            paramMap["upgrade"] = _request._upgrade;

                post(string.Format("{0}/ogm/actor/Application/Add", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveAdd(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostRemove(Proto.ApplicationRemoveRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/actor/Application/Remove", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveRemove(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostList(Proto.ApplicationListRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["domain"] = _request._domain;

                post(string.Format("{0}/ogm/actor/Application/List", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.ApplicationListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveList(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostGet(Proto.ApplicationGetRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/actor/Application/Get", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.ApplicationGetResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveGet(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostUpdate(Proto.ApplicationUpdateRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;
            paramMap["name"] = _request._name;
            paramMap["version"] = _request._version;
            paramMap["program"] = _request._program;
            paramMap["location"] = _request._location;
            paramMap["url"] = _request._url;
            paramMap["upgrade"] = _request._upgrade;

                post(string.Format("{0}/ogm/actor/Application/Update", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveUpdate(rsp);
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
