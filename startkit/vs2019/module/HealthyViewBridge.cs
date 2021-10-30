
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class HealthyViewBridge : IHealthyViewBridge
    {
        public HealthyView view{ get; set; }
        public HealthyService service{ get; set; }


        public void OnEchoSubmit(string _msg)
        {
            Proto.Request req = new Proto.Request();
            req._msg = Any.FromString(_msg);

            service.PostEcho(req);
        }
        


    }
}
