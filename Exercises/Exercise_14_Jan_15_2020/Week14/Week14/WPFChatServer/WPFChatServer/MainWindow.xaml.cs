using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace WPFChatServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread readThread; // Thread for processing incoming messages
        private  int counter = 0;
        private Dictionary<Thread, BinaryWriter> writers;
        private Dictionary<Thread, Socket> connections;

        //private Socket connection; // Socket for accepting a connection      
        //private NetworkStream socketStream; // network data stream           
        //private BinaryWriter writer; // facilitates writing to the stream    
        //private BinaryReader reader; // facilitates reading from the stream  
        // initialize thread for reading
        public MainWindow()
        {
            InitializeComponent();

            writers = new Dictionary<Thread, BinaryWriter>();
            readThread = new Thread(new ThreadStart(RunServer));
            readThread.Start();
            connections = new Dictionary<Thread, Socket>();
        }
        // close all threads associated with this application
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }// end method Window_Closing
         // sends text the user typed to client
        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return && TxtInput.IsEnabled == true)
                {
                    var keys = writers.Keys;
                    foreach (var key in keys)
                    {
                        writers[key].Write("SERVER>>> " + TxtInput.Text);
                        TxtDisplay.Text += "\r\nSERVER>>> " + TxtInput.Text;
                    }

                    // if the user at the server signaled termination
                    // sever the connection to the client
                    if (TxtInput.Text == "TERMINATE")
                    {
                        var conns = connections.Keys;
                        foreach (var connection in conns)
                        {
                            connections[connection]?.Close();
                        }
                    }
                    TxtInput.Clear();
                } // end if
            } // end try
            catch (SocketException)
            {
                TxtDisplay.Text += "\nError writing object";
            } // end catch
        } // end method TxtInput_KeyDown
          // allows a client to connect; displays text the client sends
        public void RunServer()
        {
            TcpListener listener;
            

            // wait for a client connection and display the text
            // that the client sends
            try
            {
                // Step 1: create TcpListener                    
                IPAddress local = IPAddress.Parse("127.0.0.1");
                listener = new TcpListener(local, 50000);

                // Step 2: TcpListener waits for connection request
                listener.Start();

                // Step 3: establish connection upon client request
                while (true)
                {
                    DisplayMessage("Waiting for connection\r\n");

                    // accept an incoming connection     
                    Socket connection = listener.AcceptSocket();

                    ThreadPool.QueueUserWorkItem(new WaitCallback(RunInThread), connection);      
                    
                } // end while
            } // end try
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            } // end catch
        } // end method RunServer

        private void  RunInThread(object socket )
        {
            //Socket connection; // Socket for accepting a connection      
            //NetworkStream socketStream; // network data stream           
            //BinaryWriter writer; // facilitates writing to the stream    
            Socket connection = (Socket)socket;
            
            NetworkStream socketStream = new NetworkStream(connection);

            // create objects for transferring data across stream
            BinaryWriter writer = new BinaryWriter(socketStream);
            BinaryReader reader = new BinaryReader(socketStream);
            writers.Add(Thread.CurrentThread, writer);
            connections.Add(Thread.CurrentThread, connection);

            lock (this)
            {
                counter++;
                DisplayMessage("Connection " + counter + " received.\r\n");
            }
            

            // inform client that connection was successfull  
            writer.Write("SERVER>>> Connection successful");

            EnableInput(true); // enable inputTextBox

            string theReply = "";

            // Step 4: read string data sent from client
            do
            {
                try
                {
                    // read the string sent to the server
                    theReply = reader.ReadString();

                    // display the message
                    DisplayMessage("\r\n" + theReply);
                } // end try
                catch (Exception)
                {
                    // handle exception if error reading data
                    break;
                } // end catch
            } while (theReply != "CLIENT>>> TERMINATE" &&
               connection.Connected);
            lock (this)
            {
                counter--;
                DisplayMessage("\r\nUser terminated connection\r\n");
                writers.Remove(Thread.CurrentThread);
                connections.Remove(Thread.CurrentThread);
                if (counter==0)
                    EnableInput(false); // disable InputTextBox
            }

            // Step 5: close connection  
            writer?.Close();
            reader?.Close();
            socketStream?.Close();
            connection?.Close();    
        }

        // method DisplayMessage sets displayTextBox's Text property
        // in a thread-safe manner
        private void DisplayMessage(string message)
        {
            // if modifying displayTextBox is not thread safe
            if (!TxtDisplay.Dispatcher.CheckAccess())
            {
                // use inherited method Invoke to execute DisplayMessage
                // via a delegate                                       
                TxtDisplay.Dispatcher.Invoke(new Action(() 
                                                 => TxtDisplay.Text += message));

            } // end if
            else // OK to modify displayTextBox in current thread
                TxtDisplay.Text += message;
        } // end method DisplayMessage
          // method DisableInput sets inputTextBox's ReadOnly property
          // in a thread-safe manner
        private void EnableInput(bool value)
        {
            // if modifying inputTextBox is not thread safe
            if (!TxtInput.Dispatcher.CheckAccess())
            {
                // use inherited method Invoke to execute DisableInput
                // via a delegate                                     
                TxtInput.Dispatcher.Invoke(new Action(() => TxtInput.IsEnabled = value));
            } // end if
            else // OK to modify inputTextBox in current thread
                TxtInput.IsEnabled = value;
        } // end method DisableInput


    }
}
