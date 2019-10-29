using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Xml;
using static System.Char;

namespace Problem_1
{
    class CesarCipher
    {
        private string input;
        private string output;
        private int offset;

        private List<string> alphabet = new List<string>()
        {
            "A", "B", "C", "D", "E", "F", "G", "H",
            "I", "J", "K", "L", "M", "N", "O",
            "P","Q","R","S","T","U","V","W",
            "X","Y","Z",
        };


        public CesarCipher()
        {
            Console.WriteLine("Functions available are: \n Encrypt(input String, input offset) " +
                              "\n Decrypt(input string, input offset)");
        }

        public string Encrypt(string input, int offset)
        {
            string output = "";
            int letterIndex;
            int newIndex;
            bool wasLower = false;
            foreach (char letter in input)
            {
                if (IsLower(letter))
                {
                    wasLower = true;
                }
                letterIndex = alphabet.IndexOf(letter.ToString().ToUpper());
                if (letterIndex + offset >= alphabet.Count)
                {
                    newIndex = 0 + ((letterIndex + offset) - alphabet.Count);
                }
                else
                {
                    newIndex = letterIndex + offset;
                }
                output += (wasLower) ? alphabet[newIndex].ToLower() : alphabet[newIndex];
                wasLower = false;
            }

            return output;
        }
    }
}