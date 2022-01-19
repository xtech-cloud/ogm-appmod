
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IObjectUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string,string> _permission);
        void ReceivePrepare(string _json);
        void ReceiveFlush(string _json);
        void ReceiveLink(string _json);
        void ReceiveGet(string _json);
        void ReceiveFind(string _json);
        void ReceiveRemove(string _json);
        void ReceiveList(string _json);
        void ReceiveSearch(string _json);
        void ReceivePublish(string _json);
        void ReceivePreview(string _json);
        void ReceiveRetract(string _json);
        void ReceiveConvertFromBase64(string _json);
        void ReceiveConvertFromUrl(string _json);

    }
}
