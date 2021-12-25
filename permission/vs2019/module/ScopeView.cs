
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class ScopeView : ScopeBaseView
    {
        public const string NAME = "ogm.permission.ScopeView";

        protected override void postSetup()
        {
            base.postSetup();
            addRouter("/sidemenu/tab/activated", handleTabActivated);
        }

        public void OpenRuleUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.permission.Rule");
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string target = _data as string;
            if (!target.Equals("ogm.permission.Scope"))
                return;
            var extendBridge = facade.getUiBridge() as IScopeExtendUiBridge;
            extendBridge.HandleTabActivated();
        }

    }
}
