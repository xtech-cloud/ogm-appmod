
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.startkit
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
            MyHealthyFacade facadeMyHealthy = new MyHealthyFacade();
            framework_.getStaticPipe().RegisterFacade(MyHealthyFacade.NAME, facadeMyHealthy);
            MyHealthyControl controlMyHealthy = new MyHealthyControl();
            controlMyHealthy.facade = facadeMyHealthy;
            MyHealthyControl.MyHealthyUiBridge uiMyHealthyBridge = new MyHealthyControl.MyHealthyUiBridge();
            uiMyHealthyBridge.control = controlMyHealthy;
            facadeMyHealthy.setUiBridge(uiMyHealthyBridge);
        
        }

        public void Cancel()
        {

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(MyHealthyFacade.NAME);
        
        }

        private Framework framework_ = null;
    }
}
