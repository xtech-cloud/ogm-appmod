
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.file
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
            BucketFacade facadeBucket = new BucketFacade();
            framework_.getStaticPipe().RegisterFacade(BucketFacade.NAME, facadeBucket);
            BucketControl controlBucket = new BucketControl();
            controlBucket.facade = facadeBucket;
            BucketControl.BucketUiBridge uiBucketBridge = new BucketControl.BucketUiBridge();
            uiBucketBridge.control = controlBucket;
            facadeBucket.setUiBridge(uiBucketBridge);
        
            // 注册UI装饰
            ObjectFacade facadeObject = new ObjectFacade();
            framework_.getStaticPipe().RegisterFacade(ObjectFacade.NAME, facadeObject);
            ObjectControl controlObject = new ObjectControl();
            controlObject.facade = facadeObject;
            ObjectControl.ObjectUiBridge uiObjectBridge = new ObjectControl.ObjectUiBridge();
            uiObjectBridge.control = controlObject;
            facadeObject.setUiBridge(uiObjectBridge);
        
            controlBucket.controlObject= controlObject;
        }

        public void Cancel()
        {

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(BucketFacade.NAME);
        
            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(ObjectFacade.NAME);
        
        }

        private Framework framework_ = null;
    }
}
