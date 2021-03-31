using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class ModuleRoot
    {
        public ModuleRoot(Framework _framework)
        {
            framework_ = _framework;
        }

        public void Register()
        {
            // 注册数据层
            framework_.getStaticPipe().RegisterModel(BucketModel.NAME, new BucketModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(BucketView.NAME, new BucketView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(BucketController.NAME, new BucketController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(BucketService.NAME, new BucketService());
        }

        public void Cancel()
        {
            // 注销数据层
            framework_.getStaticPipe().CancelModel(BucketModel.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(BucketView.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(BucketController.NAME);
            // 注销服务层
            framework_.getStaticPipe().CancelService(BucketService.NAME);
        }

        private Framework framework_ = null; 
    }
}
