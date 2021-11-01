
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface ISyncUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
