
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.permission
{
    public class BaseControlRoot
    {

        protected RuleFacade facadeRule_ {get;set;}
        protected RuleControl controlRule_ {get;set;}
        protected RuleControl.RuleUiBridge uiRuleBridge_  {get;set;}

        protected ScopeFacade facadeScope_ {get;set;}
        protected ScopeControl controlScope_ {get;set;}
        protected ScopeControl.ScopeUiBridge uiScopeBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeRule_ = new RuleFacade();
                framework_.getStaticPipe().RegisterFacade(RuleFacade.NAME, facadeRule_);
                controlRule_ = new RuleControl();
                controlRule_.facade = facadeRule_;
                uiRuleBridge_ = new RuleControl.RuleUiBridge();
                uiRuleBridge_.control = controlRule_;
                facadeRule_.setUiBridge(uiRuleBridge_);

                // 注册UI装饰
                facadeScope_ = new ScopeFacade();
                framework_.getStaticPipe().RegisterFacade(ScopeFacade.NAME, facadeScope_);
                controlScope_ = new ScopeControl();
                controlScope_.facade = facadeScope_;
                uiScopeBridge_ = new ScopeControl.ScopeUiBridge();
                uiScopeBridge_.control = controlScope_;
                facadeScope_.setUiBridge(uiScopeBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(RuleFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(ScopeFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
