using System.Text.Json;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;

namespace ogm.account
{
    public partial class AuthControl : UserControl
    {
        public class AuthUiBridge : BaseAuthUiBridge, IAuthExtendUiBridge
        {
            public override void UpdatePermission(Dictionary<string, string> _permission)
            {
                control.PermissionSignup = _permission.ContainsKey("/ogm/account/Auth/Signup");
                control.PermissionSignin = _permission.ContainsKey("/ogm/account/Auth/Signin");
            }
        }

        public AuthFacade facade { get; set; }

        public static readonly DependencyProperty PermissionSignupProperty = DependencyProperty.Register("PermissionSignup", typeof(bool), typeof(AuthControl), new PropertyMetadata(true));
        public static readonly DependencyProperty PermissionSigninProperty = DependencyProperty.Register("PermissionSignin", typeof(bool), typeof(AuthControl), new PropertyMetadata(true));

        public bool PermissionSignup
        {
            get { return (bool)GetValue(PermissionSignupProperty); }
            set { SetValue(PermissionSignupProperty, value); }
        }

        public bool PermissionSignin
        {
            get { return (bool)GetValue(PermissionSigninProperty); }
            set { SetValue(PermissionSigninProperty, value); }
        }

        public AuthControl()
        {
            InitializeComponent();
        }

        private void onSignupSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSignupUsername.Text) || string.IsNullOrEmpty(tbSignupPassword.Password))
                return;
            var bridge = facade.getViewBridge() as IAuthViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["username"] = tbSignupUsername.Text;
            param["password"] = Utility.WrapPassword(tbSignupPassword.Password);
            string json = JsonSerializer.Serialize(param);
            bridge.OnSignupSubmit(json);
        }

        private void onSignupCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void onSigninSubmitClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSigninUsername.Text) || string.IsNullOrEmpty(tbSigninPassword.Password))
                return;
            var bridge = facade.getViewBridge() as IAuthViewBridge;
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["username"] = tbSigninUsername.Text;
            param["password"] = Utility.WrapPassword(tbSigninPassword.Password);
            param["strategy"] = 1;
            string json = JsonSerializer.Serialize(param);
            bridge.OnSigninSubmit(json);
        }

        private void onSigninCancelClicked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

      
    }
}
