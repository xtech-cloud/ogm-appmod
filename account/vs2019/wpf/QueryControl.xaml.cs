using System.Text.Json;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Windows;

namespace ogm.account
{
    public partial class QueryControl : UserControl
    {
        public class QueryUiBridge : BaseQueryUiBridge, IQueryExtendUiBridge
        {
            public void HandleTabActivated()
            {
                if (string.IsNullOrEmpty(control.tbUsername.Text) && control.AccountList.Count == 0)
                    control.listAccount();
            }

            public override void ReceiveList(string _json)
            {
                base.ReceiveList(_json);

                QueryListReply reply = JsonSerializer.Deserialize<QueryListReply>(_json);
                control.AccountList.Clear();
                foreach (var account in reply.account)
                {
                    DateTime startTime = TimeZoneInfo.ConvertTimeFromUtc(new System.DateTime(1970, 1, 1, 0, 0, 0), TimeZoneInfo.Local);
                    long lTime = account.createdAt * 10000000;
                    account._createdAt = startTime.Add(new TimeSpan(lTime)).ToString();
                    control.AccountList.Add(account);
                }
            }

            public override void ReceiveSingle(string _json)
            {
                base.ReceiveList(_json);
                QuerySingleReply reply = JsonSerializer.Deserialize<QuerySingleReply>(_json);
                control.AccountList.Clear();
                if (null == reply.account || string.IsNullOrEmpty(reply.account.uuid))
                    return;
                DateTime startTime = TimeZoneInfo.ConvertTimeFromUtc(new System.DateTime(1970, 1, 1, 0, 0, 0), TimeZoneInfo.Local);
                long lTime = reply.account.createdAt * 10000000;
                reply.account._createdAt = startTime.Add(new TimeSpan(lTime)).ToString();
                control.AccountList.Add(reply.account);
            }
        }

        public QueryFacade facade { get; set; }
        public ObservableCollection<AccountEntity> AccountList { get; set; }
        public QueryControl()
        {
            AccountList = new ObservableCollection<AccountEntity>();
            InitializeComponent();
        }

        private void onResetCliked(object sender, System.Windows.RoutedEventArgs e)
        {
            tbUsername.Text = "";
            listAccount();
        }

        private void onSearchClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text))
            {
                listAccount();
            }
            else
            {
                searchAccount(tbUsername.Text);
            }

        }

        private void onAccountSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OnResetPasswordClick(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void OnCopyUUIDClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgAccount.SelectedItem as AccountEntity;
            if (null == item)
                return;
            Clipboard.SetDataObject(item.uuid);
        }

        private void listAccount()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            var bridge = facade.getViewBridge() as IQueryViewBridge;
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void searchAccount(string _username)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            var bridge = facade.getViewBridge() as IQueryViewBridge;
            param["field"] = 2;
            param["value"] = tbUsername.Text;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSingleSubmit(json);
        }
    }
}
