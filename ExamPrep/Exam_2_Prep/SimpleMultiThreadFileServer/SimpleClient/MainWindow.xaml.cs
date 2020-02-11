using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

namespace SimpleClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NetworkStream m_Stream;
        private StreamWriter m_Writer;
        private StreamReader m_Reader;
        private Thread m_ReadThread;
        private Thread m_ListenerThread;
        private string m_Message = "";
        private string m_ClientName = "ClientOne";
        private TcpClient m_Client;

        public MainWindow()
        {
            InitializeComponent();
            m_ReadThread = new Thread(RunClient);
            m_ReadThread.Start();
        }

        private void RunClient()
        {
            try
            {
                DisplayMessage($"[{DateTime.Now}] Status Update: Attempting connection...");

                m_Client = new TcpClient();

                for (int i = 0; i < 3; i++)
                {
                    m_Client.Connect("127.0.0.1", 50000);
                    if (m_Client.Connected)
                    {
                        m_Stream = m_Client.GetStream();
                        m_Reader = new StreamReader(m_Stream, Encoding.ASCII);
                        m_Writer = new StreamWriter(m_Stream, Encoding.ASCII);
                        DisplayMessage($"[{DateTime.Now}] Status Update: Connection with server established!");
                        break;
                    }

                    if (i < 2)
                    {
                        DisplayMessage(
                            $"[{DateTime.Now}] Status Update: Failed to connect to server. Attempting again in 3 seconds...");
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        DisplayMessage($"[{DateTime.Now}] Status Update: Failed to connect to server.");
                        m_Client?.Close();
                    }
                }

                m_ListenerThread = new Thread(Listen);
                m_ListenerThread.Name = "Client Listener";
                m_ListenerThread.Start();
            }
            catch (Exception e)
            {
                DisplayMessage(
                    $"[{DateTime.Now}] Connection Error: An error occured while attempting to connect. \n Wrong Ip or unavailable server.\n {e}");
                Close();
            }
        }


        private void Listen()
        {
            EnableInput(true);

            try
            {
                try
                {
                    while (m_Client.Connected)
                    {
                        if (m_Client.Available > 0)
                        {
                            var msg = m_Reader.ReadToEnd();
                            DisplayMessage("\r\n" + msg);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
                    }
                }
                catch (Exception e)
                {
                    DisplayMessage($"[{DateTime.Now}] Error: Disconnected from server!");
                }
                finally
                {
                    if (!m_Client.Connected)
                    {
                        DisplayMessage($"[{DateTime.Now}] Status Update: Disconnected from server!");
                    }

                    m_Reader.Close();
                    m_Writer.Close();
                    m_Client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void Tb_Input_OnKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && Tb_Input.IsEnabled)
                {
                    if (m_Client.Connected)
                    {
                        m_Writer.WriteLine($"{m_ClientName} {Tb_Input.Text}");
                        m_Writer.Flush();
                    }

                    TxtDisplay.Text += $"\r\n[{DateTime.Now} You >> " + Tb_Input.Text;
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