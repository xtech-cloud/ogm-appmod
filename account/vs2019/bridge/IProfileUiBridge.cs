
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IProfileUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
