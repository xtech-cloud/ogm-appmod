
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryBaseViewBridge : IQueryViewBridge
    {
        public QueryView view{ get; set; }
        public QueryService service{ get; set; }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.QueryListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSingleSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.QuerySingleRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSingle(req);
            }



    }
}
