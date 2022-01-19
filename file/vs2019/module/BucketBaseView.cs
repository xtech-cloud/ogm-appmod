
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketBaseView: View
    {
        protected Facade facade = null;
        protected BucketModel model = null;
        protected IBucketUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(BucketModel.NAME) as BucketModel;
            var service = findService(BucketService.NAME) as BucketService;
            facade = findFacade("ogm.file.BucketFacade");
            BucketViewBridge vb = new BucketViewBridge();
            vb.view = this as BucketView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.BucketView");

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/Make", this.handleReceiveBucketMake);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/List", this.handleReceiveBucketList);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/Remove", this.handleReceiveBucketRemove);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/Get", this.handleReceiveBucketGet);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/Find", this.handleReceiveBucketFind);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/Search", this.handleReceiveBucketSearch);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/Update", this.handleReceiveBucketUpdate);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/ResetToken", this.handleReceiveBucketResetToken);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/GenerateManifest", this.handleReceiveBucketGenerateManifest);

            addObserver(BucketModel.NAME, "_.reply.arrived:ogm/file/Bucket/Clean", this.handleReceiveBucketClean);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IBucketUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.file.Bucket"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
            // 监听权限更新
            addRouter("/permission/updated", this.handlePermissionUpdated);
        }

        protected void handlePermissionUpdated(Model.Status _status, object _data)
        {
            Dictionary<string, string> permission = (Dictionary<string,string>) _data;
            bridge.UpdatePermission(permission);
        }


        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleReceiveBucketMake(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/Make is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveMake(json);
        }

        private void handleReceiveBucketList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BucketListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveBucketRemove(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/Remove is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRemove(json);
        }

        private void handleReceiveBucketGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BucketGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveBucketFind(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BucketFindResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/Find is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveFind(json);
        }

        private void handleReceiveBucketSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BucketSearchResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

        private void handleReceiveBucketUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveBucketResetToken(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/ResetToken is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveResetToken(json);
        }

        private void handleReceiveBucketGenerateManifest(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BucketGenerateManifestResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/GenerateManifest is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGenerateManifest(json);
        }

        private void handleReceiveBucketClean(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Bucket/Clean is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveClean(json);
        }

    }
}
