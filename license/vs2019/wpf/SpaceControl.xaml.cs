using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text.Json;
using HandyControl.Controls;

namespace ogm.license
{
    public partial class SpaceControl : UserControl
    {
        public class SpaceUiBridge : BaseSpaceUiBridge, ISpaceExtendUiBridge
        {
            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionCreate = _permission.ContainsKey("/ogm/license/Space/Create");
                control.PermissionEdit = _permission.ContainsKey("/ogm/license/Space/Update");
                control.PermissionDelete = _permission.ContainsKey("/ogm/license/Space/Delete");
                //协议未实现功能
                control.PermissionDelete = false;
            }

            public override void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.SpaceListResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }
                control.SpaceList.Clear();
                foreach (var e in reply._space)
                {
                    var space = new SpaceEntity();
                    space.entity = e;
                    space.Unpack(control.PermissionCreate);
                    control.SpaceList.Add(space);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public override void ReceiveCreate(string _json)
            {
                base.ReceiveCreate(_json);
                var reply = JsonSerializer.Deserialize<Proto.BlankResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }
                control.formNewSpace.Visibility = Visibility.Collapsed;
                control.listSpace();
            }

            public override void ReceiveUpdate(string _json)
            {
                var reply = JsonSerializer.Deserialize<UuidReply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formEditSpace.Visibility = Visibility.Collapsed;
                control.getSpace(reply.uuid);
            }
            public override void ReceiveGet(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.SpaceGetResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }

                foreach(var e in control.SpaceList)
                {
                    if(e.uuid.Equals(reply._space._uuid.AsString()))
                    {
                        e.CopyFromOther(reply._space, control.PermissionCreate);
                        e.Refresh();
                        break;
                    }
                }
            }

            /*
            public override void ReceiveDelete(string _json)
            {
                var reply = JsonSerializer.Deserialize<Reply>(_json);
                if (reply.status.code != 0)
                {
                    Alert(reply.status.message);
                    return;
                }
                control.formEditDomain.Visibility = Visibility.Collapsed;
                control.formNewDomain.Visibility = Visibility.Collapsed;
                control.listDomain();
            }
            */

            public void HandleTabActivated()
            {
                control.listSpace();
            }
        }

        public SpaceFacade facade { get; set; }

        public KeyControl controlKey { get; set; }
        public CertificateControl controlCertificate { get; set; }
        public ObservableCollection<SpaceEntity> SpaceList { get; set; }

        public static readonly DependencyProperty PermissionCreateProperty = DependencyProperty.Register("PermissionCreate", typeof(bool), typeof(SpaceControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionEditProperty = DependencyProperty.Register("PermissionEdit", typeof(bool), typeof(SpaceControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionDeleteProperty = DependencyProperty.Register("PermissionDelete", typeof(bool), typeof(SpaceControl), new PropertyMetadata(true));

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

        public SpaceControl()
        {
            SpaceList = new ObservableCollection<SpaceEntity>();
            InitializeComponent();
            formEditSpace.Visibility = Visibility.Collapsed;
            formNewSpace.Visibility = Visibility.Collapsed;
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbName.Text = "";
            listSpace();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                listSpace();
            }
            else
            {
                searchSpace();
            }
        }

        private void onNewSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as ISpaceViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["name"] = tbNewName.Text;
            param["profile"] = tbNewProfile.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnCreateSubmit(json);
        }

        private void onNewCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewSpace.Visibility = Visibility.Collapsed;
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgSpaceList.SelectedItem as SpaceEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid; 
            param["profile"] = tbEditProfile.Text;

            var bridge = facade.getViewBridge() as ISpaceViewBridge;
            string json = JsonSerializer.Serialize(param);
            bridge.OnUpdateSubmit(json);
        }

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditSpace.Visibility = Visibility.Collapsed;
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formNewSpace.Visibility = Visibility.Visible;
            formEditSpace.Visibility = Visibility.Collapsed;
        }

        private void onSpaceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formNewSpace.Visibility = Visibility.Collapsed;
            var item = dgSpaceList.SelectedItem as SpaceEntity;
            if (null == item)
                return;

            tbEditName.Text = item.name;
            tbEditProfile.Text = item.profile;
        }

        private void onEditSpaceClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgSpaceList.SelectedItem as SpaceEntity;
            if (null == item)
                return;
            formEditSpace.Visibility = Visibility.Visible;
            formNewSpace.Visibility = Visibility.Collapsed;

            tbEditName.Text = item.name;
            tbEditProfile.Text = item.profile;
        }

        private void OnBrowseKeyClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgSpaceList.SelectedItem as SpaceEntity;
            if (null == item)
                return;

            controlKey.PageExtra["space.name"] = item.name;
            controlKey.PageExtra["space.uuid"] = item.uuid;
            controlKey.RefreshWithExtra();
            var bridge = facade.getViewBridge() as ISpaceExtendViewBridge;
            bridge.OnOpenKeyUi();
        }

        private void OnBrowseCertificateClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgSpaceList.SelectedItem as SpaceEntity;
            if (null == item)
                return;

            controlCertificate.PageExtra["space.name"] = item.name;
            controlCertificate.PageExtra["space.uuid"] = item.uuid;
            controlCertificate.RefreshWithExtra();
            var bridge = facade.getViewBridge() as ISpaceExtendViewBridge;
            bridge.OnOpenCertificateUi();
        }


        private void onDeleteSpaceClicked(object sender, RoutedEventArgs e)
        {
            var item = dgSpaceList.SelectedItem as SpaceEntity;
            if (null == item)
                return;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["name"] = item.name;

            string json = JsonSerializer.Serialize(param);
            var bridge = facade.getViewBridge() as ISpaceViewBridge;
            //bridge.OnDeleteSubmit(json);
        }

        private void listSpace()
        {
            var bridge = facade.getViewBridge() as ISpaceViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void searchSpace()
        {
            var bridge = facade.getViewBridge() as ISpaceViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["name"] = tbName.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }

        private void getSpace(string _uuid)
        {
            var bridge = facade.getViewBridge() as ISpaceViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = _uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnGetSubmit(json);
        }

    }
}
