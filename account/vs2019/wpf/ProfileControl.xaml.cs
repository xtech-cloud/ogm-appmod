
using System.Windows.Controls;

namespace ogm.account
{
    public partial class ProfileControl: UserControl
    {
        public class ProfileUiBridge : IProfileUiBridge
        {
            public ProfileControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }
        }

        public ProfileFacade facade { get; set; }

        public ProfileControl()
        {
            InitializeComponent();
        }
    }
}
