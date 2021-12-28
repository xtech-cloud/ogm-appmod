
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license
{
    public class SpaceBaseService: Service
    {
        protected SpaceModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(SpaceModel.NAME) as SpaceModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.SpaceService");
        }

            public void PostCreate(Proto.SpaceCreateRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["name"] = _request._name;
            paramMap["profile"] = _request._profile;

                post(string.Format("{0}/ogm/license/Space/Create", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveCreate(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostUpdate(Proto.SpaceUpdateRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;
            paramMap["profile"] = _request._profile;

                post(string.Format("{0}/ogm/license/Space/Update", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveUpdate(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostGet(Proto.SpaceGetRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/license/Space/Get", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.SpaceGetResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveGet(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostList(Proto.SpaceListRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;

                post(string.Format("{0}/ogm/license/Space/List", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.SpaceListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveList(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostSearch(Proto.SpaceSearchRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["name"] = _request._name;

                post(string.Format("{0}/ogm/license/Space/Search", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.SpaceListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
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
