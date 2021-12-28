
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license
{
    public class CertificateBaseView: View
    {
        protected Facade facade = null;
        protected CertificateModel model = null;
        protected ICertificateUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(CertificateModel.NAME) as CertificateModel;
            var service = findService(CertificateService.NAME) as CertificateService;
            facade = findFacade("ogm.license.CertificateFacade");
            CertificateViewBridge vb = new CertificateViewBridge();
            vb.view = this as CertificateView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.CertificateView");

            addObserver(CertificateModel.NAME, "_.reply.arrived:ogm/license/Certificate/Get", this.handleReceiveCertificateGet);

            addObserver(CertificateModel.NAME, "_.reply.arrived:ogm/license/Certificate/List", this.handleReceiveCertificateList);

            addObserver(CertificateModel.NAME, "_.reply.arrived:ogm/license/Certificate/Search", this.handleReceiveCertificateSearch);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as ICertificateUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.license.Certificate"] = rootPanel;
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

        private void handleReceiveCertificateGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.CerGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Certificate/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

        private void handleReceiveCertificateList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.CerListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Certificate/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveCertificateSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.CerListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Certificate/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

    }
}
