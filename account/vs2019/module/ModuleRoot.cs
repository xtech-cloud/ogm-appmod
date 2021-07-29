
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
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
            framework_.getStaticPipe().RegisterModel(AuthModel.NAME, new AuthModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(AuthView.NAME, new AuthView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(AuthController.NAME, new AuthController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(AuthService.NAME, new AuthService());
    
            // 注册数据层
            framework_.getStaticPipe().RegisterModel(ProfileModel.NAME, new ProfileModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(ProfileView.NAME, new ProfileView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(ProfileController.NAME, new ProfileController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(ProfileService.NAME, new ProfileService());
    
            // 注册数据层
            framework_.getStaticPipe().RegisterModel(QueryModel.NAME, new QueryModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(QueryView.NAME, new QueryView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(QueryController.NAME, new QueryController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(QueryService.NAME, new QueryService());
    
        }

        public void Cancel()
        {

            // 注销服务层
            framework_.getStaticPipe().CancelService(AuthService.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(AuthController.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(AuthView.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(AuthModel.NAME);
    
            // 注销服务层
            framework_.getStaticPipe().CancelService(ProfileService.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(ProfileController.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(ProfileView.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(ProfileModel.NAME);
    
            // 注销服务层
            framework_.getStaticPipe().CancelService(QueryService.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(QueryController.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(QueryView.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(QueryModel.NAME);
    
        }

        private Framework framework_ = null;
    }
}
