
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.license
{
    public interface ICertificateUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceiveGet(string _json);
        void ReceiveList(string _json);
        void ReceiveSearch(string _json);

    }
}
