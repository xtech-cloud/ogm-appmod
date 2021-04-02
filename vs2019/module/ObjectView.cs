
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class ObjectView: View
    {
        public const string NAME = "File.ObjectView";

        private Facade facade = null;
        private ObjectModel model = null;
        private IObjectUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ObjectModel.NAME) as ObjectModel;
            var service = findService(ObjectService.NAME) as ObjectService;
            facade = findFacade("File.ObjectFacade");
            ObjectViewBridge vb = new ObjectViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ObjectView");

           route("/ogm/file/Object/Prepare", this.handleObjectPrepare);
    
           route("/ogm/file/Object/Flush", this.handleObjectFlush);
    
           route("/ogm/file/Object/Link", this.handleObjectLink);
    
           route("/ogm/file/Object/Get", this.handleObjectGet);
    
           route("/ogm/file/Object/Find", this.handleObjectFind);
    
           route("/ogm/file/Object/Remove", this.handleObjectRemove);
    
           route("/ogm/file/Object/List", this.handleObjectList);
    
           route("/ogm/file/Object/Search", this.handleObjectSearch);
    
           route("/ogm/file/Object/Publish", this.handleObjectPublish);
    
           route("/ogm/file/Object/Preview", this.handleObjectPreview);
    
           route("/ogm/file/Object/Retract", this.handleObjectRetract);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IObjectUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["/OGM/File/Object"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        private void handleObjectPrepare(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectPrepareResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectFlush(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectLink(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectGet(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectGetResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectFind(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectFindResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectRemove(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectList(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectListResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectSearch(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectSearchResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectPublish(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectPublishResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectPreview(Model.Status _status, object _data)
        {
            var rsp = (Proto.ObjectPreviewResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
        private void handleObjectRetract(Model.Status _status, object _data)
        {
            var rsp = (Proto.BlankResponse)_data;
            if(rsp.status.code == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp.status.code, rsp.status.message));
        }
    
    }
}
