
using System.Collections.Generic;
using XTC.oelMVCS;

namespace OGM.Module.File
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
            framework_.getStaticPipe().RegisterModel(BucketModel.NAME, new BucketModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(BucketView.NAME, new BucketView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(BucketController.NAME, new BucketController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(BucketService.NAME, new BucketService());
    
            // 注册数据层
            framework_.getStaticPipe().RegisterModel(ObjectModel.NAME, new ObjectModel());
            // 注册视图层
            framework_.getStaticPipe().RegisterView(ObjectView.NAME, new ObjectView());
            // 注册控制层
            framework_.getStaticPipe().RegisterController(ObjectController.NAME, new ObjectController());
            // 注册服务层
            framework_.getStaticPipe().RegisterService(ObjectService.NAME, new ObjectService());
    
        }

        public void Cancel()
        {

            // 注销服务层
            framework_.getStaticPipe().CancelService(BucketService.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(BucketController.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(BucketView.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(BucketModel.NAME);
    
            // 注销服务层
            framework_.getStaticPipe().CancelService(ObjectService.NAME);
            // 注销控制层
            framework_.getStaticPipe().CancelController(ObjectController.NAME);
            // 注销视图层
            framework_.getStaticPipe().CancelView(ObjectView.NAME);
            // 注销数据层
            framework_.getStaticPipe().CancelModel(ObjectModel.NAME);
    
        }

        private Framework framework_ = null;
    }
}
