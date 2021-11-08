
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncView: SyncBaseView
    {
        public const string NAME = "ogm.actor.SyncView";

        protected override void setup()
        {
            base.setup();

            addObserver(SyncModel.NAME, "/reply/sync/pull", this.receivePull);
        }

        private void receivePull(Model.Status _status, object _data)
        {
            var replyStatus = _data  as Proto.Status;
            if(replyStatus._code.AsInt32() != 0)
            {
                Alert(replyStatus._message.AsString());
                return;
            }

            SyncModel.SyncStatus status = _status as SyncModel.SyncStatus;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["device"] = status.device;
            param["alias"] = status.alias;
            param["property"] = status.property;
            var json = JsonSerializer.Serialize(param, JsonOptions.DefaultSerializerOptions);
            bridge.ReceivePull(json);
        }

    }
}
