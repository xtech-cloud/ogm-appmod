using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using HandyControl.Controls;

namespace ogm.license
{
    public partial class KeyControl : UserControl
    {
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();

        public class KeyUiBridge : BaseKeyUiBridge, IKeyExtendUiBridge
        {
            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/license/Key/Generate");
                control.PermissionEdit = _permission.ContainsKey("/ogm/license/Key/Update");
                control.PermissionActivate = _permission.ContainsKey("/ogm/license/Key/Activate");
                control.PermissionDelete = _permission.ContainsKey("/ogm/license/Key/Delete");
            }

            public override void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.KeyListResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }
                control.KeyList.Clear();
                foreach (var e in reply._key)
                {
                    var key = new KeyEntity();
                    key.entity = e;
                    key.Unpack();
                    control.KeyList.Add(key);
                }
            }

            public override void ReceiveActivate(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.KeyActivateResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }
                control.formActivate.Visibility = Visibility.Collapsed;
                control.getKey(reply._uuid.AsString());
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public override void ReceiveGenerate(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.KeyGenerateResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }
                control.formNewKey.Visibility = Visibility.Collapsed;
                control.listKey();
            }

            public override void ReceiveUpdate(string _json)
            {
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formEditKey.Visibility = Visibility.Collapsed;
                control.getKey(reply.uuid);
            }
            public override void ReceiveGet(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.KeyGetResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }

                foreach (var e in control.KeyList)
                {
                    if (e.uuid.Equals(reply._key._uuid.AsString()))
                    {
                        e.CopyFromOther(reply._key);
                        e.Refresh();
                        break;
                    }
                }
            }
        }

        public KeyFacade facade { get; set; }

        public ObservableCollection<KeyEntity> KeyList { get; set; }

        public static readonly DependencyProperty PermissionCreateProperty = DependencyProperty.Register("PermissionCreate", typeof(bool), typeof(KeyControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(KeyControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(KeyControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionActivateProperty = DependencyProperty.Register("PermissionActivate", typeof(bool), typeof(KeyControl), new PropertyMetadata(true));

        public bool PermissionCreate
        {
            get { return (bool)GetValue(PermissionCreateProperty); }
            set { SetValue(PermissionCreateProperty, value); }
        }

        public bool PermissionEdit
        {
            get { return (bool)GetValue(PermissionEditProperty); }
            set { SetValue(PermissionEditProperty, value); }
        }

        public bool PermissionDelete
        {
            get { return (bool)GetValue(PermissionDeleteProperty); }
            set { SetValue(PermissionDeleteProperty, value); }
        }

        public bool PermissionActivate
        {
            get { return (bool)GetValue(PermissionActivateProperty); }
            set { SetValue(PermissionActivateProperty, value); }
        }

        public KeyControl()
        {
            KeyList = new ObservableCollection<KeyEntity>();
            InitializeComponent();
            formEditKey.Visibility = Visibility.Collapsed;
            formNewKey.Visibility = Visibility.Collapsed;
            formActivate.Visibility = Visibility.Collapsed;
            tbSpace.IsEnabled = false;
        }

        public void RefreshWithExtra()
        {
            object o_space;
            if (!PageExtra.TryGetValue("space.name", out o_space))
                return;
            object o_uuid;
            if (!PageExtra.TryGetValue("space.uuid", out o_uuid))
                return;

            tbSpace.Uid = o_uuid as string;
            tbSpace.Text = o_space as string;
            listKey();
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbNumber.Text = "";
            tbStorage.Text = "";
            tbProfile.Text = "";
            nudCapacity.Value = 0;
            nudExpiry.Value = 0;
            nudBan.Value = 0;
            listKey();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNumber.Text) &&
                nudCapacity.Value > 0 &&
                nudExpiry.Value > 0 &&
                nudBan.Value > 0 &&
                string.IsNullOrEmpty(tbStorage.Text) &&
                string.IsNullOrEmpty(tbProfile.Text))
                listKey();
            else
                searchKey();
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IKeyViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["space"] = tbSpace.Uid;
            param["count"] = nudNewCount.Value;
            param["capacity"] = nudNewCapacity.Value;
            param["expiry"] = nudNewExpiry.Value;
            param["storage"] = tbNewStorage.Text;
            param["profile"] = tbNewProfile.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnGenerateSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewKey.Visibility = Visibility.Collapsed;
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgKeyList.SelectedItem as KeyEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            param["profile"] = tbEditProfile.Text;
            param["ban"] = nudEditBan.Value;
            param["reason"] = tbEditReason.Text;

            var bridge = facade.getViewBridge() as IKeyViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnUpdateSubmit(json);
        }

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditKey.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewKey.Visibility = Visibility.Visible;
            formEditKey.Visibility = Visibility.Collapsed;
            formActivate.Visibility = Visibility.Collapsed;
        }

        private void onKeySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formNewKey.Visibility = Visibility.Collapsed;
            var item = dgKeyList.SelectedItem as KeyEntity;
            if (null == item)
                return;

            tbEditNumber.Text = item.number;
            tbEditProfile.Text = item.profile;
            nudEditBan.Value = item.ban;
            tbEditReason.Text = item.reason;
            tbActivateNumber.Text = item.number;
            tbActivateConsumer.Text = "";
        }

        private void onEditKeyClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgKeyList.SelectedItem as KeyEntity;
            if (null == item)
                return;

            formEditKey.Visibility = Visibility.Visible;
            formNewKey.Visibility = Visibility.Collapsed;
            formActivate.Visibility = Visibility.Collapsed;

            tbEditNumber.Text = item.number;
            tbEditProfile.Text = item.profile;
            nudEditBan.Value = item.ban;
            tbEditReason.Text = item.reason;
        }

        private void OnActivateClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgKeyList.SelectedItem as KeyEntity;
            if (null == item)
                return;

            formActivate.Visibility = Visibility.Visible;
            formEditKey.Visibility = Visibility.Collapsed;
            formNewKey.Visibility = Visibility.Collapsed;

            tbActivateNumber.Text = item.number;
            tbActivateConsumer.Text = "";
        }


        private void onDeleteKeyClicked(object sender, RoutedEventArgs e)
        {
            /*
            var item = dgKeyList.SelectedItem as KeyEntity;
            if (null == item)
                return;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;

            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as IKeyViewBridge;
            bridge.OnDeleteSubmit(json);
            */
        }

        private void listKey()
        {
            var bridge = facade.getViewBridge() as IKeyViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["space"] = tbSpace.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void searchKey()
        {
            var bridge = facade.getViewBridge() as IKeyViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["space"] = tbSpace.Text;
            param["number"] = tbNumber.Text;
            param["capacity"] = nudCapacity.Value;
            param["expiry"] = nudExpiry.Value;
            param["ban"] = nudBan.Value;
            param["storage"] = tbStorage.Text;
            param["profile"] = tbProfile.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }

        private void getKey(string _uuid)
        {
            var bridge = facade.getViewBridge() as IKeyViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = _uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnGetSubmit(json);
        }

        private void onActivateSubmitClicked(object sender, RoutedEventArgs e)
        {
            var item = dgKeyList.SelectedItem as KeyEntity;
            if (null == item)
                return;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["space"] = tbSpace.Text;
            param["number"] = tbActivateNumber.Text;
            param["consumer"] = tbActivateConsumer.Text;
            var bridge = facade.getViewBridge() as IKeyViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnActivateSubmit(json);
        }

        private void onActivateCancelClicked(object sender, RoutedEventArgs e)
        {
            formActivate.Visibility = Visibility.Collapsed;
        }
    }
}
