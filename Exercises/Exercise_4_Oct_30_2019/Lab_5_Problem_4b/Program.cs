using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_Problem_4b
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given list of strings 
            List<string> words = new List<string>() { "Blueberry", "Chimpanzee", "Abacus", "Banana", "Apple", "Cheese" };

            //Grouping strings by their first letter
            var groupedByFirstLetter = from word in words
                                      group word by word[0] into grp
                                      select grp;

            //Printing out all the grouped elements.
            foreach (var group in groupedByFirstLetter)
            {
                Console.WriteLine("Group that starts with {0} has {1} elements", group.Key, group.Count());
                foreach (var element in group)
                {
                    Console.WriteLine(element);
                }
                Console.WriteLine();
            }
        }

        
    }
}
