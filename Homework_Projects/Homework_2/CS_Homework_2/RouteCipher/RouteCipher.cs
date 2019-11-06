using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace RouteCipher
{
    public class RouteCipher
    {
        private int key;

        public RouteCipher(int key)
        {
            Key = key;
        }

        public int Key
        {
            get => key;
            set { key = value; }
        }

        public string Encrypt(string inputText)
        {
            char[] charsOnly = inputText.ToCharArray();
            
            string plainText = new string(charsOnly);
            double plainTextLen = plainText.Length;
            int numberOfRows =Convert.ToInt32(Math.Ceiling(plainTextLen/ Math.Abs(key)));

            string[,] grid = new string[numberOfRows, Math.Abs(key)];

            int charCounter = 0;
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < Math.Abs(key); j++)
                {
                    if (charCounter < plainTextLen)
                    {
                        grid[i, j] = Convert.ToString(plainText[charCounter]);
                        charCounter++;
                    }
                    else
                    {
                        grid[i, j] = "*";
                    }
                }
            }


            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    Console.Write("{0}, ",grid[i,j]);
                }

                Console.WriteLine();
            }


            string encryptedText = "";

            int upperColBound = Math.Abs(key);
            int upperRowBound = numberOfRows;
            int colDown = Math.Abs(key) - 1;
            int rowRight = 0;

            int colUp = 0;
            int rowLeft = numberOfRows-1;
            int runningCount = 0;
            if (key > 0)
            {

                while (runningCount < Math.Abs(key) * numberOfRows)
                {
                    for (int i = 0; i < upperColBound; i++)
                    {
                        encryptedText += grid[rowRight, i];
                        runningCount++;
                    }

                    upperColBound -= 1;
                    rowRight += 1;

                    for (int i = 0; i < upperRowBound; i++)
                    {
                        encryptedText += grid[i, colDown];
                        runningCount++;
                    }

                    colDown -= 1;
                    upperRowBound -= 1;

                    for (int i = upperColBound - 1; i > 0; i--)
                    {
                        encryptedText += grid[rowLeft, i];
                        runningCount++;
                    }

                    rowLeft -= 1;

                    for (int i = upperRowBound - 1; i > 0; i--)
                    {
                        encryptedText += grid[i, colUp];
                        runningCount++;
                    }

                    colUp += 1;

                } 
            }
            else
            {

                 upperColBound = Math.Abs(key);
                 upperRowBound = numberOfRows;
                 colDown = 0;
                 rowRight = numberOfRows-1;

                 colUp = Math.Abs(key) - 1;
                 rowLeft = 0;
                 runningCount = 0;
                while (runningCount < Math.Abs(key) * numberOfRows)
                {

                    for (int i = upperColBound - 1; i > 0; i--)
                    {
                        encryptedText += grid[rowLeft, i];
                        runningCount++;
                    }

                    rowLeft += 1;

                    for (int i = 0; i < upperRowBound; i++)
                    {
                        encryptedText += grid[i, colDown];
                        runningCount++;
                    }

                    colDown += 1;
                    upperRowBound -= 1;

                    for (int i = 0; i < upperColBound; i++)
                    {
                        encryptedText += grid[rowRight, i];
                        runningCount++;
                    }


                    upperColBound -= 1;
                    rowRight -= 1;

               

                

                    for (int i = upperRowBound - 1; i > 0; i--)
                    {
                        encryptedText += grid[i, colUp];
                        runningCount++;
                    }

                    colUp -= 1;

                }
            }

            return encryptedText;
        }

        public string Decrypt(string cipherText)
        {
            throw new System.NotImplementedException();
        }
        
        
    }
}