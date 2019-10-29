using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CesarCipher cs = new CesarCipher();
            Console.WriteLine("AaBbZz encrypted with offset 1");
            Console.WriteLine(cs.Encrypt("AaBbZz", 1));
            Console.WriteLine();
            Console.WriteLine("AaBbZz decrypted with offset 1");
            Console.WriteLine(cs.Decrypt("AaBbZz", 1));

        }
    }
}
