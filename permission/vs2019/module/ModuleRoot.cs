
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.permission
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
                framework_.getStaticPipe().RegisterModel(RuleModel.NAME, new RuleModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(RuleView.NAME, new RuleView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(RuleController.NAME, new RuleController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(RuleService.NAME, new RuleService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(ScopeModel.NAME, new ScopeModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(ScopeView.NAME, new ScopeView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(ScopeController.NAME, new ScopeController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(ScopeService.NAME, new ScopeService());

        }

        public void Cancel()
        {

                // 注销服务层
                framework_.getStaticPipe().CancelService(RuleService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(RuleController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(RuleView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(RuleModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(ScopeService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(ScopeController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(ScopeView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(ScopeModel.NAME);

        }

        private Framework framework_ = null;
    }
}
