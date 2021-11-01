
using System.Windows.Controls;

namespace ogm.actor
{
    public partial class DomainControl: UserControl
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
        }

        public DomainFacade facade { get; set; }

        public DomainControl()
        {
            InitializeComponent();
        }
    }
}
