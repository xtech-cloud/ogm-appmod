using System;
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainModel : DomainBaseModel
    {
        public class DomainStatus : DomainBaseStatus
        {
            public long domainTotal;
            public Proto.DomainEntity[] domainList;
            public Proto.DeviceEntity[] deviceList;
            public Dictionary<string, int> accessList;
            public Dictionary<string, string> aliasListt;
        }
        public const string NAME = "ogm.actor.DomainModel";


        public void SaveCreate(Proto.BlankResponse _rsp) { }
        public void SaveDelete(Proto.BlankResponse _rsp) { }
        public void SaveExecute(Proto.BlankResponse _rsp) { }

        public void SaveFind(Proto.DomainFindResponse _rsp)
        { }

        public void SaveList(Proto.DomainListResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.domainTotal = _rsp._total.AsInt64();
            status.domainList = _rsp._domain;
            this.Bubble("/reply/Domain/List", null);
        }
        public void SaveFetchDevice(Proto.DomainFetchDeviceResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.deviceList = _rsp._device;
            status.accessList = _rsp._access;
            status.aliasListt = _rsp._alias;
            this.Bubble("/reply/Domain/FetchDevice", null);
        }
        public void SaveEditDevice(Proto.BlankResponse _rsp)
        {

        }

        public void SaveSearch(Proto.DomainSearchResponse _rsp)
        {
            if (_rsp._status._code.AsInt32() != 0)
            {
                getLogger().Error(_rsp._status._message.AsString());
                return;
            }
            status.domainTotal = _rsp._total.AsInt64();
            status.domainList = _rsp._domain;
            this.Bubble("/reply/Domain/List", null);
        }
    }
}
