
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.actor
{
    public interface IDomainViewBridge : View.Facade.Bridge
    {
        void OnCreateSubmit(string _name);
        void OnDeleteSubmit(string _uuid);
        void OnListSubmit(long _offset, long _count);
        void OnExecuteSubmit(string _uuid, string _command, string[] _device, string _parameter);

    }
}
