
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.actor
{
    public class DomainViewBridge : IDomainViewBridge
    {
        public DomainView view{ get; set; }
        public DomainService service{ get; set; }


        public void OnCreateSubmit(string _name)
        {
            Proto.DomainCreateRequest req = new Proto.DomainCreateRequest();
            req._name = Any.FromString(_name);

            service.PostCreate(req);
        }
        

        public void OnDeleteSubmit(string _uuid)
        {
            Proto.DomainDeleteRequest req = new Proto.DomainDeleteRequest();
            req._uuid = Any.FromString(_uuid);

            service.PostDelete(req);
        }
        

        public void OnListSubmit(long _offset, long _count)
        {
            Proto.ListRequest req = new Proto.ListRequest();
            req._offset = Any.FromInt64(_offset);
            req._count = Any.FromInt64(_count);

            service.PostList(req);
        }
        

        public void OnExecuteSubmit(string _uuid, string _command, string[] _device, string _parameter)
        {
            Proto.DomainExecuteRequest req = new Proto.DomainExecuteRequest();
            req._uuid = Any.FromString(_uuid);
            req._command = Any.FromString(_command);
            req._device = Any.FromStringAry(_device);
            req._parameter = Any.FromString(_parameter);

            service.PostExecute(req);
        }
        


    }
}
