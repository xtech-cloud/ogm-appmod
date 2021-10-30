
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
            HealthyFacade facadeHealthy = new HealthyFacade();
            framework_.getStaticPipe().RegisterFacade(HealthyFacade.NAME, facadeHealthy);
            HealthyControl controlHealthy = new HealthyControl();
            controlHealthy.facade = facadeHealthy;
            HealthyControl.HealthyUiBridge uiHealthyBridge = new HealthyControl.HealthyUiBridge();
            uiHealthyBridge.control = controlHealthy;
            facadeHealthy.setUiBridge(uiHealthyBridge);
        
        }

        public void Cancel()
        {

            // 注销UI装饰
            framework_.getStaticPipe().CancelFacade(HealthyFacade.NAME);
        
        }

        private Framework framework_ = null;
    }
}
