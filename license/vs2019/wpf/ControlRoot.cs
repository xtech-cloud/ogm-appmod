
using XTC.oelMVCS;

namespace ogm.license
{
    public class ControlRoot : BaseControlRoot
    {
        public ControlRoot()
        {
        }

        public void Register()
        {
            register();
            controlSpace_.controlKey = controlKey_;
            controlSpace_.controlCertificate = controlCertificate_;
        }

        public void Cancel()
        {
            cancel();
        }
    }
}
