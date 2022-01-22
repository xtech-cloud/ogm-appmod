
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.analytics
{
    public interface IGeneratorViewBridge : View.Facade.Bridge
    {
        void OnAgentSubmit(string _json);
        void OnRecordSubmit(string _json);

    }
}
