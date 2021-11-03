using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainView : DomainBaseView
    {
        public const string NAME = "ogm.actor.DomainView";

        protected override void setup()
        {
            base.setup();

            addRouter("/sidemenu/tab/activated", this.handleTabActivated);
            addObserver(DomainModel.NAME, "/reply/Domain/List", this.receiveList);
            addObserver(DomainModel.NAME, "/reply/Domain/FetchDevice", this.receiveFetchDevice);
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string tab = (string)_data;
            if (!tab.Equals("ogm.actor.Domain"))
                return;

            var bridge = facade.getViewBridge() as DomainViewBridge;
            var req = new Proto.ListRequest();
            req._offset = Any.FromInt32(0);
            req._count = Any.FromInt32(int.MaxValue);
            bridge.service.PostList(req);
        }

        private void receiveList(Model.Status _status, object _data)
        {
            DomainModel.DomainStatus status = _status as DomainModel.DomainStatus;
            if(null == status)
            {
                getLogger().Error("status [DomainModel.DomainStatus] is null");
                return;
            }    
            var bridge = facade.getUiBridge() as IDomainUiBridge;
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var json = JsonSerializer.Serialize(status.domainList, options);
            bridge.RefreshList(json);
        }

        private void receiveFetchDevice(Model.Status _status, object _data)
        {
            DomainModel.DomainStatus status = _status as DomainModel.DomainStatus;
            if (null == status)
            {
                getLogger().Error("status [DomainModel.DomainStatus] is null");
                return;
            }
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["device"] = status.deviceList;
            param["access"] = status.accessList;
            param["alias"] = status.aliasListt;
            var bridge = facade.getUiBridge() as IDomainUiBridge;
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var json = JsonSerializer.Serialize(param, options);
            bridge.RefreshFetchDevice(json);
        }
    }
}
