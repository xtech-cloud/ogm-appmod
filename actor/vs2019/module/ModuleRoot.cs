
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ModuleRoot
    {
        public ModuleRoot()
        {
        }

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        public void Register()
        {

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(ApplicationModel.NAME, new ApplicationModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(ApplicationView.NAME, new ApplicationView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(ApplicationController.NAME, new ApplicationController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(ApplicationService.NAME, new ApplicationService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(DeviceModel.NAME, new DeviceModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(DeviceView.NAME, new DeviceView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(DeviceController.NAME, new DeviceController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(DeviceService.NAME, new DeviceService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(DomainModel.NAME, new DomainModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(DomainView.NAME, new DomainView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(DomainController.NAME, new DomainController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(DomainService.NAME, new DomainService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(GuardModel.NAME, new GuardModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(GuardView.NAME, new GuardView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(GuardController.NAME, new GuardController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(GuardService.NAME, new GuardService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(SyncModel.NAME, new SyncModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(SyncView.NAME, new SyncView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(SyncController.NAME, new SyncController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(SyncService.NAME, new SyncService());

        }

        public void Cancel()
        {

                // 注销服务层
                framework_.getStaticPipe().CancelService(ApplicationService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(ApplicationController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(ApplicationView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(ApplicationModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(DeviceService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(DeviceController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(DeviceView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(DeviceModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(DomainService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(DomainController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(DomainView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(DomainModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(GuardService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(GuardController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(GuardView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(GuardModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(SyncService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(SyncController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(SyncView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(SyncModel.NAME);

        }

        private Framework framework_ = null;
    }
}
