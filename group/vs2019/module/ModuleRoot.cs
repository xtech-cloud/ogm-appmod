
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group
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
                framework_.getStaticPipe().RegisterModel(CollectionModel.NAME, new CollectionModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(CollectionView.NAME, new CollectionView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(CollectionController.NAME, new CollectionController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(CollectionService.NAME, new CollectionService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(ElementModel.NAME, new ElementModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(ElementView.NAME, new ElementView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(ElementController.NAME, new ElementController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(ElementService.NAME, new ElementService());

        }

        public void Cancel()
        {

                // 注销服务层
                framework_.getStaticPipe().CancelService(CollectionService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(CollectionController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(CollectionView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(CollectionModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(ElementService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(ElementController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(ElementView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(ElementModel.NAME);

        }

        private Framework framework_ = null;
    }
}
