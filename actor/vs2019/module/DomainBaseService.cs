
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;
using System.Threading.Tasks;

namespace ogm.actor
{
    public class DomainBaseService : Service
    {
        protected DomainModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(DomainModel.NAME) as DomainModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.actor.DomainService");
        }

        public void PostCreate(Proto.DomainCreateRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["name"] = _request._name;

            post(string.Format("{0}/ogm/actor/Domain/Create", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveCreate(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostUpdate(Proto.DomainUpdateRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;
            paramMap["name"] = _request._name;

            post(string.Format("{0}/ogm/actor/Domain/Update", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveUpdate(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostDelete(Proto.DomainDeleteRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;

            post(string.Format("{0}/ogm/actor/Domain/Delete", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.UuidResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveDelete(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostList(Proto.ListRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;

            post(string.Format("{0}/ogm/actor/Domain/List", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.DomainListResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveList(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostGet(Proto.DomainGetRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;

            post(string.Format("{0}/ogm/actor/Domain/Get", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.DomainGetResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveGet(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostFind(Proto.DomainFindRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["name"] = _request._name;

            post(string.Format("{0}/ogm/actor/Domain/Find", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.DomainFindResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveFind(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostSearch(Proto.DomainSearchRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["offset"] = _request._offset;
            paramMap["count"] = _request._count;
            paramMap["name"] = _request._name;

            post(string.Format("{0}/ogm/actor/Domain/Search", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.DomainSearchResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveSearch(rsp);
            }, (_err) =>
            {
                getLogger().Error(_err.getMessage());
            }, null);
        }


        public void PostExecute(Proto.DomainExecuteRequest _request)
        {
            Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
            paramMap["uuid"] = _request._uuid;
            paramMap["command"] = _request._command;
            paramMap["device"] = _request._device;
            paramMap["parameter"] = _request._parameter;

            post(string.Format("{0}/ogm/actor/Domain/Execute", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
            {
                var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                model.SaveExecute(rsp);
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
