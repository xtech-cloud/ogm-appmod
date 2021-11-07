
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IGuardUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);

        void ReceiveFetch(string _reply);
        void ReceiveEdit(string _reply);
    }
}
