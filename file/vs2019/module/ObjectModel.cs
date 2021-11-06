
using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.file
{
    public class ObjectModel : ObjectBaseModel
    {
        public class ObjectStatus : ObjectBaseStatus
        {
            public Proto.ObjectEntity[] objectList;
            public long objectTotalCount;
        }
        public const string NAME = "ogm.file.ObjectModel";

        public void SavePrepare(Proto.ObjectPrepareResponse _rsp)
        {
            bool exists = _rsp._status._code.AsInt32() == 200;
            if (_rsp._status._code.AsInt32() != 0 && !exists)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            Dictionary<string, string> param = new Dictionary<string, string>();
            param["exist"] = exists.ToString();
            if (!exists)
            {
                param["url"] = _rsp._url.AsString();
                param["engine"] = _rsp._engine.AsString();
                param["accessToken"] = _rsp._accessToken.AsString();
            }
            this.Bubble("/reply/object/prepare", param);
        }
        public void SaveFlush(Proto.BlankResponse _rsp)
        {
            this.Bubble("/reply/object/flush", _rsp._status);
        }
        public void SaveLink(Proto.BlankResponse _rsp) { }
        public void SaveGet(Proto.ObjectGetResponse _rsp) { }
        public void SaveFind(Proto.ObjectFindResponse _rsp) { }
        public void SaveRemove(Proto.BlankResponse _rsp) { }
        public void SaveList(Proto.ObjectListResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.objectTotalCount = _rsp._total.AsInt64();
            status.objectList = _rsp._entity;
            this.Bubble("/reply/object/list", null);
        }
        public void SaveSearch(Proto.ObjectSearchResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.objectTotalCount = _rsp._total.AsInt64();
            status.objectList = _rsp._entity;
            this.Bubble("/reply/object/list", null);
        }
        public void SavePublish(Proto.ObjectPublishResponse _rsp) { }
        public void SavePreview(Proto.ObjectPreviewResponse _rsp)
        {

        }
        public void SaveRetract(Proto.BlankResponse _rsp) { }


    }
}
