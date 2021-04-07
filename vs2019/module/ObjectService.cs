
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class ObjectService: Service
    {
        public const string NAME = "File.ObjectService";
        private ObjectModel model = null;

        protected override void preSetup()
        {
            model = findModel(ObjectModel.NAME) as ObjectModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ObjectService");
        }

        public void PostPrepare(Proto.ObjectPrepareRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request.bucket.AsAny();
            paramMap["uname"] = _request.uname.AsAny();
            paramMap["size"] = _request.size.AsAny();

            post(string.Format("{0}/ogm/file/Object/Prepare", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPrepareResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Prepare", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostFlush(Proto.ObjectFlushRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request.bucket.AsAny();
            paramMap["uname"] = _request.uname.AsAny();
            paramMap["path"] = _request.path.AsAny();

            post(string.Format("{0}/ogm/file/Object/Flush", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Flush", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostLink(Proto.ObjectLinkRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request.bucket.AsAny();
            paramMap["filepath"] = _request.filepath.AsAny();
            paramMap["url"] = _request.url.AsAny();
            paramMap["overwrite"] = _request.overwrite.AsAny();

            post(string.Format("{0}/ogm/file/Object/Link", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Link", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostGet(Proto.ObjectGetRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();

            post(string.Format("{0}/ogm/file/Object/Get", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.ObjectGetResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Get", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostFind(Proto.ObjectFindRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = _request.bucket.AsAny();
            paramMap["filepath"] = _request.filepath.AsAny();

            post(string.Format("{0}/ogm/file/Object/Find", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.ObjectFindResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Find", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostRemove(Proto.ObjectRemoveRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();

            post(string.Format("{0}/ogm/file/Object/Remove", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Remove", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostList(Proto.ObjectListRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = _request.offset.AsAny();
            paramMap["count"] = _request.count.AsAny();
            paramMap["bucket"] = _request.bucket.AsAny();

            post(string.Format("{0}/ogm/file/Object/List", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.ObjectListResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/List", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostSearch(Proto.ObjectSearchRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = _request.offset.AsAny();
            paramMap["count"] = _request.count.AsAny();
            paramMap["bucket"] = _request.bucket.AsAny();
            paramMap["prefix"] = _request.prefix.AsAny();

            post(string.Format("{0}/ogm/file/Object/Search", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.ObjectSearchResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Search", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostPublish(Proto.ObjectPublishRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();
            paramMap["expiry"] = _request.expiry.AsAny();

            post(string.Format("{0}/ogm/file/Object/Publish", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPublishResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Publish", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostPreview(Proto.ObjectPreviewRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();

            post(string.Format("{0}/ogm/file/Object/Preview", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPreviewResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Preview", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostRetract(Proto.ObjectRetractRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();

            post(string.Format("{0}/ogm/file/Object/Retract", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Object/Retract", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        


        protected override void asyncRequest(string _url, string _method, Dictionary<string, Any> _params, OnReplyCallback _onReply, OnErrorCallback _onError, Options _options)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_url); 
            req.Method = _method;
            req.ContentType =
            "application/json;charset=utf-8";
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyConverter());
            string json = System.Text.Json.JsonSerializer.Serialize(_params, options);
            byte[] data = System.Text.Encoding.UTF8.GetBytes(json);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
            }
            HttpWebResponse rsp = (HttpWebResponse)req.GetResponse();
            if(rsp == null)
            {
                _onError(Error.NewNullErr("HttpWebResponse is null"));
                return;
            }
            if(rsp.StatusCode != HttpStatusCode.OK)
            {
                rsp.Close();
                _onError(new Error(rsp.StatusCode.GetHashCode(), "HttpStatusCode != 200"));
                return;
            }
            string reply = "";
            StreamReader sr;
            using (sr = new StreamReader(rsp.GetResponseStream()))
            {
                reply = sr.ReadToEnd();
            }
            sr.Close();
            _onReply(reply);
        }
    }
}
