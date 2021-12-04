
namespace ogm.group
{
    public class CollectionEntity
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public long capacity { get; set; }
    }

    public class MemberEntity
    {
        public string uuid { get; set; }
        public string element { get; set; }
        public string alias { get; set; }
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

    public class MemberListReply : Reply
    {
        public long total { get; set; }
        public MemberEntity[] entity { get; set; }

        public MemberListReply()
        {
            entity = new MemberEntity[0];
        }
    }

}
