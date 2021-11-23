
using System;
using XTC.oelMVCS;

namespace ogm.group
{
    public class MemberBaseController: Controller
    {

        protected MemberView view {get;set;}

        protected override void preSetup()
        {
            view = findView(MemberView.NAME) as MemberView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.MemberController");
        }
    }
}
