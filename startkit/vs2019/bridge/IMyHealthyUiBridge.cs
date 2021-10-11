
using XTC.oelMVCS;
namespace ogm.startkit
{
    public interface IMyHealthyUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
