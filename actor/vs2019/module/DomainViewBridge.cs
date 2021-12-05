
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainViewBridge : DomainBaseViewBridge, IDomainExtendViewBridge
    {
        public void OnOpenApplicationUi()
        {
            view.OpenApplicationUi();
        }

        public void OnOpenGuardUi()
        {
            view.OpenGuardUi();
        }

        public void OnOpenSyncUi()
        {
            view.OpenSyncUi();
        }
    }
}
