
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.analytics
{
    public class TrackerBaseService: Service
    {
        protected TrackerModel model = null;
        protected Options options = null;

        protected override void preSetup()
        {
            options = new Options();
            options.header["apikey"] = getConfig().getField("apikey").AsString();
            model = findModel(TrackerModel.NAME) as TrackerModel;
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.analytics.TrackerService");
        }

            public void PostWake(Proto.Agent _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["serialNumber"] = _request._serialNumber;
            paramMap["softwareFamily"] = _request._softwareFamily;
            paramMap["softwareVersion"] = _request._softwareVersion;
            paramMap["systemFamily"] = _request._systemFamily;
            paramMap["systemVersion"] = _request._systemVersion;
            paramMap["deviceModel"] = _request._deviceModel;
            paramMap["deviceType"] = _request._deviceType;
            paramMap["profile"] = _request._profile;

                post(string.Format("{0}/ogm/analytics/Tracker/Wake", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveWake(rsp);
                }, (_err) =>
                {
                    getLogger().Error(_err.getMessage());
                }, null);
            }


            public void PostRecord(Proto.TrackerRecordRequest _request)
            {
                Dictionary<string, Any> paramMap = new Dictionary<string, Any>();
                paramMap["appID"] = _request._appID;
            paramMap["deviceID"] = _request._deviceID;
            paramMap["userID"] = _request._userID;
            paramMap["eventID"] = _request._eventID;
            paramMap["parameter"] = _request._parameter;

                post(string.Format("{0}/ogm/analytics/Tracker/Record", getConfig().getField("domain").AsString()), paramMap, (_reply) =>
                {
                    var rsp = JsonSerializer.Deserialize<Proto.BlankResponse>(_reply, JsonOptions.DefaultSerializerOptions);
                    model.SaveRecord(rsp);
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
