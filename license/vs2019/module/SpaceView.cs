
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license
{
    public class SpaceView : SpaceBaseView
    {
        public const string NAME = "ogm.license.SpaceView";

        protected override void postSetup()
        {
            base.postSetup();
            addRouter("/sidemenu/tab/activated", handleTabActivated);
        }

        public void OpenKeyUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.license.Key");
        }

        public void OpenCertificateUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.license.Certificate");
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string target = _data as string;
            if (!target.Equals("ogm.actor.Domain"))
                return;
            var extendBridge = facade.getUiBridge() as ISpaceExtendUiBridge;
            extendBridge.HandleTabActivated();
        }

    }
}
