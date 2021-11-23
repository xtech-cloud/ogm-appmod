
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.group
{
    public class BaseControlRoot
    {

        protected CollectionFacade facadeCollection_ {get;set;}
        protected CollectionControl controlCollection_ {get;set;}
        protected CollectionControl.CollectionUiBridge uiCollectionBridge_  {get;set;}

        protected MemberFacade facadeMember_ {get;set;}
        protected MemberControl controlMember_ {get;set;}
        protected MemberControl.MemberUiBridge uiMemberBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeCollection_ = new CollectionFacade();
                framework_.getStaticPipe().RegisterFacade(CollectionFacade.NAME, facadeCollection_);
                controlCollection_ = new CollectionControl();
                controlCollection_.facade = facadeCollection_;
                uiCollectionBridge_ = new CollectionControl.CollectionUiBridge();
                uiCollectionBridge_.control = controlCollection_;
                facadeCollection_.setUiBridge(uiCollectionBridge_);

                // 注册UI装饰
                facadeMember_ = new MemberFacade();
                framework_.getStaticPipe().RegisterFacade(MemberFacade.NAME, facadeMember_);
                controlMember_ = new MemberControl();
                controlMember_.facade = facadeMember_;
                uiMemberBridge_ = new MemberControl.MemberUiBridge();
                uiMemberBridge_.control = controlMember_;
                facadeMember_.setUiBridge(uiMemberBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(CollectionFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(MemberFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
