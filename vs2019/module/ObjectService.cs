
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
            paramMap["bucket"] = Any.FromString(_request.bucket);
            paramMap["uname"] = Any.FromString(_request.uname);
            paramMap["size"] = Any.FromLong(_request.size);

            post(string.Format("{0}/ogm/file/Object/Prepare", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPrepareResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Prepare", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostFlush(Proto.ObjectFlushRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = Any.FromString(_request.bucket);
            paramMap["uname"] = Any.FromString(_request.uname);
            paramMap["path"] = Any.FromString(_request.path);

            post(string.Format("{0}/ogm/file/Object/Flush", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Flush", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostLink(Proto.ObjectLinkRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = Any.FromString(_request.bucket);
            paramMap["filepath"] = Any.FromString(_request.filepath);
            paramMap["url"] = Any.FromString(_request.url);
            paramMap["overwrite"] = Any.FromBool(_request.overwrite);

            post(string.Format("{0}/ogm/file/Object/Link", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Link", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostGet(Proto.ObjectGetRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);

            post(string.Format("{0}/ogm/file/Object/Get", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectGetResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Get", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostFind(Proto.ObjectFindRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["bucket"] = Any.FromString(_request.bucket);
            paramMap["filepath"] = Any.FromString(_request.filepath);

            post(string.Format("{0}/ogm/file/Object/Find", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectFindResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Find", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostRemove(Proto.ObjectRemoveRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);

            post(string.Format("{0}/ogm/file/Object/Remove", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Remove", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostList(Proto.ObjectListRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = Any.FromLong(_request.offset);
            paramMap["count"] = Any.FromLong(_request.count);
            paramMap["bucket"] = Any.FromString(_request.bucket);

            post(string.Format("{0}/ogm/file/Object/List", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectListResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/List", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostSearch(Proto.ObjectSearchRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = Any.FromLong(_request.offset);
            paramMap["count"] = Any.FromLong(_request.count);
            paramMap["bucket"] = Any.FromString(_request.bucket);
            paramMap["prefix"] = Any.FromString(_request.prefix);

            post(string.Format("{0}/ogm/file/Object/Search", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectSearchResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Search", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostPublish(Proto.ObjectPublishRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);
            paramMap["expiry"] = Any.FromLong(_request.expiry);

            post(string.Format("{0}/ogm/file/Object/Publish", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPublishResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Publish", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostPreview(Proto.ObjectPreviewRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);

            post(string.Format("{0}/ogm/file/Object/Preview", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.ObjectPreviewResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Object/Preview", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostRetract(Proto.ObjectRetractRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);

            post(string.Format("{0}/ogm/file/Object/Retract", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                ObjectModel.ObjectStatus status = Model.Status.New<ObjectModel.ObjectStatus>(rsp.status.code, rsp.status.message);
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
