
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IQueryUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveList(string _json);
        void ReceiveSingle(string _json);

    }
}
