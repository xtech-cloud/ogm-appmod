
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IBucketUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);
        void UpdatePermission(Dictionary<string, string> _permission);

        void ReceiveMake(string _json);
        void RefreshList(string _json);
    }
}
