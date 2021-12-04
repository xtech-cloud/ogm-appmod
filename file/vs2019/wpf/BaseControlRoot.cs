
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.file
{
    public class BaseControlRoot
    {

        protected BucketFacade facadeBucket_ {get;set;}
        protected BucketControl controlBucket_ {get;set;}
        protected BucketControl.BucketUiBridge uiBucketBridge_  {get;set;}

        protected ObjectFacade facadeObject_ {get;set;}
        protected ObjectControl controlObject_ {get;set;}
        protected ObjectControl.ObjectUiBridge uiObjectBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeBucket_ = new BucketFacade();
                framework_.getStaticPipe().RegisterFacade(BucketFacade.NAME, facadeBucket_);
                controlBucket_ = new BucketControl();
                controlBucket_.facade = facadeBucket_;
                uiBucketBridge_ = new BucketControl.BucketUiBridge();
                uiBucketBridge_.control = controlBucket_;
                facadeBucket_.setUiBridge(uiBucketBridge_);

                // 注册UI装饰
                facadeObject_ = new ObjectFacade();
                framework_.getStaticPipe().RegisterFacade(ObjectFacade.NAME, facadeObject_);
                controlObject_ = new ObjectControl();
                controlObject_.facade = facadeObject_;
                uiObjectBridge_ = new ObjectControl.ObjectUiBridge();
                uiObjectBridge_.control = controlObject_;
                facadeObject_.setUiBridge(uiObjectBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(BucketFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(ObjectFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
