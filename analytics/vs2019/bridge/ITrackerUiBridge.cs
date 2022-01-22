
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.analytics
{
    public interface ITrackerUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveWake(string _json);
        void ReceiveRecord(string _json);

    }
}
