
using System;
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectView: ObjectBaseView
    {
        public const string NAME = "ogm.file.ObjectView";

        protected override void setup()
        {
            base.setup();

            addObserver(ObjectModel.NAME, "/reply/object/prepare", this.receiveObjectPrepare);
            addObserver(ObjectModel.NAME, "/reply/object/flush", this.receiveObjectFlush);
            addObserver(ObjectModel.NAME, "/reply/object/list", this.receiveObjectList);
        }

        private void receiveObjectPrepare(Model.Status _status, object _data)
        {
            var bridge = facade.getUiBridge() as IObjectUiBridge;
            string json = JsonSerializer.Serialize(_data);
            bridge.receivePrepare(json);
        }

        private void receiveObjectFlush(Model.Status _status, object _data)
        {
            Proto.Status status = (Proto.Status)_data;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["code"] = status._code.AsInt32();
            param["message"] = status._message.AsString();
            var bridge = facade.getUiBridge() as IObjectUiBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.receiveFlush(json);
        }

        private void receiveObjectList(Model.Status _status, object _data)
        {
            ObjectModel.ObjectStatus status = _status as ObjectModel.ObjectStatus;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["total"] = status.objectTotalCount;
            param["entity"] = status.objectList;
            var bridge = facade.getUiBridge() as IObjectUiBridge;
            string json = JsonSerializer.Serialize(param, JsonOptions.DefaultSerializerOptions);
            bridge.receiveList(json);
        }


    }
}
