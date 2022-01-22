
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class GeneratorBaseViewBridge : IGeneratorViewBridge
    {
        public GeneratorView view{ get; set; }
        public GeneratorService service{ get; set; }


            public void OnAgentSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.GeneratorAgentRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostAgent(req);
            }


            public void OnRecordSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.GeneratorRecordRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRecord(req);
            }



    }
}
