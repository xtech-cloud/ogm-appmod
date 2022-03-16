
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.config
{
    public class TextBaseView: View
    {
        protected Facade facade = null;
        protected TextModel model = null;
        protected ITextUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(TextModel.NAME) as TextModel;
            var service = findService(TextService.NAME) as TextService;
            facade = findFacade("ogm.config.TextFacade");
            TextViewBridge vb = new TextViewBridge();
            vb.view = this as TextView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.config.TextView");

            addObserver(TextModel.NAME, "_.reply.arrived:ogm/config/Text/Write", this.handleReceiveTextWrite);

            addObserver(TextModel.NAME, "_.reply.arrived:ogm/config/Text/Read", this.handleReceiveTextRead);

            addObserver(TextModel.NAME, "_.reply.arrived:ogm/config/Text/Delete", this.handleReceiveTextDelete);

            addObserver(TextModel.NAME, "_.reply.arrived:ogm/config/Text/Get", this.handleReceiveTextGet);

            addObserver(TextModel.NAME, "_.reply.arrived:ogm/config/Text/List", this.handleReceiveTextList);

            addObserver(TextModel.NAME, "_.reply.arrived:ogm/config/Text/Search", this.handleReceiveTextSearch);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as ITextUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.config.Text"] = rootPanel;
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

        private void handleReceiveTextWrite(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Text/Write is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveWrite(json);
        }

        private void handleReceiveTextRead(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.TextReadResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Text/Read is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRead(json);
        }

        private void handleReceiveTextDelete(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Text/Delete is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveDelete(json);
        }

        private void handleReceiveTextGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.TextGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Text/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveTextList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.TextListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Text/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveTextSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.TextSearchResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Text/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

    }
}
