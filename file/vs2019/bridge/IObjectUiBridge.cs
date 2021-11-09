
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IObjectUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string, string> _permission);

        void receivePrepare(string _json);
        void receiveFlush(string _json);
        void receiveList(string _json);
        void receivePublish(string _json);
    }
}
