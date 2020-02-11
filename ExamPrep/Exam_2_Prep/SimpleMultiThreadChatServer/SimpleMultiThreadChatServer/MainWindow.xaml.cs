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

namespace SimpleMultiThreadChatServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChatServer m_Server;
        public MainWindow()
        {
            InitializeComponent();
            m_Server = new ChatServer();
            m_Server.Start();
            m_Server.MessageReceived += UpdateUI;
        }

        private void UpdateUI(string message)
        {

        }
    }
}
