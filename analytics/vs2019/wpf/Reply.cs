
namespace ogm.analytics
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

    public class ActivityEntity
    {
        public string ID { get; set; }
        public string AppID { get; set; }
        public string DeviceID { get; set; }
        public string UserID { get; set; }
        public string EventID { get; set; }
        public string EventParameter { get; set; }
        public string CreatedAt { get; set; }
    }

    public class GeneratorRecordReply : Reply
    {
        public string content { get; set; }

    }
}
