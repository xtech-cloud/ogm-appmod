
using System.Windows.Controls;

namespace ogm.account
{
    public partial class QueryControl: UserControl
    {
        public class QueryUiBridge : IQueryUiBridge
        {
            public QueryControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
            }
        }

        public QueryFacade facade { get; set; }

        public QueryControl()
        {
            InitializeComponent();
        }
    }
}
