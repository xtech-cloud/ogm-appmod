
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.group
{
    public class CollectionViewBridge : CollectionBaseViewBridge, ICollectionExtendViewBridge
    {
        public void OnOpenMemberUi()
        {
            view.OpenMemberUi();
        }
    }
}
