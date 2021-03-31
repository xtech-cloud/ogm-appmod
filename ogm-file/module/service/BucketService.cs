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

        public void PostBuckeMake(Proto.BucketMakeRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["name"] = Any.FromString(_request.name);
            paramMap["capacity"] = Any.FromLong(_request.capacity);
            paramMap["engine"] = Any.FromInt((int)_request.engine);
            paramMap["address"] = Any.FromString(_request.address);
            paramMap["scope"] = Any.FromString(_request.scope);
            paramMap["accessKey"] = Any.FromString(_request.accessKey);
            paramMap["accessSecret"] = Any.FromString(_request.accessSecret);
            post("/ogm/file/Bucket/Make", paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply);
                BucketModel.BucketStatus status = Model.Status.New<BucketModel.BucketStatus>(rsp.status.code, rsp.status.message);
                model.Broadcast("/ogm/file/Bucket/List", rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
    }
}
