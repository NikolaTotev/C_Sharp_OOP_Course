using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1UserControl
{
    public delegate void LoginEventHandler(object sender, LoginEventArgs args);
    public class LoginEventArgs
    {
        private string userName;
        private string password;

        public string Password
        {
            get { return password; }
            private set { password = value; }
        }


        public string UserName
        {
            get { return userName; }
            private set { userName = value; }
        }

        public LoginEventArgs(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
