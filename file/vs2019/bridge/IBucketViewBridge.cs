
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IBucketViewBridge : View.Facade.Bridge
    {
        void OnMakeSubmit(string _name, ulong _capacity, int _engine, string _address, string _scope, string _accessKey, string _accessSecret);
        void OnListSubmit(long _offset, long _count);
        void OnRemoveSubmit(string _uuid);
        void OnGetSubmit(string _uuid);
        void OnFindSubmit(string _name);
        void OnUpdateEngineSubmit(string _uuid, int _engine, string _address, string _scope, string _accessKey, string _accessSecret);
        void OnUpdateCapacitySubmit(string _uuid, ulong _capacity);
        void OnResetTokenSubmit(string _uuid);

    }
}
