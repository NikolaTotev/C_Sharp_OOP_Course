using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace Components
{
    public class CommandEventArgs : EventArgs
    {
        public string Command { get; set; }

        public CommandEventArgs(string cmd)
        {
            Command = cmd;
        }
    }
}
