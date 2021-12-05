
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface ISyncUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceivePush(string _json);
        void ReceivePull(string _json);
        void ReceiveUpload(string _json);

    }
}
