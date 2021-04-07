
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class BucketService: Service
    {
        public const string NAME = "File.BucketService";
        private BucketModel model = null;

        protected override void preSetup()
        {
            model = findModel(BucketModel.NAME) as BucketModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup BucketService");
        }

        public void PostMake(Proto.BucketMakeRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["name"] = _request.name.AsAny();
            paramMap["capacity"] = _request.capacity.AsAny();
            paramMap["engine"] = _request.engine.AsAny();
            paramMap["address"] = _request.address.AsAny();
            paramMap["scope"] = _request.scope.AsAny();
            paramMap["accessKey"] = _request.accessKey.AsAny();
            paramMap["accessSecret"] = _request.accessSecret.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/Make", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/Make", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostList(Proto.BucketListRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = _request.offset.AsAny();
            paramMap["count"] = _request.count.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/List", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BucketListResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/List", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostRemove(Proto.BucketRemoveRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/Remove", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/Remove", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostGet(Proto.BucketGetRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/Get", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BucketGetResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/Get", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostFind(Proto.BucketFindRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["name"] = _request.name.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/Find", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BucketFindResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/Find", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostUpdateEngine(Proto.BucketUpdateEngineRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();
            paramMap["engine"] = _request.engine.AsAny();
            paramMap["address"] = _request.address.AsAny();
            paramMap["scope"] = _request.scope.AsAny();
            paramMap["accessKey"] = _request.accessKey.AsAny();
            paramMap["accessSecret"] = _request.accessSecret.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/UpdateEngine", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/UpdateEngine", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostUpdateCapacity(Proto.BucketUpdateCapacityRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();
            paramMap["capacity"] = _request.capacity.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/UpdateCapacity", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/UpdateCapacity", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostResetToken(Proto.BucketResetTokenRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request.uuid.AsAny();

            post(string.Format("{0}/ogm/file/Bucket/ResetToken", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new FieldConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code.AsInt(), rsp.status.message.AsString());
                model.Broadcast("/ogm/file/Bucket/ResetToken", rsp);
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
