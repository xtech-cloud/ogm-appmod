
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.config
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
                framework_.getStaticPipe().RegisterModel(TextModel.NAME, new TextModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(TextView.NAME, new TextView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(TextController.NAME, new TextController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(TextService.NAME, new TextService());

        }

        public void Cancel()
        {

                // 注销服务层
                framework_.getStaticPipe().CancelService(TextService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(TextController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(TextView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(TextModel.NAME);

        }

        private Framework framework_ = null;
    }
}
