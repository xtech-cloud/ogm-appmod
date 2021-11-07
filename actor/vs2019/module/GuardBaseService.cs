
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class GuardBaseService: Service
    {
        protected GuardModel model = null;

        protected override void preSetup()
        {
            model = findModel(GuardModel.NAME) as GuardModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.GuardService");
        }

        public void PostFetch(Proto.GuardFetchRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["domain"] = _request._domain;
            paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;

            post(string.Format("{0}/ogm/actor/Guard/Fetch", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new AnyProtoConverter());
                var rsp = JsonSerializer.Deserialize<Proto.GuardFetchResponse>(_reply, options);
                model.SaveFetch(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostEdit(Proto.GuardEditRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["domain"] = _request._domain;
            paramMap["device"] = _request._device;
            paramMap["access"] = _request._access;
            paramMap["alias"] = _request._alias;

            post(string.Format("{0}/ogm/actor/Guard/Edit", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new AnyProtoConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                model.SaveEdit(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }
        

        public void PostDelete(Proto.GuardDeleteRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["domain"] = _request._domain;
            paramMap["device"] = _request._device;
            paramMap["access"] = _request._access;
            paramMap["alias"] = _request._alias;

            post(string.Format("{0}/ogm/actor/Guard/Delete", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var options = new JsonSerializerOptions();
                options.Converters.Add(new AnyProtoConverter());
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, options);
                model.SaveDelete(rsp);
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
