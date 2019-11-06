using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            Console.WriteLine("Set balance 30");
            account.Balance = 30;
            Console.WriteLine(account);
            Console.WriteLine("Withdraw 10");
            account.Withdraw(10m);
            Console.WriteLine(account);

        }
    }
}
