using System;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipCodeConverter converter = new ZipCodeConverter();
            Console.WriteLine(converter.GenerateBarcode(111));
        }
    }
}
