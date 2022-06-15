
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;
using System.Threading.Tasks;

namespace ogm.actor
{
    public class SyncBaseService: Service
    {
        protected SyncModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(SyncModel.NAME) as SyncModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.SyncService");
        }

            public void PostPush(Proto.SyncPushRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["domain"] = _request._domain;
            paramMap["downProperty"] = _request._downProperty;
            paramMap["task"] = _request._task;

                post(string.Format("{0}/ogm/actor/Sync/Push", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.SyncPushResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SavePush(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostPull(Proto.SyncPullRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["domain"] = _request._domain;
            paramMap["downProperty"] = _request._downProperty;

                post(string.Format("{0}/ogm/actor/Sync/Pull", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.SyncPullResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SavePull(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostUpload(Proto.SyncUploadRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["domain"] = _request._domain;
            paramMap["device"] = _request._device;
            paramMap["name"] = _request._name;
            paramMap["data"] = _request._data;

                post(string.Format("{0}/ogm/actor/Sync/Upload", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveUpload(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }



        protected override void asyncRequest(string _url, string _method, Dictionary<string, Any> _params, OnReplyCallback _onReply, OnErrorCallback _onError, Options _options)
        {
            doAsyncRequest(_url, _method, _params, _onReply, _onError, _options);
        }

        protected async Task doAsyncRequest(string _url, string _method, Dictionary<string, Any> _params, OnReplyCallback _onReply, OnErrorCallback _onError, Options _options)
        {
            string reply = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_url);
                req.Method = _method;
                req.ContentType = "application/json;charset=utf-8";
                foreach (var pair in options.header)
                    req.Headers.Add(pair.Key, pair.Value);
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
