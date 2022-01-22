
using System.Windows.Controls;
using System.Collections.Generic;

namespace ogm.analytics
{
    public partial class TrackerControl: UserControl
    {
        public class TrackerUiBridge : BaseTrackerUiBridge, ITrackerExtendUiBridge
        {
        }

        public TrackerFacade facade { get; set; }

        public TrackerControl()
        {
            InitializeComponent();
        }
    }
}
