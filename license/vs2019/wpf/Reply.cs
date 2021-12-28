
using System;
using System.ComponentModel;
using System.Windows;

namespace ogm.license
{
    public class Utility
    {
        public static string FormatTimestamp(long _value)
        {
            if (0 == _value)
                return "";

            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = ((long)_value * 10000000);
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime targetDt = dtStart.Add(toNow);
            return targetDt.ToString();
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

    public class SpaceEntity : INotifyPropertyChanged
    {
        public Proto.SpaceEntity entity { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string secret { get; set; }
        public string profile { get; set; }

        public Visibility secretVisibility { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Unpack(bool _permiossionCreate)
        {
            uuid = entity._uuid.AsString();
            name = entity._name.AsString();
            profile = entity._profile.AsString();
            key = entity._spaceKey.AsString();
            secret = _permiossionCreate ? entity._spaceSecret.AsString() : "********************************";
        }

        public void CopyFromOther(Proto.SpaceEntity _entity, bool _permissionCreate)
        {
            entity = _entity;
            Unpack(_permissionCreate);
        }

        public void Refresh()
        {
            if (null == PropertyChanged)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs("profile"));

        }
    }

    public class KeyEntity : INotifyPropertyChanged
    {
        public Proto.KeyEntity entity { get; set; }

        public string uuid { get; set; }
        public string number { get; set; }
        public string capacity { get; set; }
        public int expiry { get; set; }
        public string storage { get; set; }
        public string profile { get; set; }
        public string createdAt { get; set; }
        public string activatedAt { get; set; }
        public int ban { get; set; }
        public string reason { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Unpack()
        {
            uuid = entity._uuid.AsString();
            number = entity._number.AsString();
            capacity = string.Format("{0}/{1}", entity._consumer.AsStringAry().Length, entity._capacity.AsInt32());
            expiry = entity._expiry.AsInt32();
            storage = entity._storage.AsString();
            profile = entity._profile.AsString();
            ban = entity._ban.AsInt32();
            reason = entity._reason.AsString();
            createdAt = Utility.FormatTimestamp(entity._createdAt.AsInt64());
            activatedAt = Utility.FormatTimestamp(entity._activatedAt.AsInt64());
        }

        public void CopyFromOther(Proto.KeyEntity _entity)
        {
            entity = _entity;
            Unpack();
        }

        public void Refresh()
        {
            if (null == PropertyChanged)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs("profile"));
            PropertyChanged(this, new PropertyChangedEventArgs("ban"));
            PropertyChanged(this, new PropertyChangedEventArgs("reason"));
            PropertyChanged(this, new PropertyChangedEventArgs("capacity"));
            PropertyChanged(this, new PropertyChangedEventArgs("activatedAt"));

        }
    }

    public class CertificateEntity
    {
        public Proto.CertificateEntity entity { get; set; }
        public string uuid { get; set; }
        public string number { get; set; }
        public string consumer { get; set; }
        public string content { get; set; }
        public string createdAt { get; set; }

        public void Unpack()
        {

            uuid = entity._uuid.AsString();
            number = entity._number.AsString();
            consumer = entity._consumer.AsString();
            content = entity._content.AsString();
            createdAt = Utility.FormatTimestamp(entity._createdAt.AsInt64());
        }
    }

}
