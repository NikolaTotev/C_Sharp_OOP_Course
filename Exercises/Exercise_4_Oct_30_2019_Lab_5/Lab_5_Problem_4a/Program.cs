using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_Problem_4a
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate the list of 100 random numbers
            List<int> randNumbers = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                randNumbers.Add(rand.Next(20,50));
            }

            //Group the numbers by mod 8
            var groupsByMod8 = from number in randNumbers
                group number by GenGroupName(number)
                into grp
                select grp;

            //Display the results 
            foreach (var group in groupsByMod8)
            {
                Console.WriteLine("Group {0} has {1} elements", group.Key, group.Count());
                foreach (var element in group)
                {
                    Console.WriteLine(element);
                }
                Console.WriteLine();
            }
        }

        //Generate the names for each group based on mod 8
        static string GenGroupName(int number)
        {
            return "Mod " + number % 8;
        }
    }
}
