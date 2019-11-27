using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometry_Library;

namespace Geometry_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point();
            Point p2 = new Point(10, 100, 300);
            Point p3 = new Point(100, 100, 300);

            Console.WriteLine(p1);
            Vector v1 = new Vector(p1, p2);
            Vector v2 = new Vector(p1, p3);
            Console.WriteLine(v1);

            Geometry_Library.IComparable pc = ((Geometry_Library.IComparable)p1)["point"];
            Console.WriteLine(pc);


        }
    }
}
