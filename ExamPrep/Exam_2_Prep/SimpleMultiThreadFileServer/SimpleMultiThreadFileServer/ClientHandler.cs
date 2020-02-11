using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace SimpleMultiThreadFileServer
{
    public class ClientHandler
    {
        private Socket m_Client;
        private NetworkStream m_Stream;
        private StreamWriter m_Writer;
        private StreamReader m_Reader;
        public delegate void Messenger(string message);
        public event Messenger ClientEvent;

        public ClientHandler(Socket client)
        {
            m_Client = client;
        }

        public void ProcessClient()
        {
            string receivedData;
            string clientName;
            string clientMessage;
            try
            {
                if (m_Client.Connected)
                {
                    ClientEvent?.Invoke($"\r\n[{DateTime.Now}] Client update: Client connected.");
                }
                else
                {
                    ClientEvent?.Invoke(
                        $"\r\n[{DateTime.Now}] Client update: Client disconnected before any data was transmitted.");
                }

                ClientEvent?.Invoke($"\r\n[{DateTime.Now}] Client update: Getting data from client.");

                m_Stream = new NetworkStream(m_Client);
                m_Writer = new StreamWriter(m_Stream, Encoding.ASCII);
                m_Reader = new StreamReader(m_Stream, Encoding.ASCII);

                m_Writer.WriteLine($"[{DateTime.Now}] Server >> Hello! Awaiting your message.");
                m_Writer.Flush();

                receivedData = m_Reader.ReadLine();
                if (receivedData != null && !string.IsNullOrEmpty(receivedData))
                {
                    string[] data = receivedData.Split(new char[] {' '}, 2);
                    clientName = data[0];
                    clientMessage = data[1];
                    ClientEvent?.Invoke($"\r\n[{DateTime.Now}] {clientName} >> {clientMessage}");
                }
                else
                {
                    ClientEvent?.Invoke($"\r\n[{DateTime.Now}] Client update >> Data from client was empty!");
                    clientMessage = ">> EMPTY <<";
                    clientName = ">> EMPTY <<";
                }

                try
                {
                    if (m_Client.Connected)
                    {
                        ClientEvent?.Invoke(
                            $"\r\n[{DateTime.Now}] Server >> Hello, {clientName}! I have received your message.\n It said {clientMessage}. \n Have a nice day!");
                        m_Writer.WriteLine(
                            $"[{DateTime.Now}] Server >> Hello, {clientName}! I have received your message. It said - {clientMessage}. Have a nice day!");
                        m_Writer.Flush();
                        //Thread.Sleep(300);
                    }
                }
                catch (Exception e)
                {
                    ClientEvent?.Invoke(
                        $"\r\n[{DateTime.Now}] Client update >> Could not say goodbye to client. Connection may have been terminated already. \n {e.Message}");
                }
            }
            catch(SocketException e)
            {
                ClientEvent?.Invoke($"\r\n[{DateTime.Now}] Client Error >> Socket exception encountered! \n {e}");
            }
            catch (Exception e)
            {
                ClientEvent?.Invoke($"\r\n[{DateTime.Now}] Client Error >> Client exception! \n {e}");
            }
            finally
            {
                try
                {
                    m_Client.Close();
                }
                catch (Exception e)
                {
                    ClientEvent?.Invoke($"\r\n[{DateTime.Now}] Client Error >> Exception encountered while disconnecting client! \n {e}");
                }
            }
        }

        protected virtual void OnClientEvent(string message)
        {
            ClientEvent?.Invoke(message);
        }
    }
}