
using XTC.oelMVCS;

namespace wpf
{
}

namespace ogm.analytics
{
    public class BaseControlRoot
    {

        protected GeneratorFacade facadeGenerator_ {get;set;}
        protected GeneratorControl controlGenerator_ {get;set;}
        protected GeneratorControl.GeneratorUiBridge uiGeneratorBridge_  {get;set;}

        protected TrackerFacade facadeTracker_ {get;set;}
        protected TrackerControl controlTracker_ {get;set;}
        protected TrackerControl.TrackerUiBridge uiTrackerBridge_  {get;set;}

        public void Inject(Framework _framework)
        {
            framework_ = _framework;
        }

        protected void register()
        {

                // 注册UI装饰
                facadeGenerator_ = new GeneratorFacade();
                framework_.getStaticPipe().RegisterFacade(GeneratorFacade.NAME, facadeGenerator_);
                controlGenerator_ = new GeneratorControl();
                controlGenerator_.facade = facadeGenerator_;
                uiGeneratorBridge_ = new GeneratorControl.GeneratorUiBridge();
                uiGeneratorBridge_.control = controlGenerator_;
                facadeGenerator_.setUiBridge(uiGeneratorBridge_);

                // 注册UI装饰
                facadeTracker_ = new TrackerFacade();
                framework_.getStaticPipe().RegisterFacade(TrackerFacade.NAME, facadeTracker_);
                controlTracker_ = new TrackerControl();
                controlTracker_.facade = facadeTracker_;
                uiTrackerBridge_ = new TrackerControl.TrackerUiBridge();
                uiTrackerBridge_.control = controlTracker_;
                facadeTracker_.setUiBridge(uiTrackerBridge_);

        }

        protected void cancel()
        {

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(GeneratorFacade.NAME);

                // 注销UI装饰
                framework_.getStaticPipe().CancelFacade(TrackerFacade.NAME);

        }

        protected Framework framework_ = null;
    }
}
