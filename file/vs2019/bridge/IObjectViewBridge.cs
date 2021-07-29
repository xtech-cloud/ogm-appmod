
using System.Collections.Generic;
using XTC.oelMVCS;
namespace ogm.file
{
    public interface IObjectViewBridge : View.Facade.Bridge
    {
        void OnPrepareSubmit(string _bucket, string _uname, ulong _size);
        void OnFlushSubmit(string _bucket, string _uname, string _path);
        void OnLinkSubmit(string _bucket, string _filepath, string _url, bool _overwrite);
        void OnGetSubmit(string _uuid);
        void OnFindSubmit(string _bucket, string _filepath);
        void OnRemoveSubmit(string _uuid);
        void OnListSubmit(long _offset, long _count, string _bucket);
        void OnSearchSubmit(long _offset, long _count, string _bucket, string _prefix);
        void OnPublishSubmit(string _uuid, ulong _expiry);
        void OnPreviewSubmit(string _uuid);
        void OnRetractSubmit(string _uuid);

    }
}
