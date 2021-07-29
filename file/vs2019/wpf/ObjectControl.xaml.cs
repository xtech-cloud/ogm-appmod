
using System.Windows.Controls;

namespace ogm.file
{
    public partial class ObjectControl: UserControl
    {
        public class ObjectUiBridge : IObjectUiBridge
        {
            public ObjectControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }
        }

        public ObjectFacade facade { get; set; }

        public ObjectControl()
        {
            InitializeComponent();
        }
    }
}
