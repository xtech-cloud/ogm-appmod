
namespace ogm.account
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

    public class AccountEntity
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public long createdAt { get; set; }

        public string _createdAt { get; set; }
    }

    public class QueryListReply : Reply
    {
        public long total { get; set; }
        public AccountEntity[] account { get; set; }

        public QueryListReply() : base()
        {
            account = new AccountEntity[0];
        }
    }

    public class QuerySingleReply : Reply
    {
        public AccountEntity account { get; set; }
    }

}
