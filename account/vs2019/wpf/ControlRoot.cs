
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.account
{
    public class ControlRoot
    {
        public ControlRoot()
        {
        }

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        public void Register()
        {

            // 注册UI装饰
            AuthFacade facadeAuth = new AuthFacade();
            framework_.getStaticPipe().RegisterFacade(AuthFacade.NAME, facadeAuth);
            AuthControl controlAuth = new AuthControl();
            controlAuth.facade = facadeAuth;
            AuthControl.AuthUiBridge uiAuthBridge = new AuthControl.AuthUiBridge();
            uiAuthBridge.control = controlAuth;
            facadeAuth.setUiBridge(uiAuthBridge);
        
            // 注册UI装饰
            ProfileFacade facadeProfile = new ProfileFacade();
            framework_.getStaticPipe().RegisterFacade(ProfileFacade.NAME, facadeProfile);
            ProfileControl controlProfile = new ProfileControl();
            controlProfile.facade = facadeProfile;
            ProfileControl.ProfileUiBridge uiProfileBridge = new ProfileControl.ProfileUiBridge();
            uiProfileBridge.control = controlProfile;
            facadeProfile.setUiBridge(uiProfileBridge);
        
            // 注册UI装饰
            QueryFacade facadeQuery = new QueryFacade();
            framework_.getStaticPipe().RegisterFacade(QueryFacade.NAME, facadeQuery);
            QueryControl controlQuery = new QueryControl();
            controlQuery.facade = facadeQuery;
            QueryControl.QueryUiBridge uiQueryBridge = new QueryControl.QueryUiBridge();
            uiQueryBridge.control = controlQuery;
            facadeQuery.setUiBridge(uiQueryBridge);
        
        }

        public void Cancel()
        {

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(AuthFacade.NAME);
        
            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(ProfileFacade.NAME);
        
            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(QueryFacade.NAME);
        
        }

        private Framework framework_ = null;
    }
}
