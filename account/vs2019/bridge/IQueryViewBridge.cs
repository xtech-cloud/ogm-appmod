
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.account
{
    public interface IQueryViewBridge : View.Facade.Bridge
    {
        void OnListSubmit(string _json);
        void OnSingleSubmit(string _json);

    }
}
