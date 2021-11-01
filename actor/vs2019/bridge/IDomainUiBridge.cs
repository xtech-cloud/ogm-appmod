
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDomainUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
