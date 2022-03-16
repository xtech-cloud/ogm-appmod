
using System;
using XTC.oelMVCS;

namespace ogm.config
{
    public class TextBaseController: Controller
    {

        protected TextView view {get;set;}

        protected override void preSetup()
        {
            view = findView(TextView.NAME) as TextView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.config.TextController");
        }
    }
}
