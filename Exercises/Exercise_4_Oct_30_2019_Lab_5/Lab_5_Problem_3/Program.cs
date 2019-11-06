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
            //==================================


            //Sorting chars in ascending order;
            Console.WriteLine("Sorted chars - Ascending Order");

            var sortedAscending = from chr in chars
                orderby chr  ascending 
                select chr;

            foreach (var chr in sortedAscending)
            {
                Console.Write("{0}, ", chr);
            }

            Console.WriteLine();
            Console.WriteLine();
            //==================================


            //Sorting chars in descending order;
            Console.WriteLine("Sorted chars - Descending Order");

            var sortedDescending = from chr in chars
                orderby chr descending 
                select chr;

            foreach (var chr in sortedDescending)
            {
                Console.Write("{0}, ", chr);
            }

            Console.WriteLine();
            Console.WriteLine();
            //==================================


            //Chars with removed duplicates
            Console.WriteLine("Sorted chars - Duplicates removed");

            var sortdWithDuplicatesRemoved = from chr in chars
                orderby chr descending
                select chr;

            //var distinctItems = sortdWithDuplicatesRemoved.Select(y => y.First());

            List<char> distinctElements = sortdWithDuplicatesRemoved.Distinct().ToList();
            foreach (char element in distinctElements)
            {
                Console.Write("{0}, ", element);
            }

            Console.WriteLine();
            //==================================

        }
    }
}
