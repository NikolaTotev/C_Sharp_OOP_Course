using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4a_Problem_2
{
    public class Sipher
    {
        private int cipherKey;
        public int CipherKey
        {
            get { return cipherKey; }
            set
            {
                if (value > 0)
                {
                    cipherKey = value;
                }
                else
                {
                    cipherKey = 1;
                }
            }
        }

        public Sipher(int cipherKey)
        {
            CipherKey = cipherKey;
        }

        /// <summary>
        /// Encrypts plaintext with Transposition cipher
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>Encrypted text</returns>
        public string Encrypt(string plaintext)
        {
            string ciphertext = "";
            char[] plainTextChars = plaintext.ToCharArray();
            if (plainTextChars.Length <= cipherKey)
            {
                return "Can't encrypt. Text too short!";
            }

            int rows = plainTextChars.Length / cipherKey + 1;
            int cols = cipherKey;
            char[] cipherTextChars = new char[rows * cipherKey];
            char[,] codeTable = new char[rows, cols]; // write by rows read by columns

            int countChars = 0;
            for (int i = 0; i < cipherTextChars.GetLength(0); i++)
            {
                for (int j = 0; j < cipherTextChars.GetLength(1); j++)
                {
                    if (countChars < plainTextChars.Length)
                    {

                        codeTable[i, j] = plainTextChars[countChars++];
                    }
                    else
                    {
                        codeTable[i, j] = ' ';
                    }
                }


            }

            countChars = 0;
            for (int i = 0; i < cipherTextChars.GetLength(0); i++)
            {
                for (int j = 0; j < cipherTextChars.GetLength(1); j++)
                {
                    cipherTextChars[countChars++] = codeTable[j, i];
                }
            }

            return new String(cipherTextChars);
        }

        public string Decrypt (string cipherText)
        {
            string plainText = " ";

            char[] cipherTextChars = cipherText.ToCharArray();



            int rows = cipherTextChars.Length / cipherKey + 1;
            int cols = cipherKey;
            char[] plainTextChars = new char[rows * cipherKey];
            char[,] codeTable = new char[rows, cols]; // write by rows read by columns

            int countChars = 0;
            for (int i = 0; i < cipherTextChars.GetLength(0); i++)
            {
                for (int j = 0; j < cipherTextChars.GetLength(1); j++)
                {
                    if (countChars < plainTextChars.Length)
                    {
                        plainTextChars[countChars++] = codeTable[i, j];
                    }
                    else
                    {
                        codeTable[i, j] = ' ';
                    }
                }


            }

            countChars = 0;
            for (int i = 0; i < cipherTextChars.GetLength(0); i++)
            {
                for (int j = 0; j < cipherTextChars.GetLength(1); j++)
                {
                     codeTable[j, i] = cipherTextChars[countChars++];
                }
            }

            return "";
        }
    }


}
