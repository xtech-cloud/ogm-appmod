
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.config
{
    public interface ITextUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveWrite(string _json);
        void ReceiveRead(string _json);
        void ReceiveDelete(string _json);
        void ReceiveGet(string _json);
        void ReceiveList(string _json);
        void ReceiveSearch(string _json);

    }
}
