
using XTC.oelMVCS;

namespace ogm.permission
{
    public class ControlRoot : BaseControlRoot
    {
        public ControlRoot()
        {
        }

        public void Register()
        {
            register();

            controlScope_.controlRule = controlRule_;
        }

        public void Cancel()
        {
            cancel();
        }
    }
}
