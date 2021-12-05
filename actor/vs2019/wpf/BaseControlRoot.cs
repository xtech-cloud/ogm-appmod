
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.actor
{
    public class BaseControlRoot
    {

        protected ApplicationFacade facadeApplication_ {get;set;}
        protected ApplicationControl controlApplication_ {get;set;}
        protected ApplicationControl.ApplicationUiBridge uiApplicationBridge_  {get;set;}

        protected DeviceFacade facadeDevice_ {get;set;}
        protected DeviceControl controlDevice_ {get;set;}
        protected DeviceControl.DeviceUiBridge uiDeviceBridge_  {get;set;}

        protected DomainFacade facadeDomain_ {get;set;}
        protected DomainControl controlDomain_ {get;set;}
        protected DomainControl.DomainUiBridge uiDomainBridge_  {get;set;}

        protected GuardFacade facadeGuard_ {get;set;}
        protected GuardControl controlGuard_ {get;set;}
        protected GuardControl.GuardUiBridge uiGuardBridge_  {get;set;}

        protected SyncFacade facadeSync_ {get;set;}
        protected SyncControl controlSync_ {get;set;}
        protected SyncControl.SyncUiBridge uiSyncBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeApplication_ = new ApplicationFacade();
                framework_.getStaticPipe().RegisterFacade(ApplicationFacade.NAME, facadeApplication_);
                controlApplication_ = new ApplicationControl();
                controlApplication_.facade = facadeApplication_;
                uiApplicationBridge_ = new ApplicationControl.ApplicationUiBridge();
                uiApplicationBridge_.control = controlApplication_;
                facadeApplication_.setUiBridge(uiApplicationBridge_);

                // 注册UI装饰
                facadeDevice_ = new DeviceFacade();
                framework_.getStaticPipe().RegisterFacade(DeviceFacade.NAME, facadeDevice_);
                controlDevice_ = new DeviceControl();
                controlDevice_.facade = facadeDevice_;
                uiDeviceBridge_ = new DeviceControl.DeviceUiBridge();
                uiDeviceBridge_.control = controlDevice_;
                facadeDevice_.setUiBridge(uiDeviceBridge_);

                // 注册UI装饰
                facadeDomain_ = new DomainFacade();
                framework_.getStaticPipe().RegisterFacade(DomainFacade.NAME, facadeDomain_);
                controlDomain_ = new DomainControl();
                controlDomain_.facade = facadeDomain_;
                uiDomainBridge_ = new DomainControl.DomainUiBridge();
                uiDomainBridge_.control = controlDomain_;
                facadeDomain_.setUiBridge(uiDomainBridge_);

                // 注册UI装饰
                facadeGuard_ = new GuardFacade();
                framework_.getStaticPipe().RegisterFacade(GuardFacade.NAME, facadeGuard_);
                controlGuard_ = new GuardControl();
                controlGuard_.facade = facadeGuard_;
                uiGuardBridge_ = new GuardControl.GuardUiBridge();
                uiGuardBridge_.control = controlGuard_;
                facadeGuard_.setUiBridge(uiGuardBridge_);

                // 注册UI装饰
                facadeSync_ = new SyncFacade();
                framework_.getStaticPipe().RegisterFacade(SyncFacade.NAME, facadeSync_);
                controlSync_ = new SyncControl();
                controlSync_.facade = facadeSync_;
                uiSyncBridge_ = new SyncControl.SyncUiBridge();
                uiSyncBridge_.control = controlSync_;
                facadeSync_.setUiBridge(uiSyncBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(ApplicationFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(DeviceFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(DomainFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(GuardFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(SyncFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
