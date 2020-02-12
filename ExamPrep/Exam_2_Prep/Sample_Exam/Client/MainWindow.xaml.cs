using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
using Components;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClientLogic m_Client;

        public delegate void RequestEventDelegate(RequestEventArgs args);
        public event RequestEventDelegate RequestClicked;

        public delegate void SaveEventDelegate(SaveEventArgs args);
        public event SaveEventDelegate SaveClicked;
        public MainWindow()
        {
            InitializeComponent();
            m_Client = new ClientLogic(this);
            m_Client.ClientNotification += DisplayMessage;
            m_Client.UpdateContent += UpdateContent;
            m_Client.Start();

            ClientControl.ButtonSaveClicked += Btn_SaveClick;
            ClientControl.ButtonRequestClicked += Btn_RequestClick;

        }

        private void UpdateContent(string message)
        {
            ClientControl.DisplayFileData(message);
        }

        public void Btn_SaveClick(object sender, SaveEventArgs args )
        {
            SaveClicked?.Invoke(args);
        }

        public void Btn_RequestClick(object sender, RequestEventArgs args)
        {
            RequestClicked?.Invoke(args);
        }

        private void DisplayMessage(string message)
        {
            if (Tb_Logs.Dispatcher != null && !Tb_Logs.Dispatcher.CheckAccess())
            {
                Tb_Logs.Dispatcher.Invoke(new Action(() => Tb_Logs.Text = $"\r\n{Tb_Logs.Text}" + message));
            }
            else
            {
                Tb_Logs.Text = $"\r\n{Tb_Logs.Text}" + message;
            }
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            m_Client.Stop();
        }
    }
}
