
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IQueryViewBridge : View.Facade.Bridge
    {
        void OnListSubmit(long _offset, long _count);
        void OnSingleSubmit(int _field, string _value);

    }
}
