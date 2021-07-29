
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IAuthUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        public void RefreshSignupSuccess(string _uuid);
    }
}
