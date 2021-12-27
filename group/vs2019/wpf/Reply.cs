
namespace ogm.group
{
    public class CollectionEntity
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public long capacity { get; set; }
    }

    public class ElementEntity
    {
        public string uuid { get; set; }
        public string key { get; set; }
        public string alias { get; set; }
        public string[] label
        {
            get
            {
                return label_;
            }

            set
            {
                label_ = value;
                if (null != label_)
                {
                    _label = "";
                    foreach (var label in value)
                        _label += label + ",";
                    if (_label.Length > 0)
                        _label = _label.Remove(_label.Length - 1, 1);
                }
            }
        }
        public string _label { get; set; }

        private string[] label_;
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

    public class CollectionListReply : Reply
    {
        public long total { get; set; }
        public CollectionEntity[] entity { get; set; }

        public CollectionListReply()
        {
            entity = new CollectionEntity[0];
        }
    }

    public class ElementListReply : Reply
    {
        public long total { get; set; }
        public ElementEntity[] entity { get; set; }

        public ElementListReply()
        {
            entity = new ElementEntity[0];
        }
    }

}
