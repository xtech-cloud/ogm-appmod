
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryView: QueryBaseView
    {
        public const string NAME = "ogm.account.QueryView";

        protected override void postSetup()
        {
            base.postSetup();
            addRouter("/sidemenu/tab/activated", handleTabActivated);
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string target = _data as string;
            if (!target.Equals("ogm.account.Query"))
                return;
            var extendBridge = facade.getUiBridge() as IQueryExtendUiBridge;
            extendBridge.HandleTabActivated();
        }
    }
}
