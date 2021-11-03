
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDomainUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);

        void RefreshList(string _reply);
        void RefreshFetchDevice(string _reply);
    }
}
