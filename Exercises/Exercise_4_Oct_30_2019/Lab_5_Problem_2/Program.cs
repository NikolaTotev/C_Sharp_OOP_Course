using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input the sentence that needs to be split and sorted.
            string inputSentence;
            inputSentence = Console.ReadLine();

            //String split into words.
            List<string> words = inputSentence.Split().ToList();

            //Sort the words alphabetically.
            var sortedAlphabetically = from word in words
                                       orderby word.ToLower()
                                       select word;
            
            //Remove duplicates.
            List<string> distinctWords = sortedAlphabetically.Distinct().ToList();

            //Print out the sorted and duplicate free list.s
            foreach (string word in distinctWords)
            {
                Console.WriteLine("{0},", word);
            }
        }
    }
}
