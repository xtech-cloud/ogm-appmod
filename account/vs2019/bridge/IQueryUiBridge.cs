
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IQueryUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
