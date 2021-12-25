
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class ScopeViewBridge : ScopeBaseViewBridge, IScopeExtendViewBridge
    {
        public void OnOpenRuleUi()
        {
            view.OpenRuleUi();
        }
    }
}
