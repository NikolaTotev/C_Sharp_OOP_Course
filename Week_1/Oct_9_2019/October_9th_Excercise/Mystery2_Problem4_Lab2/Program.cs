using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystery2_Problem4_Lab2
{

    // Ex. 5.25: Mystery2.cs
    using System;

    public class Mystery2
    {
        public static void Main(string[] args)
        {
            int count = 1;

            while (count <= 10)
            {
                Console.WriteLine(count % 2 == 1 ? "****" : "++++++++");
                count++;
            } // end while
        } // end Main
    } // end class Mystery2

}
