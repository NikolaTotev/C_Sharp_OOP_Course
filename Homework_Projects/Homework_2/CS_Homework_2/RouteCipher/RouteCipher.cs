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
            int numberOfRows = Convert.ToInt32(Math.Ceiling(plainTextLen / Math.Abs(key)));

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
                for (int j = 0; j < Math.Abs(key); j++)
                {
                    Console.Write("{0}, ", grid[i, j]);
                }

                Console.WriteLine();
            }


            string encryptedText = "";

            int upperColBound = Math.Abs(key);
            int upperRowBound = numberOfRows;
            int colDownToBottom = 0;
            int rowLeftToR = numberOfRows - 1;

            int colUpToTop = Math.Abs(key) - 1;
            int rowRightToL = 0;
            int runningCount = 0;
            if (key > 0)
            {


                while (runningCount <= Math.Abs(key) * numberOfRows)
                {
                    //Down column from colum 0;

                    ///This code itterates through a column from top to bottom.
                    for (int i = rowRightToL; i < upperRowBound; i++)
                    {
                        encryptedText += grid[i, colDownToBottom];

                        runningCount++;


                    }

                    colDownToBottom += 1;
                    upperRowBound -= 1;
                    ///=========================================================



                    //Right row from upperRowBound

                    ///This code itterates through a row from left to right.
                    for (int i = colDownToBottom; i < upperColBound; i++)
                    {
                        encryptedText += grid[rowLeftToR, i];

                        runningCount++;

                    }

                    upperColBound -= 1;
                    rowLeftToR -= 1;
                    ///=====================================================

                    //Column up from upperColBound - OK

                    ///This code itterates through a column bottom to top.
                    for (int i = rowLeftToR; i >= 0; i--)
                    {
                        encryptedText += grid[i, colUpToTop];

                        runningCount++;


                    }

                    colUpToTop -= 1;
                    ///===================================================


                    //Row left from row 0 - OK
                    ///This code itterates through a row right to left.
                    for (int i = upperColBound - 1; i > 0; i--)
                    {
                        encryptedText += grid[rowRightToL, i];

                        runningCount++;

                    }

                    rowRightToL += 1;
                    ///=================================================
                }
            }
            else
            {

                upperColBound = Math.Abs(key);
                upperRowBound = numberOfRows;
                colDownToBottom = 0;
                rowLeftToR = numberOfRows - 1;

                colUpToTop = Math.Abs(key) - 1;
                rowRightToL = 0;
                runningCount = 0;
                int maxCount = Math.Abs(key) * numberOfRows;
                while (runningCount <= maxCount)
                {


                    //Up from [max,max]

                    ///This code itterates through a column bottom to top.
                    for (int i = rowLeftToR; i > 0 && runningCount < maxCount; i--)
                    {
                        if (runningCount + 1 < maxCount)
                        {
                            encryptedText += grid[i, colUpToTop];
                            runningCount++;
                        }
                    }

                    colUpToTop -= 1;
                    ///===================================================


                    if (runningCount + 1 >= maxCount)
                    {
                        break;
                    }
                    //Right to left from [0, max]
                    ///This code itterates through a row right to left.
                    for (int i = colUpToTop; i >= colDownToBottom && runningCount <= maxCount; i--)
                    {
                        encryptedText += grid[rowRightToL, i];
                        runningCount++;
                    }

                    rowRightToL += 1;

                    ///=================================================

                    //Down from [0, 0]
                    ///This code itterates through a column from top to bottom.
                    for (int i = rowRightToL; i < upperRowBound && runningCount <= maxCount; i++)
                    {
                        encryptedText += grid[i, colDownToBottom];
                        runningCount++;
                    }

                    colDownToBottom += 1;
                    upperRowBound -= 1;

                    ///=========================================================

                    //Left to right from [max, 0]
                    ///This code itterates through a row from left to right.
                    for (int i = colDownToBottom; i <= colUpToTop && runningCount <= maxCount; i++)
                    {
                        encryptedText += grid[rowLeftToR, i];
                        runningCount++;
                    }

                    upperColBound -= 1;
                    rowLeftToR -= 1;

                    ///=====================================================


                }
            }

            return encryptedText;
        }

        public void Decrypt(string cipherText, int key)
        {



            double cipherTextLen = cipherText.Length;
            int rows = Convert.ToInt32(Math.Ceiling(cipherTextLen / Math.Abs(key)));

            string[,] grid = new string[rows, Math.Abs(key)];
            char[] stringArr = cipherText.ToCharArray();

            string encryptedText = "";

            int upperColBound = Math.Abs(key);
            int upperRowBound = rows;
            int colDownToBottom = 0;
            int rowLeftToR = rows - 1;

            int colUpToTop = Math.Abs(key) - 1;
            int rowRightToL = 0;
            int runningCount = 0;
            if (key > 0)
            {


                while (runningCount <= cipherText.Length)
                {
                    //Down column from colum 0;

                    ///This code itterates through a column from top to bottom.
                    for (int i = rowRightToL; i < upperRowBound; i++)
                    {
                        if (runningCount < stringArr.Length)
                        {
                            grid[i, colDownToBottom] = stringArr[runningCount].ToString();
                        }

                        runningCount++;


                    }

                    colDownToBottom += 1;
                    upperRowBound -= 1;
                    ///=========================================================



                    //Right row from upperRowBound

                    ///This code itterates through a row from left to right.
                    for (int i = colDownToBottom; i < upperColBound; i++)
                    {

                        if (runningCount < stringArr.Length)
                        {

                            grid[rowLeftToR, i] = stringArr[runningCount].ToString();
                        }

                        runningCount++;


                    }

                    upperColBound -= 1;
                    rowLeftToR -= 1;
                    ///=====================================================

                    //Column up from upperColBound - OK

                    ///This code itterates through a column bottom to top.
                    for (int i = rowLeftToR; i >= 0; i--)
                    {
                        if (runningCount < stringArr.Length)
                        {

                            grid[i, colUpToTop] = stringArr[runningCount].ToString();
                        }

                        runningCount++;


                    }

                    colUpToTop -= 1;
                    ///===================================================


                    //Row left from row 0 - OK
                    ///This code itterates through a row right to left.
                    for (int i = upperColBound - 1; i > 0; i--)
                    {
                        if (runningCount < stringArr.Length)
                        {


                            grid[rowRightToL, i] = stringArr[runningCount].ToString();
                        }

                        runningCount++;

                    }

                    rowRightToL += 1;
                    ///=================================================
                }
            }
            else
            {

                upperColBound = Math.Abs(key);
                upperRowBound = rows;
                colDownToBottom = 0;
                rowLeftToR = rows - 1;

                colUpToTop = Math.Abs(key) - 1;
                rowRightToL = 0;
                runningCount = 0;
                int maxCount = Math.Abs(key) * rows;
                while (runningCount <= maxCount)
                {


                    //Up from [max,max]

                    ///This code itterates through a column bottom to top.
                    for (int i = rowLeftToR; i > 0 && runningCount < maxCount; i--)
                    {
                        if (runningCount + 1 < maxCount)
                        {
                            grid[i, colUpToTop] = stringArr[runningCount].ToString();
                            runningCount++;
                        }
                    }

                    colUpToTop -= 1;
                    ///===================================================


                    if (runningCount + 1 >= maxCount)
                    {
                        break;
                    }
                    //Right to left from [0, max]
                    ///This code itterates through a row right to left.
                    for (int i = colUpToTop; i >= colDownToBottom && runningCount <= maxCount; i--)
                    {
                        grid[rowRightToL, i] = stringArr[runningCount].ToString();
                        runningCount++;
                    }

                    rowRightToL += 1;

                    ///=================================================

                    //Down from [0, 0]
                    ///This code itterates through a column from top to bottom.
                    for (int i = rowRightToL; i < upperRowBound && runningCount <= maxCount; i++)
                    {
                        grid[i, colDownToBottom] = stringArr[runningCount].ToString();
                        runningCount++;
                    }

                    colDownToBottom += 1;
                    upperRowBound -= 1;

                    ///=========================================================

                    //Left to right from [max, 0]
                    ///This code itterates through a row from left to right.
                    for (int i = colDownToBottom; i <= colUpToTop && runningCount <= maxCount; i++)
                    {
                        grid[rowLeftToR, i] = stringArr[runningCount].ToString();
                        runningCount++;
                    }

                    upperColBound -= 1;
                    rowLeftToR -= 1;

                    ///=====================================================


                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < Math.Abs(key); j++)
                {
                    Console.Write("{0}, ", grid[i, j]);
                }

                Console.WriteLine();
            }
        }


    }
}