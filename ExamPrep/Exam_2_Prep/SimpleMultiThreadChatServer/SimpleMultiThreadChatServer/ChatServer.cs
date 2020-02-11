using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMultiThreadChatServer
{
    class ChatServer
    {
        internal delegate void MessageUpdater(string message);
        public event MessageUpdater MessageReceived;
        public void Start()
        {

        }

        private void Listen()
        {

        }

        public void Stop()
        {

        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(message);
        }
    }
}
