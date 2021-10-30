
using XTC.oelMVCS;
namespace ogm.startkit
{
    public interface IHealthyUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
