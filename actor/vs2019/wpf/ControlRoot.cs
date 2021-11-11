
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.actor
{
    public class ControlRoot
    {
        public ControlRoot()
        {
        }

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        public void Register()
        {
            // 注册UI装饰
            ApplicationFacade facadeApplication = new ApplicationFacade();
            framework_.getStaticPipe().RegisterFacade(ApplicationFacade.NAME, facadeApplication);
            ApplicationControl controlApplication = new ApplicationControl();
            controlApplication.facade = facadeApplication;
            ApplicationControl.ApplicationUiBridge uiApplicationBridge = new ApplicationControl.ApplicationUiBridge();
            uiApplicationBridge.control = controlApplication;
            facadeApplication.setUiBridge(uiApplicationBridge);

            // 注册UI装饰
            DeviceFacade facadeDevice = new DeviceFacade();
            framework_.getStaticPipe().RegisterFacade(DeviceFacade.NAME, facadeDevice);
            DeviceControl controlDevice = new DeviceControl();
            controlDevice.facade = facadeDevice;
            DeviceControl.DeviceUiBridge uiDeviceBridge = new DeviceControl.DeviceUiBridge();
            uiDeviceBridge.control = controlDevice;
            facadeDevice.setUiBridge(uiDeviceBridge);

            // 注册UI装饰
            DomainFacade facadeDomain = new DomainFacade();
            framework_.getStaticPipe().RegisterFacade(DomainFacade.NAME, facadeDomain);
            DomainControl controlDomain = new DomainControl();
            controlDomain.facade = facadeDomain;
            DomainControl.DomainUiBridge uiDomainBridge = new DomainControl.DomainUiBridge();
            uiDomainBridge.control = controlDomain;
            facadeDomain.setUiBridge(uiDomainBridge);

            // 注册UI装饰
            GuardFacade facadeGuard = new GuardFacade();
            framework_.getStaticPipe().RegisterFacade(GuardFacade.NAME, facadeGuard);
            GuardControl controlGuard = new GuardControl();
            controlGuard.facade = facadeGuard;
            GuardControl.GuardUiBridge uiGuardBridge = new GuardControl.GuardUiBridge();
            uiGuardBridge.control = controlGuard;
            facadeGuard.setUiBridge(uiGuardBridge);

            // 注册UI装饰
            SyncFacade facadeSync = new SyncFacade();
            framework_.getStaticPipe().RegisterFacade(SyncFacade.NAME, facadeSync);
            SyncControl controlSync = new SyncControl();
            controlSync.facade = facadeSync;
            SyncControl.SyncUiBridge uiSyncBridge = new SyncControl.SyncUiBridge();
            uiSyncBridge.control = controlSync;
            facadeSync.setUiBridge(uiSyncBridge);

            controlSync.facadeApplication = facadeApplication;
            controlSync.facadeDomain = facadeDomain;
            controlDomain.controlGuard = controlGuard;
            controlDomain.controlSync = controlSync;
            controlDomain.controlApplication = controlApplication;
        }

        public void Cancel()
        {

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(DeviceFacade.NAME);

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(DomainFacade.NAME);

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(GuardFacade.NAME);

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(SyncFacade.NAME);

        }

        private Framework framework_ = null;
    }
}
