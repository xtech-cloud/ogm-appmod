
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.license
{
    public class SpaceViewBridge : SpaceBaseViewBridge, ISpaceExtendViewBridge
    {
        public void OnOpenCertificateUi()
        {
            view.OpenCertificateUi();
        }

        public void OnOpenKeyUi()
        {
            view.OpenKeyUi();
        }
    }
}
