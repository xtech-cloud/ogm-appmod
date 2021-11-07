
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardViewBridge : IGuardViewBridge
    {
        public GuardView view{ get; set; }
        public GuardService service{ get; set; }


        public void OnFetchSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.GuardFetchRequest>(_json, options);
            service.PostFetch(req);
        }
        

        public void OnEditSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.GuardEditRequest>(_json, options);
            service.PostEdit(req);
        }
        

        public void OnDeleteSubmit(string _json)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var req = JsonSerializer.Deserialize<Proto.GuardDeleteRequest>(_json, options);
            service.PostDelete(req);
        }
        


    }
}
