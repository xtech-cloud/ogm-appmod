
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IBucketUiBridge : View.Facade.Bridge
    {
        object getRootPanel();
        void Alert(string _message);

        void RefreshBucketList(long _total, List<Dictionary<string, Any>> _list);
    }
}
