using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrasnpositionCipher
{
    public class Cipher
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
                else cipherKey = 1;
            }
        }

        public Cipher(int cipherKey)
        {
            CipherKey = cipherKey;
        }

        /// <summary>
        /// Encrypts with Transposition Cipher
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns>
        /// Encrypted text
        /// </returns>
        public string Encrypt(string plaintext)
        {
            char[] plaintextChars = plaintext.ToCharArray();
            if (plaintextChars.Length <= cipherKey) return "Cannot encrypt. Text is too short!";

            int rows = plaintextChars.Length / cipherKey + 1;
            int cols = cipherKey;
            char[] ciphertextChars = new char[rows * cipherKey];
            int countChars;

            //write by rows, read by cols
            char[,] codeTable = new char[rows, cols];

            //write by rows
            countChars = 0;//no chars read
            for (int i = 0; i < codeTable.GetLength(0); i++)
            {
                for (int j = 0; j < codeTable.GetLength(1); j++)
                {
                    if (countChars < plaintextChars.Length)
                    {
                        codeTable[i, j] = plaintextChars[countChars++];
                    }
                    else
                    {
                        codeTable[i, j] = ' ';
                    }
                }
            }

            //read codeTable by cols
            countChars = 0; // no chars read
            for (int i = 0; i < codeTable.GetLength(1); i++)
            {
                for (int j = 0; j < codeTable.GetLength(0); j++)
                {
                    ciphertextChars[countChars++] = codeTable[j, i];
                }
            }

            return new String(ciphertextChars);//convert to string
        }

        public string Decrypt(string ciphertext)
        {
            char[] ciphertextChars = ciphertext.ToCharArray();

            int rows = ciphertextChars.Length / cipherKey;
            int cols = cipherKey;
            char[] plaintextChars = new char[rows * cipherKey];
            int countChars;

            //write by cols, read by rows
            char[,] codeTable = new char[rows, cols];

            //write by col
            countChars = 0;//no chars read
            for (int i = 0; i < codeTable.GetLength(1); i++)
            {
                for (int j = 0; j < codeTable.GetLength(0); j++)
                {
                    if (countChars < ciphertextChars.Length)
                    {
                        codeTable[j, i] = ciphertextChars[countChars++];
                    }
                    else
                    {
                        codeTable[j, i] = ' ';
                    }
                }
            }

            //read codeTable by rows
            countChars = 0; // no chars read
            for (int i = 0; i < codeTable.GetLength(0); i++)
            {
                for (int j = 0; j < codeTable.GetLength(1); j++)
                {
                    plaintextChars[countChars++] = codeTable[i, j];
                }
            }

            return new String(plaintextChars);//convert to string
        }
    }
}