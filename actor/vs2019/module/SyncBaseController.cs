
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncBaseController: Controller
    {

        protected SyncView view {get;set;}

        protected override void preSetup()
        {
            view = findView(SyncView.NAME) as SyncView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.SyncController");
        }
    }
}
