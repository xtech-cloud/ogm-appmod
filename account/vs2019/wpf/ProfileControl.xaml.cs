
using System.Windows.Controls;
using System.Collections.Generic;

namespace ogm.account
{
    public partial class ProfileControl: UserControl
    {
        public class ProfileUiBridge : BaseProfileUiBridge, IProfileExtendUiBridge
        {
        }

        public ProfileFacade facade { get; set; }

        public ProfileControl()
        {
            InitializeComponent();
        }
    }
}
