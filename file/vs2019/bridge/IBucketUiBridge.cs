
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IBucketUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);

        void RefreshList(string _json);
    }
}
