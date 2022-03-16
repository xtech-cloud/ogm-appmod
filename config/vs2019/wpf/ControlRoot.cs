
using XTC.oelMVCS;

namespace ogm.config
{
    public class ControlRoot : BaseControlRoot
    {
        public ControlRoot()
        {
        }

        public void Register()
        {
            register();
        }

        public void Cancel()
        {
            cancel();
        }
    }
}
