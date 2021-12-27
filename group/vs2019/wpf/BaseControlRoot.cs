
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

        protected ElementFacade facadeElement_ {get;set;}
        protected ElementControl controlElement_ {get;set;}
        protected ElementControl.ElementUiBridge uiElementBridge_  {get;set;}

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
                facadeElement_ = new ElementFacade();
                framework_.getStaticPipe().RegisterFacade(ElementFacade.NAME, facadeElement_);
                controlElement_ = new ElementControl();
                controlElement_.facade = facadeElement_;
                uiElementBridge_ = new ElementControl.ElementUiBridge();
                uiElementBridge_.control = controlElement_;
                facadeElement_.setUiBridge(uiElementBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(CollectionFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(ElementFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
