using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteCipher
{
    class Program
    {
        static void Main(string[] args)
        {

            RouteCipher cp = new RouteCipher(-5);
            string encrpted = cp.Encrypt("abortthemissionyouhavebeenspotted");
            cp.Decrypt(encrpted, -5);
        }
    }
}
