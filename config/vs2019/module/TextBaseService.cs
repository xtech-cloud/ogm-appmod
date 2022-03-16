
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.config
{
    public class TextBaseService: Service
    {
        protected TextModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(TextModel.NAME) as TextModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.config.TextService");
        }

            public void PostWrite(Proto.TextWriteRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["path"] = _request._path;
            paramMap["content"] = _request._content;

                post(string.Format("{0}/ogm/config/Text/Write", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveWrite(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostRead(Proto.TextReadRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["path"] = _request._path;

                post(string.Format("{0}/ogm/config/Text/Read", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.TextReadResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveRead(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostDelete(Proto.DeleteRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/config/Text/Delete", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveDelete(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostGet(Proto.GetRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["uuid"] = _request._uuid;

                post(string.Format("{0}/ogm/config/Text/Get", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.TextGetResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveGet(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostList(Proto.ListRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;

                post(string.Format("{0}/ogm/config/Text/List", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.TextListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveList(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostSearch(Proto.TextSearchRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["path"] = _request._path;

                post(string.Format("{0}/ogm/config/Text/Search", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.TextSearchResponse>(_reply, JsonOptions.DefaultSerializerOptions);
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
