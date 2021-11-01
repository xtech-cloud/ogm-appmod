
using System.Windows.Controls;

namespace ogm.actor
{
    public partial class SyncControl: UserControl
    {
        public class SyncUiBridge : ISyncUiBridge
        {
            public SyncControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }
        }

        public SyncFacade facade { get; set; }

        public SyncControl()
        {
            InitializeComponent();
        }
    }
}
