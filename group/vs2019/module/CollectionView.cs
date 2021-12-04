
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group
{
    public class CollectionView: CollectionBaseView
    {
        public const string NAME = "ogm.group.CollectionView";

        protected override void postSetup()
        {
            base.postSetup();
            addRouter("/sidemenu/tab/activated", handleTabActivated);
        }

        public void OpenMemberUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.group.Member");
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string target = _data as string;
            if (!target.Equals("ogm.group.Collection"))
                return;
            var extendBridge = facade.getUiBridge() as ICollectionExtendUiBridge;
            extendBridge.HandleTabActivated();
        }
    }
}
