using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Problem1UserControl
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public event LoginEventHandler Login; //publish login event;
        public LoginControl()
        {
            InitializeComponent();
        }


        public string Password
        {
            get { return txtPassword.Password; }
            set { txtPassword.Password = value; }
        }

        public string UserName
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }


        private void CancelClick(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = string.Empty;
            txtUsername.Text = string.Empty;
        }

        protected virtual void OnLogin(LoginEventArgs args) => Login?.Invoke(this, args);

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            OnLogin(new LoginEventArgs(txtUsername.Text, txtPassword.Password));
        }
    }
}
  