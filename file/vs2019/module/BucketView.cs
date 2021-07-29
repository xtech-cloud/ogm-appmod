
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketView : View
    {
        public const string NAME = "ogm.file.BucketView";

        private Facade facade = null;
        private BucketModel model = null;
        private IBucketUiBridge bridge = null;
        private BucketService service = null;

        protected override void preSetup()
        {
            model = findModel(BucketModel.NAME) as BucketModel;
            service = findService(BucketService.NAME) as BucketService;
            facade = findFacade("ogm.file.BucketFacade");
            BucketViewBridge vb = new BucketViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.BucketView");
            addRouter("/Application/Auth/Signin/Success", handleAuthSigninSuccess);
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IBucketUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.file.Bucket"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleBucketMake(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleBucketList(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketListResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleBucketRemove(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleBucketGet(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketGetResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleBucketFind(Model.Status _status, object _data)
        {
            var rsp = (Proto.BucketFindResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleBucketUpdateEngine(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleBucketUpdateCapacity(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleBucketResetToken(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if (rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }

        private void handleAuthSigninSuccess(Model.Status _status, object _data)
        {
            Dictionary<string, Any> data = (Dictionary<string, Any>)_data;
            if (data["location"].AsString().Equals("public"))
            {
                service.domain = data["host"].AsString();
                service.accessToken = data["accessToken"].AsString();
                service.uuid = data["uuid"].AsString();
                //bridge.RefreshActivateLocation(data["location"].AsString());
            }
        }

        public void RefreshBucketList(BucketModel.BucketStatus _status)
        {
            List<Dictionary<string, Any>> bucketList = new List<Dictionary<string, Any>>();
            foreach(var e in _status.entity)
            {
                Dictionary<string, Any> bucket = new Dictionary<string, Any>();
                bucketList.Add(bucket);
                bucket["accessKey"] = e._accessKey;
                bucket["accessSecret"] = e._accessSecret;
                bucket["address"] = e._address;
                bucket["engine"] = e._engine;
                bucket["name"] = e._name;
                bucket["scope"] = e._scope;
                bucket["token"] = e._token;
                bucket["totalSize"] = e._totalSize;
                bucket["usedSize"] = e._usedSize;
                bucket["uuid"] = e._uuid;
            }
            bridge.RefreshBucketList(_status.total, bucketList);
        }

    }
}
