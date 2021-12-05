
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainView : DomainBaseView
    {
        public const string NAME = "ogm.actor.DomainView";

        protected override void postSetup()
        {
            base.postSetup();
            addRouter("/sidemenu/tab/activated", handleTabActivated);
        }

        public void OpenGuardUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.actor.Guard");
        }

        public void OpenSyncUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.actor.Sync");
        }

        public void OpenApplicationUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.actor.Application");
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string target = _data as string;
            if (!target.Equals("ogm.actor.Domain"))
                return;
            var extendBridge = facade.getUiBridge() as IDomainExtendUiBridge;
            extendBridge.HandleTabActivated();
        }
    }
}
