
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class ProfileView: View
    {
        public const string NAME = "ogm.account.ProfileView";

        private Facade facade = null;
        private ProfileModel model = null;
        private IProfileUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(ProfileModel.NAME) as ProfileModel;
            var service = findService(ProfileService.NAME) as ProfileService;
            facade = findFacade("ogm.account.ProfileFacade");
            ProfileViewBridge vb = new ProfileViewBridge();
            vb.view = this;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.account.ProfileView");

           addRouter("/ogm/account/Profile/Query", this.handleProfileQuery);
    
           addRouter("/ogm/account/Profile/Update", this.handleProfileUpdate);
    
        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as IProfileUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.account.Profile"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
        }

        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleProfileQuery(Model.Status _status, object _data)
        {
            var rsp = (Proto.QueryProfileResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
        private void handleProfileUpdate(Model.Status _status, object _data)
        {
            var rsp = (Proto.UpdateProfileResponse)_data;
            if(rsp._status._code.AsInt32() == 0)
                bridge.Alert("Success");
            else
                bridge.Alert(string.Format("Failure：\n\nCode: {0}\nMessage:\n{1}", rsp._status._code.AsInt32(), rsp._status._message.AsString()));
        }
    
    }
}
