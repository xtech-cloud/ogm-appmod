
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDomainUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveCreate(string _json);
        void ReceiveUpdate(string _json);
        void ReceiveDelete(string _json);
        void ReceiveList(string _json);
        void ReceiveGet(string _json);
        void ReceiveFind(string _json);
        void ReceiveSearch(string _json);
        void ReceiveExecute(string _json);

    }
}
