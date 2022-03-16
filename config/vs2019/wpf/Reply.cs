
namespace ogm.config
{
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

    public class TextEntity
    {
        public string uuid { get; set; }
        public string path { get; set; }
        public string content { get; set; }
    }


    public class TextListReply : Reply
    {
        public long total { get; set; }
        public TextEntity[] entity { get; set; }
    }
}
