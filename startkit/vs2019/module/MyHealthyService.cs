
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.startkit
{
    public class MyHealthyService: Service
    {
        public const string NAME = "ogm.startkit.MyHealthyService";
        private MyHealthyModel model = null;

        protected override void preSetup()
        {
            model = findModel(MyHealthyModel.NAME) as MyHealthyModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.startkit.MyHealthyService");
        }

        public void PostEcho(Proto.Request _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["msg"] = _request._msg;

            post(string.Format("{0}/ogm/startkit/MyHealthy/Echo", getConfig()["domain"].AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new AnyProtoConverter());
                var rsp = JsonSerializer.Deserialize<Proto.Response>(_reply, options);
                Model.Status reply = Model.Status.New<Model.Status>(rsp._status._code.AsInt32(), rsp._status._message.AsString());
                model.Broadcast("/ogm/startkit/MyHealthy/Echo", reply);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        


        protected override void asyncRequest(string _url, string _method, Dictionary<string, Any> _params, OnReplyCallback _onReply, OnErrorCallback _onError, Options _options)
        {
            doAsyncRequest(_url, _method, _params, _onReply, _onError, _options);    
        }

        protected async void doAsyncRequest(string _url, string _method, Dictionary<string, Any> _params, OnReplyCallback _onReply, OnErrorCallback _onError, Options _options)
        {
            string reply = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_url);
                req.Method = _method;
                req.ContentType =
                "application/json;charset=utf-8";
                byte[] data = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_params, JsonOptions.DefaultSerializerOptions);
                req.ContentLength = data.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                }
                HttpWebResponse rsp = await req.GetResponseAsync() as HttpWebResponse;
                if (rsp == null)
                {
                    _onError(Error.NewNullErr("HttpWebResponse is null"));
                    return;
                }
                if (rsp.StatusCode != HttpStatusCode.OK)
                {
                    rsp.Close();
                    _onError(new Error(rsp.StatusCode.GetHashCode(), "HttpStatusCode != 200"));
                    return;
                }
                StreamReader sr;
                using (sr = new StreamReader(rsp.GetResponseStream()))
                {
                    reply = sr.ReadToEnd();
                }
                sr.Close();
            }
            catch (System.Exception ex)
            {
                _onError(Error.NewException(ex));
                return;
            }
            _onReply(reply);
        }

    }
}
