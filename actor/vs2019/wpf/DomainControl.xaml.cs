
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Controls;

namespace ogm.actor
{
    public partial class DomainControl : UserControl
    {
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
                control.cbDomainList.Items.Clear();
                DomainEntity[] domainList = JsonSerializer.Deserialize<DomainEntity[]>(_reply);
                foreach (var entity in domainList)
                {
                    var item = new ComboBoxItem();
                    item.Content = entity.name;
                    item.Uid = entity.uuid;
                    control.cbDomainList.Items.Add(item);
                }
            }
        }

        public class DomainEntity
        {
            public string uuid { get; set; }
            public string name { get; set; }
        }

        public DomainFacade facade { get; set; }

        public DomainControl()
        {
            InitializeComponent();
        }

        private void onCreateClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
