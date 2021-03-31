
using XTC.oelMVCS;

namespace OGM.Module.File
{
    public class FormRoot
    {
        public FormRoot(Framework _framework)
        {
            framework_ = _framework;
        }

        public void Register()
        {

            // 注册UI装饰
            BucketFacade facadeBucket = new BucketFacade();
            framework_.getStaticPipe().RegisterFacade(BucketFacade.NAME, facadeBucket);
            BucketPanel panelBucket = new BucketPanel();
            panelBucket.facade = facadeBucket;
            BucketPanel.BucketUiBridge uiBucketBridge = new BucketPanel.BucketUiBridge();
            uiBucketBridge.panel = panelBucket;
            facadeBucket.setUiBridge(uiBucketBridge);
        
            // 注册UI装饰
            ObjectFacade facadeObject = new ObjectFacade();
            framework_.getStaticPipe().RegisterFacade(ObjectFacade.NAME, facadeObject);
            ObjectPanel panelObject = new ObjectPanel();
            panelObject.facade = facadeObject;
            ObjectPanel.ObjectUiBridge uiObjectBridge = new ObjectPanel.ObjectUiBridge();
            uiObjectBridge.panel = panelObject;
            facadeObject.setUiBridge(uiObjectBridge);
        
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
