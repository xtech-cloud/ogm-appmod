
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace ogm.actor
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

    public class ApplicationEntity : INotifyPropertyChanged
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public string version { get; set; }
        public string program { get; set; }
        public string location { get; set; }
        public string url { get; set; }

        public int upgrade
        {
            get { return upgrade_; }
            set
            {
                upgrade_ = value;
                _noUpgradeVisibility = upgrade_ == 1 ? Visibility.Visible : Visibility.Collapsed;
                _autoUpgradeVisibility = upgrade_ == 2 ? Visibility.Visible : Visibility.Collapsed;
                _manualUpgradeVisibility = upgrade_ == 3 ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        private int upgrade_ { get; set; }

        public Visibility _noUpgradeVisibility { get; set; }
        public Visibility _autoUpgradeVisibility { get; set; }
        public Visibility _manualUpgradeVisibility { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CopyFromOther(ApplicationEntity _other)
        {
            if (!_other.uuid.Equals(uuid))
                return;
            name = _other.name;
            version = _other.version;
            program = _other.program;
            location = _other.location;
            url = _other.url;
            upgrade = _other.upgrade;
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged(this, new PropertyChangedEventArgs("name"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("version"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("program"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("location"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("upgrade"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_noUpgradeVisibility"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_autoUpgradeVisibility"));
            this.PropertyChanged(this, new PropertyChangedEventArgs("_manualUpgradeVisibility"));
        }
    }

    public class DomainEntity : INotifyPropertyChanged
    {
        public string uuid { get; set; }
        public string name { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void CopyFromOther(DomainEntity _other)
        {
            if (!_other.uuid.Equals(uuid))
                return;
            name = _other.name;
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged(this, new PropertyChangedEventArgs("name"));
        }
    }


    public class DeviceEntity : INotifyPropertyChanged
    {
        public string uuid { get; set; }
        public string serialNumber { get; set; }
        public string name { get; set; }
        public string operatingSystem { get; set; }
        public string systemVersion { get; set; }
        public string shape { get; set; }
        public int _access
        {
            get { return _access_; }
            set
            {
                _access_ = value;
                _waitVisibility = _access == 0 ? Visibility.Visible : Visibility.Collapsed;
                _acceptVisibility = _access == 1 ? Visibility.Visible : Visibility.Collapsed;
                _rejectVisibility = _access == 2 ? Visibility.Visible : Visibility.Collapsed;
                OnPrepertyChanged("_waitVisibility");
                OnPrepertyChanged("_acceptVisibility");
                OnPrepertyChanged("_rejectVisibility");
            }
        }

        public string _alias
        {
            get { return _alias_; }
            set { _alias_ = value; OnPrepertyChanged("_alias"); }
        }

        public int battery { get; set; }
        public int controllerBattery { get; set; }
        public int volume { get; set; }
        public int brightness { get; set; }
        public long storageAvailable { get; set; }
        public int networkStrength { get; set; }
        public string _application { get; set; }
        public int _healthy { get; set; }
        public string _storageAvailable { get; set; }
        public ImageSource _batteryIcon { get; set; }
        public ImageSource _controllerIcon { get; set; }
        public ImageSource _healthyIcon { get; set; }
        public ImageSource _capture { get; set; }
        public Visibility _waitVisibility { get; set; }
        public Visibility _acceptVisibility { get; set; }
        public Visibility _rejectVisibility { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPrepertyChanged(string _propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged(this, new PropertyChangedEventArgs(_propertyName));
        }

        private string _alias_;
        private int _access_;

        public void CopyFromOther(DeviceEntity _other)
        {
            battery = _other.battery;
            volume = _other.volume;
            brightness = _other.brightness;
            storageAvailable = _other.storageAvailable;
            networkStrength = _other.networkStrength;
            _alias = _other._alias;
            _application = _other._application;
            _storageAvailable = _other._storageAvailable;
            _batteryIcon = _other._batteryIcon;
            _healthyIcon = _other._healthyIcon;
            if (null != _other._capture)
            {
                _capture = _other._capture;
                OnPrepertyChanged("_capture");
            }
            OnPrepertyChanged("battery");
            OnPrepertyChanged("volume");
            OnPrepertyChanged("brightness");
            OnPrepertyChanged("storageAvailable");
            OnPrepertyChanged("networkStrength");
            OnPrepertyChanged("_alias");
            OnPrepertyChanged("_application");
            OnPrepertyChanged("_storageAvailable");
            OnPrepertyChanged("_batteryIcon");
            OnPrepertyChanged("_healthyIcon");
            OnPrepertyChanged("_controllerIcon");
        }
    }

    public class ApplicationListReply : Reply
    {
        public long total { get; set; }
        public ApplicationEntity[] application { get; set; }
    }

    public class DomainGetReply : Reply
    {
        public DomainEntity domain { get; set; }
    }

    public class ApplicationGetReply : Reply
    {
        public ApplicationEntity application { get; set; }
    }

    public class DomainListReply : Reply
    {
        public long total { get; set; }
        public DomainEntity[] domain { get; set; }
    }

    public class DeviceListReply : Reply
    {
        public long total { get; set; }
        public DeviceEntity[] device { get; set; }
    }

    public class GuardFetchReply : Reply
    {
        public long total { get; set; }
        public DeviceEntity[] device { get; set; }
        public Dictionary<string, int> access { get; set; }
        public Dictionary<string, string> alias { get; set; }

    }

    public class SyncPullReply : Reply
    {
        public DeviceEntity[] device { get; set; }
        public Dictionary<string, string> alias { get; set; }
        public Dictionary<string, string> property { get; set; }
        public Dictionary<string, int> healthy { get; set; }
    }
}
