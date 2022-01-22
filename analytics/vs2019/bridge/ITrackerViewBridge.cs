
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.analytics
{
    public interface ITrackerViewBridge : View.Facade.Bridge
    {
        void OnWakeSubmit(string _json);
        void OnRecordSubmit(string _json);

    }
}
