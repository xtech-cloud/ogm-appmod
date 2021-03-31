using XTC.oelMVCS;
namespace OGM.Module.File
{
    public interface IBucketViewBridge : View.Facade.Bridge
    {
        void OnMakeSubmit(string _name, long _capacity, int _engine, string _address, string _scope, string _accessKey, string _accessSecret);
        void OnListSubmit(long _offset, long _count);
    }
}
