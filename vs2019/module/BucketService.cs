
using System.Collections.Generic;
using System.Text.Json;
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
            paramMap["name"] = Any.FromString(_request.name);
            paramMap["capacity"] = Any.FromLong(_request.capacity);
            paramMap["engine"] = Any.FromInt(_request.engine);
            paramMap["address"] = Any.FromString(_request.address);
            paramMap["scope"] = Any.FromString(_request.scope);
            paramMap["accessKey"] = Any.FromString(_request.accessKey);
            paramMap["accessSecret"] = Any.FromString(_request.accessSecret);

            post("/ogm/file/Bucket/Make", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/Make", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostList(Proto.BucketListRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = Any.FromLong(_request.offset);
            paramMap["count"] = Any.FromLong(_request.count);

            post("/ogm/file/Bucket/List", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BucketListResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/List", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostRemove(Proto.BucketRemoveRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);

            post("/ogm/file/Bucket/Remove", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/Remove", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostGet(Proto.BucketGetRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);

            post("/ogm/file/Bucket/Get", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BucketGetResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/Get", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostFind(Proto.BucketFindRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["name"] = Any.FromString(_request.name);

            post("/ogm/file/Bucket/Find", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BucketFindResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/Find", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostUpdateEngine(Proto.BucketUpdateEngineRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);
            paramMap["engine"] = Any.FromInt(_request.engine);
            paramMap["address"] = Any.FromString(_request.address);
            paramMap["scope"] = Any.FromString(_request.scope);
            paramMap["accessKey"] = Any.FromString(_request.accessKey);
            paramMap["accessSecret"] = Any.FromString(_request.accessSecret);

            post("/ogm/file/Bucket/UpdateEngine", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/UpdateEngine", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostUpdateCapacity(Proto.BucketUpdateCapacityRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);
            paramMap["capacity"] = Any.FromLong(_request.capacity);

            post("/ogm/file/Bucket/UpdateCapacity", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/UpdateCapacity", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostResetToken(Proto.BucketResetTokenRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = Any.FromString(_request.uuid);

            post("/ogm/file/Bucket/ResetToken", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/ResetToken", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

    }
}
