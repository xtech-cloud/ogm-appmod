
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.config
{
    public class TextBaseViewBridge : ITextViewBridge
    {
        public TextView view{ get; set; }
        public TextService service{ get; set; }


            public void OnWriteSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.TextWriteRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostWrite(req);
            }


            public void OnReadSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.TextReadRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRead(req);
            }


            public void OnDeleteSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.DeleteRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostDelete(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.GetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.ListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.TextSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }



    }
}
