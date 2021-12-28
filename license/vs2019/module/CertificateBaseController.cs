
using System;
using XTC.oelMVCS;

namespace ogm.license
{
    public class CertificateBaseController: Controller
    {

        protected CertificateView view {get;set;}

        protected override void preSetup()
        {
            view = findView(CertificateView.NAME) as CertificateView;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.license.CertificateController");
        }
    }
}
