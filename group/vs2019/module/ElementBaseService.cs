
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group
{
    public class ElementBaseService: Service
    {
        protected ElementModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(ElementModel.NAME) as ElementModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.ElementService");
        }

            public void PostAdd(Proto.ElementAddRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["collection"] = _request._collection;
            paramMap["key"] = _request._key;
            paramMap["alias"] = _request._alias;
            paramMap["label"] = _request._label;

                post(string.Format("{0}/ogm/group/Element/Add", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveAdd(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostUpdate(Proto.ElementUpdateRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;
            paramMap["key"] = _request._key;
            paramMap["alias"] = _request._alias;
            paramMap["label"] = _request._label;

                post(string.Format("{0}/ogm/group/Element/Update", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveUpdate(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostList(Proto.ElementListRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["collection"] = _request._collection;

                post(string.Format("{0}/ogm/group/Element/List", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.ElementListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveList(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostSearch(Proto.ElementSearchRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["collection"] = _request._collection;
            paramMap["key"] = _request._key;
            paramMap["alias"] = _request._alias;

                post(string.Format("{0}/ogm/group/Element/Search", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.ElementListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveSearch(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostRemove(Proto.ElementRemoveRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/group/Element/Remove", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveRemove(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostGet(Proto.ElementGetRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/group/Element/Get", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.ElementGetResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveGet(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostWhere(Proto.ElementWhereRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["key"] = _request._key;

                post(string.Format("{0}/ogm/group/Element/Where", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.ElementWhereResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveWhere(rsp);
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
