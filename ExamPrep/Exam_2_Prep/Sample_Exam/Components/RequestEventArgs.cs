using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components
{
    public class RequestEventArgs : CommandEventArgs
    {
        public string FileName { get; set; }
        public RequestEventArgs(string cmd, string fileName) : base(cmd)
        {
            FileName = fileName;
        }
    }
}
