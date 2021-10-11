
using System.Windows.Controls;

namespace ogm.startkit
{
    public partial class MyHealthyControl: UserControl
    {
        public class MyHealthyUiBridge : IMyHealthyUiBridge
        {
            public MyHealthyControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }
        }

        public MyHealthyFacade facade { get; set; }

        public MyHealthyControl()
        {
            InitializeComponent();
        }
    }
}
