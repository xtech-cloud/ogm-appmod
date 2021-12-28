
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.license
{
    public class CertificateBaseViewBridge : ICertificateViewBridge
    {
        public CertificateView view{ get; set; }
        public CertificateService service{ get; set; }


            public void OnGetSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.CerGetRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostGet(req);
            }


            public void OnListSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.CerListRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostList(req);
            }


            public void OnSearchSubmit(string _json)
            {
                var req = JsonSerializer.Deserialize<Proto.CerSearchRequest>(_json, JsonOptions.DefaultSerializerOptions);
                service.PostSearch(req);
            }



    }
}
