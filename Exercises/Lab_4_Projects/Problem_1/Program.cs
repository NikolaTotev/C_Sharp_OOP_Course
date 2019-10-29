using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CesarCipher cs = new CesarCipher();
            Console.WriteLine(cs.Encrypt("AaBbZz", 1));
        }
    }
}
