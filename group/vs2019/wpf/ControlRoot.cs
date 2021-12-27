
using XTC.oelMVCS;

namespace ogm.group
{
    public class ControlRoot : BaseControlRoot
    {
        public ControlRoot()
        {
        }

        public void Register()
        {
            register();

            controlCollection_.controlElement = controlElement_;
        }

        public void Cancel()
        {
            cancel();
        }
    }
}
