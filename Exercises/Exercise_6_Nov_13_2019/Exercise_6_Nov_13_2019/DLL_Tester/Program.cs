using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise_6___Nov_13_2019;

namespace DLL_Tester
{
    public class Program
    {
        static void Main(string[] args)
        {
            Point pointOne = new Point(new int[] {10, 10});
            Point pointTwo = new Point(pointOne);
            Console.WriteLine("Points - \n {0} \n {1}",pointOne.ToString(), pointTwo.ToString());
            Console.WriteLine();

            Console.WriteLine("Rectangle info:");
            Console.WriteLine();
            Rectangle rect = new Rectangle(20, 40, pointOne);
            Rectangle rect2 = new Rectangle(50, 90, pointTwo);



            pointOne.Coords[0] = 1000;
            Console.WriteLine(" Rectangle - {0}", rect.ToString());
            Console.WriteLine(" Area - {0}", rect.Area());
            Console.WriteLine(" Diagonal - {0}", rect.Diagonal());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Update rectangle with indexer");
            Console.WriteLine();

            rect["W"] = 200;
            rect["W"] = 400;

            Console.WriteLine(" Rectangle - {0}", rect.ToString());
            Console.WriteLine(" Area - {0}", rect.Area());
            Console.WriteLine(" Diagonal - {0}", rect.Diagonal());
            Console.WriteLine();

            rect.Order = rect.Area;

            List<Rectangle> rectangles = new List<Rectangle>(){rect, rect2};

            Rectangle.SortBy(rectangles, rect.order);
        }
    }
}
