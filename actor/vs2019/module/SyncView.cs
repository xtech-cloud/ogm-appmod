
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class SyncView: SyncBaseView
    {
        public const string NAME = "ogm.actor.SyncView";

        protected override void postSetup()
        {
            base.postSetup();
            addObserver(ApplicationModel.NAME, "_.reply.arrived:ogm/actor/Application/List", this.handleReceiveApplicationList);
        }

        private void handleReceiveApplicationList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.ApplicationListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Application/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            var extendBridge = bridge as ISyncExtendUiBridge;
            extendBridge.ReceiveApplicationList(json);
        }
    }
}
