
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class BucketView: View
    {
        public const string NAME = "File.BucketView";

        private Facade facade = null;
        private BucketModel model = null;
        private IBucketUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(BucketModel.NAME) as BucketModel;
            var service = findService(BucketService.NAME) as BucketService;
            facade = findFacade("File.BucketFacade");
            BucketViewBridge vb = new BucketViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup BucketView");

           route("/ogm/file/Bucket/Make", this.handleBucketMake);
    
           route("/ogm/file/Bucket/List", this.handleBucketList);
    
           route("/ogm/file/Bucket/Remove", this.handleBucketRemove);
    
           route("/ogm/file/Bucket/Get", this.handleBucketGet);
    
           route("/ogm/file/Bucket/Find", this.handleBucketFind);
    
           route("/ogm/file/Bucket/UpdateEngine", this.handleBucketUpdateEngine);
    
           route("/ogm/file/Bucket/UpdateCapacity", this.handleBucketUpdateCapacity);
    
           route("/ogm/file/Bucket/ResetToken", this.handleBucketResetToken);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IBucketUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["/OGM/File/Bucket"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        private void handleBucketMake(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
        private void handleBucketList(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketListResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
        private void handleBucketRemove(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
        private void handleBucketGet(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketGetResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
        private void handleBucketFind(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketFindResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
        private void handleBucketUpdateEngine(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
        private void handleBucketUpdateCapacity(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
        private void handleBucketResetToken(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code.AsInt() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code.AsInt(), rsp.status.message.AsString()));
        }
    
    }
}
