
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.config
{
    public class BaseControlRoot
    {

        protected TextFacade facadeText_ {get;set;}
        protected TextControl controlText_ {get;set;}
        protected TextControl.TextUiBridge uiTextBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeText_ = new TextFacade();
                framework_.getStaticPipe().RegisterFacade(TextFacade.NAME, facadeText_);
                controlText_ = new TextControl();
                controlText_.facade = facadeText_;
                uiTextBridge_ = new TextControl.TextUiBridge();
                uiTextBridge_.control = controlText_;
                facadeText_.setUiBridge(uiTextBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(TextFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
