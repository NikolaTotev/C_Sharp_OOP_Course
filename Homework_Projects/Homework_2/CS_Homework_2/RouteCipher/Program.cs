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
            Console.WriteLine(cp.Encrypt("abortthemissionyouhavebeenspotted"));
        }
    }
}
