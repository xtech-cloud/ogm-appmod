
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IObjectUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);

        void receivePrepare(string _json);
        void receiveFlush(string _json);
        void receiveList(string _json);
    }
}
