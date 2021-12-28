
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.license
{
    public class BaseControlRoot
    {

        protected CertificateFacade facadeCertificate_ {get;set;}
        protected CertificateControl controlCertificate_ {get;set;}
        protected CertificateControl.CertificateUiBridge uiCertificateBridge_  {get;set;}

        protected KeyFacade facadeKey_ {get;set;}
        protected KeyControl controlKey_ {get;set;}
        protected KeyControl.KeyUiBridge uiKeyBridge_  {get;set;}

        protected SpaceFacade facadeSpace_ {get;set;}
        protected SpaceControl controlSpace_ {get;set;}
        protected SpaceControl.SpaceUiBridge uiSpaceBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeCertificate_ = new CertificateFacade();
                framework_.getStaticPipe().RegisterFacade(CertificateFacade.NAME, facadeCertificate_);
                controlCertificate_ = new CertificateControl();
                controlCertificate_.facade = facadeCertificate_;
                uiCertificateBridge_ = new CertificateControl.CertificateUiBridge();
                uiCertificateBridge_.control = controlCertificate_;
                facadeCertificate_.setUiBridge(uiCertificateBridge_);

                // 注册UI装饰
                facadeKey_ = new KeyFacade();
                framework_.getStaticPipe().RegisterFacade(KeyFacade.NAME, facadeKey_);
                controlKey_ = new KeyControl();
                controlKey_.facade = facadeKey_;
                uiKeyBridge_ = new KeyControl.KeyUiBridge();
                uiKeyBridge_.control = controlKey_;
                facadeKey_.setUiBridge(uiKeyBridge_);

                // 注册UI装饰
                facadeSpace_ = new SpaceFacade();
                framework_.getStaticPipe().RegisterFacade(SpaceFacade.NAME, facadeSpace_);
                controlSpace_ = new SpaceControl();
                controlSpace_.facade = facadeSpace_;
                uiSpaceBridge_ = new SpaceControl.SpaceUiBridge();
                uiSpaceBridge_.control = controlSpace_;
                facadeSpace_.setUiBridge(uiSpaceBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(CertificateFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(KeyFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(SpaceFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
