
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.group
{
    public class MemberBaseViewBridge : IMemberViewBridge
    {
        public MemberView view{ get; set; }
        public MemberService service{ get; set; }


            public void OnAddSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.MemberAddRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostAdd(req);
            }


            public void OnUpdateSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.MemberUpdateRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostUpdate(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.MemberListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.MemberSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }


            public void OnRemoveSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.MemberRemoveRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostRemove(req);
            }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.MemberGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnWhereSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.MemberWhereRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostWhere(req);
            }



    }
}
