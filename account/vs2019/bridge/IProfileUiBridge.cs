
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IProfileUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveQuery(string _json);
        void ReceiveUpdate(string _json);

    }
}
