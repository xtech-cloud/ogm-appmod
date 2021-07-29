
using System.Collections.Generic;
using XTC.oelMVCS;

namespace ogm.account
{
    public class QueryViewBridge : IQueryViewBridge
    {
        public QueryView view{ get; set; }
        public QueryService service{ get; set; }


        public void OnListSubmit(long _offset, long _count)
        {
            Proto.QueryListRequest req = new Proto.QueryListRequest();
            req._offset = Any.FromInt64(_offset);
            req._count = Any.FromInt64(_count);

            service.PostList(req);
        }
        

        public void OnSingleSubmit(int _field, string _value)
        {
            Proto.QuerySingleRequest req = new Proto.QuerySingleRequest();
            req._field = Any.FromInt32(_field);
            req._value = Any.FromString(_value);

            service.PostSingle(req);
        }
        


    }
}
