using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainView : DomainBaseView
    {
        public const string NAME = "ogm.actor.DomainView";

        public void OpenGuardUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.actor.Guard");
        }

        public void OpenSyncUi()
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.actor.Sync");
        }


        protected override void setup()
        {
            base.setup();

            addRouter("/sidemenu/tab/activated", this.handleTabActivated);
            addObserver(DomainModel.NAME, "/reply/Domain/Create", this.receiveCreate);
            addObserver(DomainModel.NAME, "/reply/Domain/Update", this.receiveUpdate);
            addObserver(DomainModel.NAME, "/reply/Domain/List", this.receiveList);
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

        private void receiveCreate(Model.Status _status, object _data)
        {
            var bridge = facade.getUiBridge() as IDomainUiBridge;
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var status = _data as Proto.Status;
            var json = JsonSerializer.Serialize(status, options);
            bridge.ReceiveCreate(json);
        }

        private void receiveUpdate(Model.Status _status, object _data)
        {
            var bridge = facade.getUiBridge() as IDomainUiBridge;
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var status = _data as Proto.Status;
            var json = JsonSerializer.Serialize(status, options);
            bridge.ReceiveUpdate(json);
        }



    }
}
