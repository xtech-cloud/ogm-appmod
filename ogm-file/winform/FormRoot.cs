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
            BucketFacade bucketFacade = new BucketFacade();
            framework_.getStaticPipe().RegisterFacade(BucketFacade.NAME, bucketFacade);

            BucketPanel panel = new BucketPanel();
            panel.facade = bucketFacade;
            BucketPanel.BucketUiBridge uiBridge = new BucketPanel.BucketUiBridge();
            uiBridge.panel = panel;
            bucketFacade.setUiBridge(uiBridge);
        }

        public void Cancel()
        {
            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(BucketFacade.NAME);
        }

        private Framework framework_ = null;
    }
}
