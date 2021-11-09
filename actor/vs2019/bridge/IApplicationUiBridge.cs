
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IApplicationUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);

        void ReceiveAdd(string _json);
        void ReceiveRemove(string _json);
        void ReceiveUpdate(string _json);
        void ReceiveList(string _json);
    }
}
