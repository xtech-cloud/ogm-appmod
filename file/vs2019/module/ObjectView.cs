
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectView: View
    {
        public const string NAME = "ogm.file.ObjectView";

        private Facade facade = null;
        private ObjectModel model = null;
        private IObjectUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ObjectModel.NAME) as ObjectModel;
            var service = findService(ObjectService.NAME) as ObjectService;
            facade = findFacade("ogm.file.ObjectFacade");
            ObjectViewBridge vb = new ObjectViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.ObjectView");

           addRouter("/ogm/file/Object/Prepare", this.handleObjectPrepare);
    
           addRouter("/ogm/file/Object/Flush", this.handleObjectFlush);
    
           addRouter("/ogm/file/Object/Link", this.handleObjectLink);
    
           addRouter("/ogm/file/Object/Get", this.handleObjectGet);
    
           addRouter("/ogm/file/Object/Find", this.handleObjectFind);
    
           addRouter("/ogm/file/Object/Remove", this.handleObjectRemove);
    
           addRouter("/ogm/file/Object/List", this.handleObjectList);
    
           addRouter("/ogm/file/Object/Search", this.handleObjectSearch);
    
           addRouter("/ogm/file/Object/Publish", this.handleObjectPublish);
    
           addRouter("/ogm/file/Object/Preview", this.handleObjectPreview);
    
           addRouter("/ogm/file/Object/Retract", this.handleObjectRetract);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IObjectUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.file.Object"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleObjectPrepare(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectPrepareResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectFlush(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectLink(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectGet(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectGetResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectFind(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectFindResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectRemove(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectList(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectListResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectSearch(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectSearchResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectPublish(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectPublishResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectPreview(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectPreviewResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleObjectRetract(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}