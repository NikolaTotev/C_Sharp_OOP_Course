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

namespace Simple_Chat_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Instance variables for networking purposes
        private Socket m_Connection;
        private Thread m_ReadThread;
        private NetworkStream m_SocketStream;
        private BinaryReader m_Reader;
        private BinaryWriter m_Writer;

        public MainWindow()
        {
            InitializeComponent();
            m_ReadThread = new Thread(RunServer);
            m_ReadThread.Start();

        }

        private void RunServer()
        {
            TcpListener listener;
            int counter = 1;

            try
            {
                //Step 1: Create TcpListener
                IPAddress local = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(local, 50000);

                //Step 2: TcpListener waits for connection request.
                listener.Start();

                //Step 3: Establish connection upon client request.
                while (true)
                {
                    DisplayMessage("Waiting for connection\r\n");

                    //Accept incoming connection;
                    m_Connection = listener.AcceptSocket();

                    //Create NetworkStream object associated with socket
                    m_SocketStream = new NetworkStream(m_Connection);

                    m_Writer = new BinaryWriter(m_SocketStream);
                    m_Reader = new BinaryReader(m_SocketStream);

                    DisplayMessage("Connection " + counter + " received.\r\n");

                    m_Writer.Write("Server >> Connection successful");
                    EnableInput(true);
                    string theReply = "";

                    do
                    {
                        try
                        {
                            theReply = m_Reader.ReadString();
                            DisplayMessage("\r\n" + theReply);
                        }
                        catch (Exception e)
                        {
                            break;
                        }

                    }
                    while (theReply != "Client >> Terminate" && m_Connection.Connected);


                    DisplayMessage("\r\nUser terminated connection\r\n");
                    m_Writer?.Close();
                    m_Reader?.Close();
                    m_SocketStream?.Close();
                    m_Connection?.Close();

                    EnableInput(false);
                    counter++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Sets Tb_Display's text in a thread-safe manner.
        /// </summary>
        /// <param name="message"></param>
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

        /// <summary>
        /// Send the typed text from the server to the client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tb_Input_OnKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && Tb_Input.IsEnabled)
                {
                    m_Writer.Write("Server >> " + Tb_Input.Text);
                    TxtDisplay.Text += "\r\nServer >> " + Tb_Input.Text;
                    Tb_Input.Clear();
                }

                if (Tb_Input.Text == "Terminate")
                {
                    m_Connection.Close();
                }

            }
            catch (SocketException exception)
            {
                TxtDisplay.Text += "\nError writing object.";
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
