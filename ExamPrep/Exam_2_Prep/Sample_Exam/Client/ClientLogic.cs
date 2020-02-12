using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Components;

namespace Client
{
    class ClientLogic
    {
        private StreamWriter m_Writer;
        private StreamReader m_Reader;
        private NetworkStream m_Stream;
        private TcpClient m_Client;
        private Thread m_ListenerThread;
        private int m_PortToUse = 50000;
        private readonly IPAddress m_IpToUse = IPAddress.Parse("127.0.0.1");
        private bool m_ListenerShouldStop = false;

        internal delegate void Messenger(string message);
        public event Messenger ClientNotification;
        public event Messenger UpdateContent;
        public ClientLogic(MainWindow window)
        {
            window.SaveClicked += Save;
            window.RequestClicked += Request;
        }

        public void Start()
        {
            m_ListenerShouldStop = false;

            try
            {
                m_Client = new TcpClient();
                for (int i = 0; i < 3; i++)
                {
                    m_Client.Connect("127.0.0.1", 50000);
                    if (m_Client.Connected)
                    {
                        m_Stream = m_Client.GetStream();
                        m_Reader = new StreamReader(m_Stream, Encoding.ASCII);
                        m_Writer = new StreamWriter(m_Stream, Encoding.ASCII);
                        ClientNotification?.Invoke($"[{DateTime.Now}] Info >> Connected to the server!");
                        break;
                    }

                    if (i < 2)
                    {
                        ClientNotification?.Invoke($"[{DateTime.Now}] Warning >> Failed to connect. Retrying in 3s...");
                        Thread.Sleep(TimeSpan.FromSeconds(3));
                    }
                    else
                    {
                        ClientNotification?.Invoke(
                            $"[{DateTime.Now}] Error >> Maximum connection attempts reached. Aborting.");
                        m_Client?.Close();
                        return;
                    }
                }

                m_ListenerThread = new Thread(Listen);
                m_ListenerThread.Name = "Listener thread";
                m_ListenerThread.Start();
            }
            catch (Exception e)
            {
                ClientNotification?.Invoke(
                    $"[{DateTime.Now}] Error >> An exception occured during connection attempts. {e}");
            }
        }

        public void Listen()
        {
            try
            {

                while (m_Client.Connected || !m_ListenerShouldStop)
                {
                   

                    if (m_Client.Available > 0)
                    {
                        string serverResponse = m_Reader.ReadToEnd();
                        UpdateContent?.Invoke(serverResponse);
                        ClientNotification?.Invoke($"\n[{DateTime.Now}] Server >> {serverResponse}");
                        ClientNotification?.Invoke($"\n[{DateTime.Now}] You >> Server response received. Disconnecting from server.");
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                    
                }
            }
            catch (Exception e)
            {
                ClientNotification?.Invoke($"[{DateTime.Now}] Error >> Exception occured during communication.");
            }
            finally
            {
                if (!m_Client.Connected)
                {
                    ClientNotification?.Invoke($"[{DateTime.Now}] Info >> Disconnected from server!");
                }

                m_Reader.Close();
                m_Client.Close();
            }
        }

        private void Save(SaveEventArgs args)
        {
            m_Writer.WriteLine($"{args.Command} {args.Data.FileName} {args.Data.FileContents}");
            m_Writer.Flush();
        }

        private void Request(RequestEventArgs args)
        {
            m_Writer.WriteLine($"{args.Command} {args.FileName}");
            m_Writer.Flush();
        }


        public void Stop()
        {
            ClientNotification?.Invoke($"\r\n[{DateTime.Now}] Info >> Stopping client"); 


            if (m_ListenerThread != null && m_ListenerThread.IsAlive)
            {
                bool listenerStop = m_ListenerThread.Join(5000);
                if (!listenerStop)
                {
                    ClientNotification?.Invoke($"\r\n[{DateTime.Now}] Info >> Error during listener stopping. Aborting listener.");
                    m_ListenerThread.Abort();
                }
            }
        }
    }

  
}
