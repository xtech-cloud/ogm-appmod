
using System;
using XTC.oelMVCS;

namespace ogm.file
{
    public class BucketModel : BucketBaseModel
    {
        public class BucketStatus : BucketBaseStatus
        {
            public Proto.BucketEntity[] bucketList;
        }
        public const string NAME = "ogm.file.BucketModel";

        public void SaveMake(Proto.BlankResponse _rsp) 
        {
            this.Bubble("/reply/bucket/make", _rsp._status);
        }

        public void SaveList(Proto.BucketListResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.bucketList = _rsp._entity;
            this.Bubble("/reply/bucket/list", null);
        }
        public void SaveSearch(Proto.BucketSearchResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.bucketList = _rsp._entity;
            this.Bubble("/reply/bucket/list", null);
        }
        public void SaveRemove(Proto.BlankResponse _rsp) { }
        public void SaveGet(Proto.BucketGetResponse _rsp) { }
        public void SaveFind(Proto.BucketFindResponse _rsp) { }
        public void SaveUpdate(Proto.BlankResponse _rsp) { }
        public void SaveResetToken(Proto.BlankResponse _rsp) { }


    }
}
