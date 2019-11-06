using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using TrasnpositionCipher;

namespace Lab_4a_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Cipher cp = new Cipher(6);
            string plain = "ttihhnietspeilxsat";
            string cipher = cp.Encrypt(plain);
            Console.WriteLine(cipher);
        }
    }
}
