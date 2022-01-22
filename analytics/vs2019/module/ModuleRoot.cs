
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.analytics
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
                framework_.getStaticPipe().RegisterModel(GeneratorModel.NAME, new GeneratorModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(GeneratorView.NAME, new GeneratorView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(GeneratorController.NAME, new GeneratorController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(GeneratorService.NAME, new GeneratorService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(TrackerModel.NAME, new TrackerModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(TrackerView.NAME, new TrackerView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(TrackerController.NAME, new TrackerController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(TrackerService.NAME, new TrackerService());

        }

        public void Cancel()
        {

                // 注销服务层
                framework_.getStaticPipe().CancelService(GeneratorService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(GeneratorController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(GeneratorView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(GeneratorModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(TrackerService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(TrackerController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(TrackerView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(TrackerModel.NAME);

        }

        private Framework framework_ = null;
    }
}
