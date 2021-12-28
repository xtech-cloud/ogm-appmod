
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.license
{
    public interface ISpaceUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveCreate(string _json);
        void ReceiveUpdate(string _json);
        void ReceiveGet(string _json);
        void ReceiveList(string _json);
        void ReceiveSearch(string _json);

    }
}
