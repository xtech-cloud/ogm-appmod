
using System.Collections.Generic;
using XTC.oelMVCS;

namespace app
{
    class AppView : View
    {
        public const string NAME = "AppView";

        private AppFacade appFacade = null;

        protected override void preSetup()
        {
            appFacade = findFacade(AppFacade.NAME) as AppFacade;
        }

        protected override void setup()
        {
            route("/module/view/attach", this.handleAttachView);
        }

        private void handleAttachView(Model.Status _status, object _data)
        {
            getLogger().Trace("attach view");
            Dictionary<string, object> data = _data as Dictionary<string, object>;
            foreach(string path in data.Keys)
            {
                appFacade.rootForm.AddPath(path, data[path]);
            }
        }
    }//class
}//namespace
