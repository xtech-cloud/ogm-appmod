
using System;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DeviceBaseController: Controller
    {

        protected DeviceView view {get;set;}

        protected override void preSetup()
        {
            view = findView(DeviceView.NAME) as DeviceView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.DeviceController");
        }
    }
}
