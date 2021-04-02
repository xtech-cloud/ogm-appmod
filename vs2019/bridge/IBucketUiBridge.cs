
using XTC.oelMVCS;
namespace OGM.Module.File
{
    public interface IBucketUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
    }
}
