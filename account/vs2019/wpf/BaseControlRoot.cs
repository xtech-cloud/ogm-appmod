
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.account
{
    public class BaseControlRoot
    {

        protected AuthFacade facadeAuth_ {get;set;}
        protected AuthControl controlAuth_ {get;set;}
        protected AuthControl.AuthUiBridge uiAuthBridge_  {get;set;}

        protected ProfileFacade facadeProfile_ {get;set;}
        protected ProfileControl controlProfile_ {get;set;}
        protected ProfileControl.ProfileUiBridge uiProfileBridge_  {get;set;}

        protected QueryFacade facadeQuery_ {get;set;}
        protected QueryControl controlQuery_ {get;set;}
        protected QueryControl.QueryUiBridge uiQueryBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeAuth_ = new AuthFacade();
                framework_.getStaticPipe().RegisterFacade(AuthFacade.NAME, facadeAuth_);
                controlAuth_ = new AuthControl();
                controlAuth_.facade = facadeAuth_;
                uiAuthBridge_ = new AuthControl.AuthUiBridge();
                uiAuthBridge_.control = controlAuth_;
                facadeAuth_.setUiBridge(uiAuthBridge_);

                // 注册UI装饰
                facadeProfile_ = new ProfileFacade();
                framework_.getStaticPipe().RegisterFacade(ProfileFacade.NAME, facadeProfile_);
                controlProfile_ = new ProfileControl();
                controlProfile_.facade = facadeProfile_;
                uiProfileBridge_ = new ProfileControl.ProfileUiBridge();
                uiProfileBridge_.control = controlProfile_;
                facadeProfile_.setUiBridge(uiProfileBridge_);

                // 注册UI装饰
                facadeQuery_ = new QueryFacade();
                framework_.getStaticPipe().RegisterFacade(QueryFacade.NAME, facadeQuery_);
                controlQuery_ = new QueryControl();
                controlQuery_.facade = facadeQuery_;
                uiQueryBridge_ = new QueryControl.QueryUiBridge();
                uiQueryBridge_.control = controlQuery_;
                facadeQuery_.setUiBridge(uiQueryBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(AuthFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(ProfileFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(QueryFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
