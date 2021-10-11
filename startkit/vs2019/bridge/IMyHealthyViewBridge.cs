
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.startkit
{
    public interface IMyHealthyViewBridge : View.Facade.Bridge
    {
        void OnEchoSubmit(string _msg);

    }
}
