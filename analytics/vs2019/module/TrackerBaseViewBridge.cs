
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class TrackerBaseViewBridge : ITrackerViewBridge
    {
        public TrackerView view{ get; set; }
        public TrackerService service{ get; set; }


            public void OnWakeSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.Agent>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostWake(req);
            }


            public void OnRecordSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.TrackerRecordRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRecord(req);
            }



    }
}
