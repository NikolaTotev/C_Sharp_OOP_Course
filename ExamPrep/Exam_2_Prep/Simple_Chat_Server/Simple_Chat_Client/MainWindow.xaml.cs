using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Input;

namespace Simple_Chat_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private NetworkStream m_Output;
        private BinaryWriter m_Writer;
        private BinaryReader m_Reader;
        private Thread m_ReadThread;
        private string m_Message = "";

        public MainWindow()
        {
            InitializeComponent();
            m_ReadThread = new Thread(RunClient);
            m_ReadThread.Start();
        }

        private void RunClient()
        {
            TcpClient client;

            try
            {
                DisplayMessage("Attempting Connection\r\n");

                client = new TcpClient();
                client.Connect("127.0.0.1", 50000);

                m_Output = client.GetStream();

                m_Writer = new BinaryWriter(m_Output);
                m_Reader = new BinaryReader(m_Output);

                DisplayMessage("\r\nGot I/O streams\r\n");
                EnableInput(true);

                do
                {
                    try
                    {
                        m_Message = m_Reader.ReadString();
                        DisplayMessage("\r\n" + m_Message);
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                }
                while (m_Message != "Server >> Terminate");

                m_Writer?.Close();
                m_Reader?.Close();
                m_Output?.Close();
                client?.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Tb_Input_OnKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && Tb_Input.IsEnabled)
                {
                    m_Writer.Write("Client >> " + Tb_Input.Text);
                    TxtDisplay.Text += "\r\nClient >> " + Tb_Input.Text;
                    Tb_Input.Clear();
                }
            }
            catch (SocketException exception)
            {
                TxtDisplay.Text += "\nError writing object.";
                throw;
            }
        }

        private void DisplayMessage(string message)
        {
            if (TxtDisplay.Dispatcher != null && !TxtDisplay.Dispatcher.CheckAccess())
            {
                TxtDisplay.Dispatcher.Invoke(new Action(() => TxtDisplay.Text += message));
            }
            else
            {
                TxtDisplay.Text += message;
            }
        }

        private void EnableInput(bool value)
        {
            if (Tb_Input.Dispatcher != null && !Tb_Input.Dispatcher.CheckAccess())
            {
                Tb_Input.Dispatcher.Invoke(new Action(() => Tb_Input.IsEnabled = value));
            }
            else
            {
                Tb_Input.IsEnabled = value;
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
