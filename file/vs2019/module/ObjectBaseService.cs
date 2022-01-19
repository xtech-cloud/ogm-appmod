
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectBaseService : Service
    {
        protected ObjectModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(ObjectModel.NAME) as ObjectModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.ObjectService");
        }

        public void PostPrepare(Proto.ObjectPrepareRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request._bucket;
            paramMap["hash"] = _request._hash;
            paramMap["path"] = _request._path;
            paramMap["size"] = _request._size;
            paramMap["expiry"] = _request._expiry;
            paramMap["override"] = _request._override;

            post(string.Format("{0}/ogm/file/Object/Prepare", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPrepareResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SavePrepare(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostFlush(Proto.ObjectFlushRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request._bucket;
            paramMap["hash"] = _request._hash;
            paramMap["path"] = _request._path;

            post(string.Format("{0}/ogm/file/Object/Flush", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveFlush(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostLink(Proto.ObjectLinkRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request._bucket;
            paramMap["filepath"] = _request._filepath;
            paramMap["url"] = _request._url;
            paramMap["overwrite"] = _request._overwrite;

            post(string.Format("{0}/ogm/file/Object/Link", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveLink(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostGet(Proto.ObjectGetRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;

            post(string.Format("{0}/ogm/file/Object/Get", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectGetResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveGet(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostFind(Proto.ObjectFindRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request._bucket;
            paramMap["path"] = _request._path;

            post(string.Format("{0}/ogm/file/Object/Find", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectFindResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveFind(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostRemove(Proto.ObjectRemoveRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;

            post(string.Format("{0}/ogm/file/Object/Remove", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveRemove(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostList(Proto.ObjectListRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["bucket"] = _request._bucket;

            post(string.Format("{0}/ogm/file/Object/List", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveList(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostSearch(Proto.ObjectSearchRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["bucket"] = _request._bucket;
            paramMap["prefix"] = _request._prefix;
            paramMap["name"] = _request._name;

            post(string.Format("{0}/ogm/file/Object/Search", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectSearchResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveSearch(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostPublish(Proto.ObjectPublishRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;
            paramMap["expiry"] = _request._expiry;

            post(string.Format("{0}/ogm/file/Object/Publish", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPublishResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SavePublish(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostPreview(Proto.ObjectPreviewRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;
            paramMap["expiry"] = _request._expiry;

            post(string.Format("{0}/ogm/file/Object/Preview", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPreviewResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SavePreview(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostRetract(Proto.ObjectRetractRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;

            post(string.Format("{0}/ogm/file/Object/Retract", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveRetract(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostConvertFromBase64(Proto.ObjectConvertFromBase64Request _request)
        {
        }


        public void PostConvertFromUrl(Proto.ObjectConvertFromUrlRequest _request)
        {
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
