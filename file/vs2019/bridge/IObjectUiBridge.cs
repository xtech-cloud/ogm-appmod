
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IObjectUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
