
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group
{
    public class CollectionView: CollectionBaseView
    {
        public const string NAME = "ogm.group.CollectionView";

        public void OpenMemberUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.group.Member");
        }
    }
}
