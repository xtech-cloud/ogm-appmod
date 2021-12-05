
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardBaseViewBridge : IGuardViewBridge
    {
        public GuardView view{ get; set; }
        public GuardService service{ get; set; }


            public void OnFetchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.GuardFetchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostFetch(req);
            }


            public void OnEditSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.GuardEditRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostEdit(req);
            }


            public void OnDeleteSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.GuardDeleteRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostDelete(req);
            }



    }
}
