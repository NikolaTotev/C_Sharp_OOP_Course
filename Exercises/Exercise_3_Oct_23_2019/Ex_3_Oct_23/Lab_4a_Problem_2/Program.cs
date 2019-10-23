using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4a_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Sipher sp = new Sipher(6);
            string plain = "ttihhnietspeilxsat";
            string cipher = sp.Encrypt(plain);
            Console.WriteLine(cipher);
        }
    }
}
