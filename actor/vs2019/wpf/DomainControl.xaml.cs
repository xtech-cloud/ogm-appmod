using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ogm.actor
{
    public partial class DomainControl : UserControl
    {
        public class DomainEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
        }

        public class DomainUiBridge : IDomainUiBridge
        {
            public DomainControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }

            public void RefreshList(string _reply)
            {
                control.DomainList.Clear();
                var list = JsonSerializer.Deserialize<DomainEntity[]>(_reply);
                foreach (var e in list)
                {
                    control.DomainList.Add(e);
                }
            }

            public void RefreshFetchDevice(string _reply)
            {
            }
        }

        public DomainFacade facade { get; set; }
        public ObservableCollection<DomainEntity> DomainList { get; set; }

        public DomainControl()
        {
            DomainList = new ObservableCollection<DomainEntity>();
            InitializeComponent();
            formEditDomain.Visibility = Visibility.Collapsed;
            formNewDomain.Visibility = Visibility.Collapsed;
        }

        private void onEditSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            Dictionary<string, object> param = new Dictionary<string, object>();
            param["uuid"] = item.uuid;
            param["name"] = tbEditName.Text;

            var bridge = facade.getViewBridge() as IDomainViewBridge;
            string json = JsonSerializer.Serialize(param);
            //bridge.OnUp(json);
        }

        private void onEditCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            formEditDomain.Visibility = Visibility.Collapsed;
        }

        private void onDomainSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            formNewDomain.Visibility = Visibility.Collapsed;
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;

            //tbEditName.Text = item.alias;
        }

        private void onEditDomainClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = dgDomainList.SelectedItem as DomainEntity;
            if (null == item)
                return;
            formEditDomain.Visibility = Visibility.Visible;
            formNewDomain.Visibility = Visibility.Collapsed;

            tbEditName.Text = item.name;
        }

        private void onCreateClicked(object sender, RoutedEventArgs e)
        {
            formNewDomain.Visibility = Visibility.Visible;
            formEditDomain.Visibility = Visibility.Collapsed;
        }

        private void onRefreshCliked(object sender, RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void onSearchClicked(object sender, RoutedEventArgs e)
        {
            var bridge = facade.getViewBridge() as IDomainViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["offset"] = 0;
            param["count"] = int.MaxValue;
            string json = JsonSerializer.Serialize(param);
            bridge.OnListSubmit(json);
        }

        private void onNewSubmitClicked(object sender, RoutedEventArgs e)
        {
            formEditDomain.Visibility = Visibility.Collapsed;
            formNewDomain.Visibility = Visibility.Visible;
        }

        private void onNewCancelClicked(object sender, RoutedEventArgs e)
        {
            formNewDomain.Visibility = Visibility.Collapsed;
        }
    }
}
