using System;
using System.Collections.Generic;

namespace Problem_3
{
    public class ZipCodeConverter
    {
        private List<string> barcodeInfo = new List<string>()
        {
            "||:::", //0
            ":::||", //1
            "::|:|", //2
            "::||:", //3
            ":|::|", //4
            ":|:|:", //5 
            ":||::", //6
            "|:::|", //7
            "|::|:", //8
            "|:|::", //9
        };

        public string GenerateBarcode(int input)
        {
            string output = "";
            string inputString = input.ToString();
            int currentDigit;
            foreach (char digit in inputString)
            {
                currentDigit = Convert.ToInt32(digit) - '0';
                output += barcodeInfo[currentDigit];
            }

            return output;
        }
    }
}