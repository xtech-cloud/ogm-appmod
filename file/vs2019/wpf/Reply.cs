
using System.ComponentModel;

namespace ogm.file
{
    public class Utility
    {
        public static string FormatSize(long _size)
        {
            if (_size < 1024)
                return string.Format("{0} B", _size);
            if (_size < 1024 * 1024)
                return string.Format("{0} K", _size / 1024);
            if (_size < 1024 * 1024 * 1024)
                return string.Format("{0} M", _size / 1024 / 1024);
            if (_size < (long)1024 * 1024 * 1024 * 1024)
                return string.Format("{0} G", _size / 1024 / 1024 / 1024);
            if (_size < (long)1024 * 1024 * 1024 * 1024 * 1024)
                return string.Format("{0} T", _size / 1024 / 1024 / 1024 / 1024);
            return "?";
        }
    }

    public class Reply
    {
        public class Status
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        public Status status { get; set; }

        public Reply()
        {
            status = new Status();
        }

    }

    public class UuidReply : Reply
    {
        public string uuid { get; set; }
    }

    public class BucketEntity : INotifyPropertyChanged
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string token { get; set; }
        public long totalSize { get; set; }
        public long usedSize { get; set; }
        public int engine { get; set; }
        public string address { get; set; }
        public string scope { get; set; }
        public string accessKey { get; set; }
        public string accessSecret { get; set; }
        public string url { get; set; }
        public string mode { get; set; }

        public string _engine { get; set; }
        public string _totalSize { get; set; }
        public string _usedSize { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public static string engineToString(int _engine)
        {
            if (0 == _engine)
                return "Invalid";
            if (1 == _engine)
                return "Local";
            if (2 == _engine)
                return "MinIO";
            if (3 == _engine)
                return "Qiniu";
            if (100 == _engine)
                return "Custom";
            return "Unknown";


        }

        public void CopyFromOther(BucketEntity _other)
        {
            if (!uuid.Equals(_other.uuid))
                return;
            this.name = _other.name;
            this.token = _other.token;
            this.totalSize = _other.totalSize;
            this.usedSize = _other.usedSize;
            this.engine = _other.engine;
            this.address = _other.address;
            this.scope = _other.scope;
            this.accessKey = _other.accessKey;
            this.accessSecret = _other.accessSecret;
            this.url = _other.url;
            this._engine = engineToString(this.engine);
            this._totalSize = Utility.FormatSize(this.totalSize);
            this._usedSize = Utility.FormatSize(this.usedSize);
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged(this, new PropertyChangedEventArgs("name"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("token"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("totalSize"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("usedSize"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("engine"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("address"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("scope"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("accessKey"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("accessSecret"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("url"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_engine"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_totalSize"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_usedSize"));
        }
    }

    public class ObjectEntity : INotifyPropertyChanged
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public long size { get; set; }
        public string hash { get; set; }

        public string _size { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPrepertyChanged(string _propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
        }
    }

    public class BucketListReply : Reply
    {
        public long total { get; set; }
        public BucketEntity[] entity { get; set; }
    }

    public class ObjectListReply : Reply
    {
        public long total { get; set; }
        public ObjectEntity[] entity { get; set; }
    }

    public class BucketGetReply : Reply
    {
        public BucketEntity entity { get; set; }
    }

    public class ObjectPrepareReply : Reply
    {
        public int engine { get; set; }
        public string url { get; set; }
        public string accessToken { get; set; }
    }


    public class PublishReply : Reply
    {
        public string url { get; set; }
    }

}
