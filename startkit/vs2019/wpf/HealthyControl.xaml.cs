
using System.Windows.Controls;

namespace ogm.startkit
{
    public partial class HealthyControl: UserControl
    {
        public class HealthyUiBridge : IHealthyUiBridge
        {
            public HealthyControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }
        }

        public HealthyFacade facade { get; set; }

        public HealthyControl()
        {
            InitializeComponent();
        }
    }
}
