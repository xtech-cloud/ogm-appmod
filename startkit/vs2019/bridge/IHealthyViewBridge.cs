
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.startkit
{
    public interface IHealthyViewBridge : View.Facade.Bridge
    {
        void OnEchoSubmit(string _msg);

    }
}
