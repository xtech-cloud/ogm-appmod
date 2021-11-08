
using System;
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class ApplicationView: ApplicationBaseView
    {
        public const string NAME = "ogm.actor.ApplicationView";

        protected override void setup()
        {
            base.setup();

            addObserver(ApplicationModel.NAME, "/reply/application/add", this.receiveApplicationAdd);
            addObserver(ApplicationModel.NAME, "/reply/application/list", this.receiveApplicationList);
        }

        private void receiveApplicationAdd(Model.Status _status, object _data)
        {
            var json = JsonSerializer.Serialize(_data, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveAdd(json);
        }

        private void receiveApplicationList(Model.Status _status, object _data)
        {
            var status = _status as ApplicationModel.ApplicationStatus;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["total"] = status.applicationTotal;
            param["application"] = status.applicationList;
            var json = JsonSerializer.Serialize(param, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }
    }
}
