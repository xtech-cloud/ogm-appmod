
using System.Windows.Controls;

namespace ogm.account
{
    public partial class AuthControl : UserControl
    {
        public class AuthUiBridge : IAuthUiBridge
        {
            public AuthControl control { get; set; }

            public object getRootPanel()
            {
                return control;
            }

            public void Alert(string _message)
            {
                HandyControl.Controls.Growl.Warning(_message, "StatusGrowl");
            }

            private void success(string _message)
            {
                HandyControl.Controls.Growl.Success(_message, "StatusGrowl");
            }

            public void RefreshSignupSuccess(string _uuid)
            {
                success(string.Format("uuid: {0}", _uuid));
                control.tbSignupUsername.Text = "";
                control.pbSignupPassword.Password= "";
            }
        }

        public AuthFacade facade { get; set; }

        public AuthControl()
        {
            InitializeComponent();
        }

        private void onSignupSubmit(object sender, System.Windows.RoutedEventArgs e)
        {
            string username = tbSignupUsername.Text;
            string password = pbSignupPassword.Password;
            var bridge = facade.getViewBridge() as IAuthViewBridge;
            bridge.OnSignupSubmit(username, password);
        }
    }
}
