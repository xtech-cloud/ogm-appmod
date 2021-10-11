
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
            framework_.getStaticPipe().RegisterModel(MyHealthyModel.NAME, new MyHealthyModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(MyHealthyView.NAME, new MyHealthyView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(MyHealthyController.NAME, new MyHealthyController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(MyHealthyService.NAME, new MyHealthyService());
    
        }

        public void Cancel()
        {

            // 注销服务层
            framework_.getStaticPipe().CancelService(MyHealthyService.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(MyHealthyController.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(MyHealthyView.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(MyHealthyModel.NAME);
    
        }

        private Framework framework_ = null;
    }
}
