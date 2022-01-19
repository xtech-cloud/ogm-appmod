
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectBaseView: View
    {
        protected Facade facade = null;
        protected ObjectModel model = null;
        protected IObjectUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ObjectModel.NAME) as ObjectModel;
            var service = findService(ObjectService.NAME) as ObjectService;
            facade = findFacade("ogm.file.ObjectFacade");
            ObjectViewBridge vb = new ObjectViewBridge();
            vb.view = this as ObjectView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.file.ObjectView");

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Prepare", this.handleReceiveObjectPrepare);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Flush", this.handleReceiveObjectFlush);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Link", this.handleReceiveObjectLink);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Get", this.handleReceiveObjectGet);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Find", this.handleReceiveObjectFind);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Remove", this.handleReceiveObjectRemove);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/List", this.handleReceiveObjectList);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Search", this.handleReceiveObjectSearch);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Publish", this.handleReceiveObjectPublish);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Preview", this.handleReceiveObjectPreview);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/Retract", this.handleReceiveObjectRetract);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/ConvertFromBase64", this.handleReceiveObjectConvertFromBase64);

            addObserver(ObjectModel.NAME, "_.reply.arrived:ogm/file/Object/ConvertFromUrl", this.handleReceiveObjectConvertFromUrl);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IObjectUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.file.Object"] = rootPanel;
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

        private void handleReceiveObjectPrepare(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectPrepareResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Prepare is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceivePrepare(json);
        }

        private void handleReceiveObjectFlush(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Flush is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveFlush(json);
        }

        private void handleReceiveObjectLink(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.BlankResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Link is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveLink(json);
        }

        private void handleReceiveObjectGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveObjectFind(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectFindResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Find is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveFind(json);
        }

        private void handleReceiveObjectRemove(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Remove is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRemove(json);
        }

        private void handleReceiveObjectList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveObjectSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectSearchResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

        private void handleReceiveObjectPublish(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectPublishResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Publish is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceivePublish(json);
        }

        private void handleReceiveObjectPreview(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectPreviewResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Preview is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceivePreview(json);
        }

        private void handleReceiveObjectRetract(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/Retract is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRetract(json);
        }

        private void handleReceiveObjectConvertFromBase64(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectConvertFromBase64Response;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/ConvertFromBase64 is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveConvertFromBase64(json);
        }

        private void handleReceiveObjectConvertFromUrl(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ObjectConvertFromUrlResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Object/ConvertFromUrl is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveConvertFromUrl(json);
        }

    }
}
