using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class ServerLogic
    {
        private static readonly string m_LocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string m_FileStorageRoot = System.IO.Path.Combine(m_LocalAppDataPath, "SampleExamFileServer");

        private int m_PortToUse = 50000;
        private Thread m_ListenerThread;
        private bool m_ListenerShouldStop;
        internal delegate void Messenger(string message);

        public event Messenger ServerNotification;
        public ServerLogic()
        {
            if (!Directory.Exists(m_FileStorageRoot))
            {
                Directory.CreateDirectory(m_FileStorageRoot);
            }
        }


        public void Start()
        {
            if (m_ListenerThread != null)
            {
                return;
            }
            IPEndPoint localIp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), m_PortToUse);
            m_ListenerThread = new Thread(Listen);
            m_ListenerShouldStop = false;
            m_ListenerThread.Start(localIp);
            ServerNotification?.Invoke($"[{DateTime.Now}]  Info >> Server started");

        }

        public void Listen(object state)
        {
            TcpListener listener;

            if (state is IPEndPoint endPoint)
            {
                listener = new TcpListener(endPoint);
                listener.Start();

                while (!m_ListenerShouldStop)
                {
                    if (listener.Pending())
                    {
                        Socket client = listener.AcceptSocket();
                        ThreadPool.QueueUserWorkItem(HandleClient, client);
                        ServerNotification?.Invoke($"\n[{DateTime.Now}]  Info >> Client Connected");
                    }
                }
            }

        }

        public void HandleClient(object client)
        {
            if (!(client is Socket clientSocket))
            {
                return;
            }
            var stream = new NetworkStream(clientSocket);
            var writer = new StreamWriter(stream, Encoding.ASCII);
            var reader = new StreamReader(stream, Encoding.ASCII);

            try
            {
                if (clientSocket.Connected)
                {
                    string clientResponse = reader.ReadLine();
                    if (!string.IsNullOrEmpty(clientResponse))
                    {

                        string[] parameters = clientResponse.Split(' ');
                        if (parameters[0] == Common.CommandsHelper.SaveCommand)
                        {
                            string fileName = parameters[1];
                            string fileContents = parameters[2];

                            ServerNotification?.Invoke($"\n[{DateTime.Now}] Client Command >>  {Common.CommandsHelper.SaveCommand}");
                            ServerNotification?.Invoke($"\n[{DateTime.Now}]   File : {fileName}");
                            ServerNotification?.Invoke($"\n[{DateTime.Now}]   Contents : {fileContents}");

                            string finalFile = System.IO.Path.Combine(m_FileStorageRoot, fileName);

                            var streamWriter = new StreamWriter(finalFile);
                            streamWriter.WriteLine(fileContents);
                            streamWriter.Close();
                            writer.WriteLine($"Saving of: \n {fileName} \n with contents: \n {fileContents} \n is complete");
                            writer.Flush();
                        }

                        if (parameters[0] == Common.CommandsHelper.RequestCommand)
                        {
                           
                            string fileName = parameters[1];
                            string finalFile = System.IO.Path.Combine(m_FileStorageRoot, fileName);

                            ServerNotification?.Invoke($"\n[{DateTime.Now}] Client Command >>  {Common.CommandsHelper.RequestCommand}");
                            ServerNotification?.Invoke($"\n[{DateTime.Now}]   File : {fileName}");

                            if (File.Exists(finalFile))
                            {
                                ServerNotification?.Invoke($"\n[{DateTime.Now}] Info >> File exists");
                                var fileStream = new StreamReader(finalFile);
                                string fileContents = fileStream.ReadToEnd();
                                writer.Write($"File Contents: {fileContents}");
                                writer.Flush();
                                fileStream.Close();
                            }
                            else
                            {
                                ServerNotification?.Invoke($"\n[{DateTime.Now}] Info >> File doesn't exists");
                                writer.WriteLine("No Such File");
                                writer.Flush();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ServerNotification?.Invoke($"\n[{DateTime.Now}] Info >> Exception occured during client processing. {e}");
            }
            finally
            {
                stream.Close();
                reader.Close();
                writer.Close();

                if (clientSocket.Connected)
                {
                    clientSocket.Close();
                    ServerNotification?.Invoke($"\n[{DateTime.Now}] Info >> Client Disconnected.");
                }
            }
        }

        public void Stop()
        {
            ServerNotification?.Invoke($"\n[{DateTime.Now}] Info >> Stopping server");
            m_ListenerShouldStop = true;


            if (m_ListenerThread != null && m_ListenerThread.IsAlive)
            {
                bool listenerStop = m_ListenerThread.Join(1000);
                if (!listenerStop)
                {
                    ServerNotification?.Invoke($"\n[{DateTime.Now}] Info >> Error during listener stopping. Aborting listener.");
                    m_ListenerThread.Abort();
                }
            }
        }
    }
}
