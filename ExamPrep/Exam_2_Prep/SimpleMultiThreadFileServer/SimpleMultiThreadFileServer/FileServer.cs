using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleMultiThreadFileServer
{
    class FileServer
    {
        private bool m_MustStop = false;
        private readonly int m_Port = 50000;

        private Thread m_ListenerThread;
        private ConcurrentQueue<Guid> m_ClientHandlersQueue = new ConcurrentQueue<Guid>();
        internal delegate void Messenger(string message);

        public event Messenger ClientEvent;
        public event Messenger ServerNotification;
        public void Start()
        {
            if (m_ListenerThread != null)
            {
                ServerNotification?.Invoke("Process already started!");
                return;
            }
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ip, m_Port);

            m_ListenerThread = new Thread(Listen);
            m_MustStop = false;
            m_ListenerThread.Start(localEndPoint);
            ServerNotification?.Invoke($"[{DateTime.Now}] Status Update:  Server Started!");
        }

        public void Listen(object state)
        {
            ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update:  Starting listener...");
            TcpListener listener;
            if (state is IPEndPoint localEndPoint)
            {
                try
                {
                    listener = new TcpListener(localEndPoint);
                    listener.Start();
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update:  Awaiting connection on port: {m_Port}");
                }
                catch (Exception)
                {
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Error:  Failed to start listener!");
                    throw;
                }
            }
            else
            {
                ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Error:  Invalid listener state!");
                return;
            }

            while (!m_MustStop)
            {
                try
                {
                    if (listener.Pending())
                    {
                        Socket client = listener.AcceptSocket();
                        ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update:  Connected to Client!");

                        for (int i = 0; i < 3; i++)
                        {
                            if (ThreadPool.QueueUserWorkItem(RunClientHandler, client))
                            {
                                m_ClientHandlersQueue.Enqueue(Guid.NewGuid());
                                ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update: Client ready for processing.");
                                break;
                            }

                            if (i < 2)
                            {
                                ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update: Failed to enqueue client. Retrying...");
                                Thread.Sleep(2);
                            }
                            else
                            {
                                ServerNotification?.Invoke($"\r\n[{DateTime.Now}] ERROR: Failed to enqueue client. Closing connection.");
                                client.Close();
                            }
                        }

                        Thread.Sleep(2);
                    }
                }
                catch (Exception e)
                {
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Fatal Error: The server encountered a fatal error. Terminating. \n {e}");
                    throw;
                }
            }
            ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update: Received stop instruction. Stopping listener.");
            listener.Stop();
            ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update: Listener has been stopped. Client can't connect.");
        }

        private void RunClientHandler(object client)
        {
            try
            {
                if (!(client is Socket currentSocket))
                {
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Error: Unexpected client state encountered. Aborting client processing.");
                    return;
                }

                try
                {
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update: Processing Client...");
                    ClientHandler currentHandler = new ClientHandler(currentSocket);
                    currentHandler.ClientEvent += RedirectClientEvent;
                    currentHandler.ProcessClient();
                }
                catch (Exception e)
                {
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Error: Encountered exception during client processing.\n{e}");
                    throw;
                }
            }
            finally
            {
                bool dequeued = false;
                for (int i = 0; i < 10; i++)
                {
                    if (m_ClientHandlersQueue.TryDequeue(out _))
                    {
                        dequeued = true;
                        break;
                    }
                }

                if (!dequeued)
                {
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Warning: Client could not be dequeued.");
                }
            }
        }

        private void RedirectClientEvent(string message)
        {
            ServerNotification?.Invoke(message);
        }

        public void Stop()
        {
            ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update: Stopping server.");
            m_MustStop = true;

            if (m_ListenerThread != null && m_ListenerThread.IsAlive)
            {
                bool listenerStopped = m_ListenerThread.Join(100);
                if (!listenerStopped)
                {
                    ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Error: Failed to stop listener thread in allocated time. Aborting thread.");
                    m_ListenerThread.Abort();
                }
            }
            ServerNotification?.Invoke($"\r\n[{DateTime.Now}] Status Update: Server has been stopped. There are still {m_ClientHandlersQueue.Count} clients being processed. They will be aborted.");
        }

        protected virtual void OnClientEvent(string message)
        {
            ClientEvent?.Invoke(message);
        }

        protected virtual void OnServerNotification(string message)
        {
            ServerNotification?.Invoke(message);
        }
    }
}
