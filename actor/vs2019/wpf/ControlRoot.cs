
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ControlRoot : BaseControlRoot
    {
        public ControlRoot()
        {
        }

        public void Register()
        {
            register();

            controlSync_.facadeApplication = facadeApplication_;
            controlSync_.facadeDomain = facadeDomain_;
            controlDomain_.controlGuard = controlGuard_;
            controlDomain_.controlSync = controlSync_;
            controlDomain_.controlApplication = controlApplication_;
        }

        public void Cancel()
        {
            cancel();
        }
    }
}
