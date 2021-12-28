
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.license
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
                framework_.getStaticPipe().RegisterModel(CertificateModel.NAME, new CertificateModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(CertificateView.NAME, new CertificateView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(CertificateController.NAME, new CertificateController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(CertificateService.NAME, new CertificateService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(KeyModel.NAME, new KeyModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(KeyView.NAME, new KeyView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(KeyController.NAME, new KeyController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(KeyService.NAME, new KeyService());

                // 注册数据层
                framework_.getStaticPipe().RegisterModel(SpaceModel.NAME, new SpaceModel());
                // 注册视图层
                framework_.getStaticPipe().RegisterView(SpaceView.NAME, new SpaceView());
                // 注册控制层
                framework_.getStaticPipe().RegisterController(SpaceController.NAME, new SpaceController());
                // 注册服务层
                framework_.getStaticPipe().RegisterService(SpaceService.NAME, new SpaceService());

        }

        public void Cancel()
        {

                // 注销服务层
                framework_.getStaticPipe().CancelService(CertificateService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(CertificateController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(CertificateView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(CertificateModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(KeyService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(KeyController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(KeyView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(KeyModel.NAME);

                // 注销服务层
                framework_.getStaticPipe().CancelService(SpaceService.NAME);
                // 注销控制层
                framework_.getStaticPipe().CancelController(SpaceController.NAME);
                // 注销视图层
                framework_.getStaticPipe().CancelView(SpaceView.NAME);
                // 注销数据层
                framework_.getStaticPipe().CancelModel(SpaceModel.NAME);

        }

        private Framework framework_ = null;
    }
}
