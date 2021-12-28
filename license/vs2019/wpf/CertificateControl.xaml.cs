
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text.Json;
using HandyControl.Controls;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace ogm.license
{
    public partial class CertificateControl : UserControl
    {
        public Dictionary<string, object> PageExtra = new Dictionary<string, object>();
        public class CertificateUiBridge : BaseCertificateUiBridge, ICertificateExtendUiBridge
        {
            public override void Alert(string _message)
            {
                Growl.Warning(_message, "StatusGrowl");
            }

            public override void ReceiveList(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.CerListResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }
                control.CerList.Clear();
                foreach (var e in reply._cer)
                {
                    var cer = new CertificateEntity();
                    cer.entity = e;
                    cer.Unpack();
                    control.CerList.Add(cer);
                }
            }

            public override void ReceiveSearch(string _json)
            {
                ReceiveList(_json);
            }

            public override void ReceiveGet(string _json)
            {
                var reply = JsonSerializer.Deserialize<Proto.CerGetResponse>(_json, JsonOptions.DefaultSerializerOptions);
                if (reply._status._code.AsInt32() != 0)
                {
                    Alert(reply._status._message.AsString());
                    return;
                }

                SaveFileDialog dialog = new SaveFileDialog();
                dialog.FileName = "app.cer";
                if(true == dialog.ShowDialog())
                {
                    File.WriteAllText(dialog.FileName, reply._cer._content.AsString());
                }
            }
        }

        public CertificateFacade facade { get; set; }
        public ObservableCollection<CertificateEntity> CerList { get; set; }

        public CertificateControl()
        {
            CerList = new ObservableCollection<CertificateEntity>();
            InitializeComponent();
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
            listCer();
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbConsumer.Text = "";
            tbNumber.Text = "";
            listCer();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNumber.Text) && string.IsNullOrEmpty(tbConsumer.Text))
            {
                listCer();
            }
            else
            {
                searchCer();
            }
        }

        private void listCer()
        {
            var bridge = facade.getViewBridge() as ICertificateViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["space"] = tbSpace.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void searchCer()
        {
            var bridge = facade.getViewBridge() as ICertificateViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            param["number"] = tbNumber.Text;
            param["consumer"] = tbConsumer.Text;
            param["space"] = tbSpace.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSearchSubmit(json);
        }

        private void getCer(string _uuid)
        {
            var bridge = facade.getViewBridge() as ICertificateViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = _uuid;
            string json = JsonSerializer.Serialize(param);
            bridge.OnGetSubmit(json);
        }

        private void OnDownloadClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgCerList.SelectedItem as CertificateEntity;
            if (null == item)
                return;
            getCer(item.uuid);
        }
    }
}
