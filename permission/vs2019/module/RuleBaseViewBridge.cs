
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.permission
{
    public class RuleBaseViewBridge : IRuleViewBridge
    {
        public RuleView view{ get; set; }
        public RuleService service{ get; set; }


            public void OnAddSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleAddRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostAdd(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnDeleteSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleDeleteRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostDelete(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }


            public void OnExportSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleExportRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostExport(req);
            }


            public void OnImportSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.RuleImportRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostImport(req);
            }



    }
}
