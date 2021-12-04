
using XTC.oelMVCS;

namespace ogm.file
{
    public class ControlRoot : BaseControlRoot
    {
        public ControlRoot()
        {
        }

        public void Register()
        {
            register();

            controlBucket_.controlObject= controlObject_;
        }

        public void Cancel()
        {
            cancel();
        }
    }
}
