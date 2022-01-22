
using System;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class TrackerBaseController: Controller
    {

        protected TrackerView view {get;set;}

        protected override void preSetup()
        {
            view = findView(TrackerView.NAME) as TrackerView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.analytics.TrackerController");
        }
    }
}
