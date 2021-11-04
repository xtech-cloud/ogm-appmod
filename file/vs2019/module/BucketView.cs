
using System;
using System.Collections.Generic;
using System.Text.Json;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketView: BucketBaseView
    {
        public const string NAME = "ogm.file.BucketView";

        public void EnterBucket(string _uuid)
        {
            model.Broadcast("/sidemenu/active/tab", "ogm.file.Object");
        }

        protected override void setup()
        {
            base.setup();

            addRouter("/sidemenu/tab/activated", this.handleTabActivated);
            addObserver(BucketModel.NAME, "/reply/bucket/list", this.receiveBucketList);
        }

        private void handleTabActivated(Model.Status _status, object _data)
        {
            string tab = (string)_data;
            if (!tab.Equals("ogm.actor.Device"))
                return;

            var bridge = facade.getViewBridge() as BucketViewBridge;
            var req = new Proto.BucketListRequest();
            req._offset = Any.FromInt32(0);
            req._count = Any.FromInt32(int.MaxValue);
            bridge.service.PostList(req);
        }

        private void receiveBucketList(Model.Status _status, object _data)
        {
            BucketModel.BucketStatus status = _status as BucketModel.BucketStatus;
            if(null == status)
            {
                getLogger().Error("status [BucketModel.BucketStatus] is null");
                return;
            }    
            var bridge = facade.getUiBridge() as IBucketUiBridge;
            var options = new JsonSerializerOptions();
            options.Converters.Add(new AnyProtoConverter());
            var json = JsonSerializer.Serialize(status.bucketList, options);
            bridge.RefreshList(json);

        }


    }
}
