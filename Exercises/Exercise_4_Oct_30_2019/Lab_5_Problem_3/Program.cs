using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> chars = new List<char>();
            
            //Generate 30 random characters.
            Random rand = new Random();

            for (int i = 0; i < 30; i++)
            {
              chars.Add((char)('A'+ rand.Next(26)));   
            }
            Console.WriteLine("Unsorted chars");
            Console.WriteLine("{0}", string.Join(", ", chars));
            Console.WriteLine();


            Console.WriteLine("Sorted chars");

            var sortedChars = from chr in chars
                orderby chr
                select chr;

            foreach (var chr in sortedChars)
            {
                Console.Write("{0}, ", chr);
            }

            Console.WriteLine();

            Console.WriteLine("Sorted chars with lambda");
            
            Console.WriteLine();

        }
    }
}
