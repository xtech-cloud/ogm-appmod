
using System.ComponentModel;
using System.Windows;

namespace ogm.permission
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

    public class UuidReply : Reply
    {
        public string uuid { get; set; }
    }

    public class ScopeEntity : INotifyPropertyChanged
    {
        public string uuid { get; set; }
        public string key { get; set; }
        public string name { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Refresh()
        {
            if (null == PropertyChanged)
                return;
            this.PropertyChanged(this, new PropertyChangedEventArgs("uuid"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("key"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("name"));
        }
    }

    public class RuleEntity : INotifyPropertyChanged
    {
        public string uuid { get; set; }
        public string scope { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public int state
        {
            get
            {
                return state_;
            }
            set
            {
                state_ = value;
                _waitVisibility = state_ == 0 ? Visibility.Visible : Visibility.Collapsed;
                _acceptVisibility = state_ == 1 ? Visibility.Visible : Visibility.Collapsed;
                _rejectVisibility = state_ == 2 ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        public Visibility _waitVisibility { get; set; }
        public Visibility _acceptVisibility { get; set; }
        public Visibility _rejectVisibility { get; set; }

        private int state_ = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public void Refresh()
        {
            if (null == PropertyChanged)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs("uuid"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("scope"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("key"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("name"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("state"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_waitVisibility"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_acceptVisibility"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_rejectVisibility"));
        }
    }


    public class ScopeListReply : Reply
    {
        public long total { get; set; }
        public ScopeEntity[] entity { get; set; }
        public ScopeListReply()
        {
            entity = new ScopeEntity[0];
        }
    }

    public class RuleListReply : Reply
    {
        public long total { get; set; }
        public RuleEntity[] entity { get; set; }
        public RuleListReply()
        {
            entity = new RuleEntity[0];
        }

    }

}
