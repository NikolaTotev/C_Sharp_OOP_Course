using FileServiceClientApp.FileServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServiceClientApp
{
    class Program
    {
        static void Main(string[] args)
        {

            FileServiceClient client = new FileServiceClient();
            Console.WriteLine(client.GetFileContents("c:\\temp\\test.txt"));
        }
    }
}
