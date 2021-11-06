
using System;
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

           addRouter("/ogm/file/Bucket/Make", this.handleBucketMake);
    
           addRouter("/ogm/file/Bucket/List", this.handleBucketList);
    
           addRouter("/ogm/file/Bucket/Remove", this.handleBucketRemove);
    
           addRouter("/ogm/file/Bucket/Get", this.handleBucketGet);
    
           addRouter("/ogm/file/Bucket/Find", this.handleBucketFind);
    
           addRouter("/ogm/file/Bucket/Search", this.handleBucketSearch);
    
           addRouter("/ogm/file/Bucket/Update", this.handleBucketUpdate);
    
           addRouter("/ogm/file/Bucket/ResetToken", this.handleBucketResetToken);
    
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

        private void handleBucketMake(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleBucketList(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketListResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleBucketRemove(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleBucketGet(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketGetResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleBucketFind(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketFindResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleBucketSearch(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketSearchResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleBucketUpdate(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleBucketResetToken(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
