
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.startkit
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
            framework_.getStaticPipe().RegisterModel(HealthyModel.NAME, new HealthyModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(HealthyView.NAME, new HealthyView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(HealthyController.NAME, new HealthyController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(HealthyService.NAME, new HealthyService());
    
        }

        public void Cancel()
        {

            // 注销服务层
            framework_.getStaticPipe().CancelService(HealthyService.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(HealthyController.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(HealthyView.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(HealthyModel.NAME);
    
        }

        private Framework framework_ = null;
    }
}
