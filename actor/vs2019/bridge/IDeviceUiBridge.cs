
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDeviceUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
