
using System.Text.Json;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.group
{
    public class CollectionBaseView: View
    {
        protected Facade facade = null;
        protected CollectionModel model = null;
        protected ICollectionUiBridge bridge = null;

        protected override void preSetup()
        {
            model = findModel(CollectionModel.NAME) as CollectionModel;
            var service = findService(CollectionService.NAME) as CollectionService;
            facade = findFacade("ogm.group.CollectionFacade");
            CollectionViewBridge vb = new CollectionViewBridge();
            vb.view = this as CollectionView;
            vb.service = service;
            facade.setViewBridge(vb);
        }

        protected override void setup()
        {
            getLogger().Trace("setup ogm.group.CollectionView");

            addObserver(CollectionModel.NAME, "_.reply.arrived:ogm/group/Collection/Make", this.handleReceiveCollectionMake);

            addObserver(CollectionModel.NAME, "_.reply.arrived:ogm/group/Collection/Update", this.handleReceiveCollectionUpdate);

            addObserver(CollectionModel.NAME, "_.reply.arrived:ogm/group/Collection/List", this.handleReceiveCollectionList);

            addObserver(CollectionModel.NAME, "_.reply.arrived:ogm/group/Collection/Search", this.handleReceiveCollectionSearch);

            addObserver(CollectionModel.NAME, "_.reply.arrived:ogm/group/Collection/Remove", this.handleReceiveCollectionRemove);

            addObserver(CollectionModel.NAME, "_.reply.arrived:ogm/group/Collection/Get", this.handleReceiveCollectionGet);

        }

        protected override void postSetup()
        {
            bridge = facade.getUiBridge() as ICollectionUiBridge;
            object rootPanel = bridge.getRootPanel();
            // 通知主程序挂载界面
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ogm.group.Collection"] = rootPanel;
            model.Broadcast("/module/view/attach", data);
            // 监听权限更新
            addRouter("/permission/updated", this.handlePermissionUpdated);
        }

        protected void handlePermissionUpdated(Model.Status _status, object _data)
        {
            Dictionary<string, string> permission = (Dictionary<string,string>) _data;
            bridge.UpdatePermission(permission);
        }


        public void Alert(string _message)
        {
            bridge.Alert(_message);
        }

        private void handleReceiveCollectionMake(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Collection/Make is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveMake(json);
        }

        private void handleReceiveCollectionUpdate(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Collection/Update is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveUpdate(json);
        }

        private void handleReceiveCollectionList(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.CollectionListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Collection/List is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveList(json);
        }

        private void handleReceiveCollectionSearch(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.CollectionListResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Collection/Search is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveSearch(json);
        }

        private void handleReceiveCollectionRemove(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.UuidResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Collection/Remove is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveRemove(json);
        }

        private void handleReceiveCollectionGet(Model.Status _status, object _data)
        {
            var rsp = _data as Proto.CollectionGetResponse;
            if(null == rsp)
            {
                getLogger().Error("rsp of Collection/Get is null");
                return;
            }
            string json = JsonSerializer.Serialize(rsp, JsonOptions.DefaultSerializerOptions);
            bridge.ReceiveGet(json);
        }

    }
}
