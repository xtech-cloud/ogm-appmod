
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
                framework_.getStaticPipe().RegisterModel(MemberModel.NAME, new MemberModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(MemberView.NAME, new MemberView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(MemberController.NAME, new MemberController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(MemberService.NAME, new MemberService());

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
                framework_.getStaticPipe().CancelService(MemberService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(MemberController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(MemberView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(MemberModel.NAME);

        }

        private Framework framework_ = null;
    }
}
