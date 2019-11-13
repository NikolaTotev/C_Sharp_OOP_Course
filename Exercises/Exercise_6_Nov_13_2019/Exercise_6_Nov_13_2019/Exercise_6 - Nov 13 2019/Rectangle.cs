using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_6___Nov_13_2019
{
    public class Rectangle
    {
        #region Data members

        private double width;
        private double length;
        private static Point upperLeftPoint;
        public delegate double CompareBy();
        public CompareBy order;

        #endregion

        #region Constructors

        public Rectangle(double width, double length, Point upperLeftPoint)
        {
            Width = width;
            Length = length;
            UpperLeftPoint = upperLeftPoint;
            order = Area;
        }

        public Rectangle() : this(0, 0, new Point())
        {

        }

        ////Why are these showing up as never used.
        //public Rectangle(Rectangle rect) : this(rect.Width, rect.length, rect.upperLeftPoint)
        //{

        //}

        #endregion

        #region Properties

        public CompareBy Order //This remains to be fixed for next time 
        {
            get { return order; }
            set
            {
                if (value != null)
                {
                    order = value;
                }
                else
                {
                    order = Area;
                }
            }
        }
        public double this[string index]
        {
            get
            {
                /* return the specified index here */
                if (index == "W" || index == "L")
                {
                    return index == "W" ? width : length;
                }

                return -1;
            }
            set
            {
                /* set the specified index to value here */
                if (value >= 0)
                {
                    switch (index)
                    {
                        case "W":
                            width = value;
                            break;
                        case "L":
                            length = value;
                            break;

                    }
                }
            }
        }
        public Point UpperLeftPoint
        {
            get
            {
                return new Point(upperLeftPoint); //Point is a reference type.
            }
            set
            {
                //Which version is better?
                if (value != null)
                {
                    upperLeftPoint = new Point(value);
                }
                else
                {
                    upperLeftPoint = new Point();
                }

                // upperLeftPoint = value != null ? new Point(value) : new Point();
            }
        }

        public double Width
        {
            get { return width; }
            set { width = value >= 0 ? value : 0; }
        }

        public double Length
        {
            get { return length; }
            set { length = value >= 0 ? value : 0; }
        }

        #endregion

        #region Utility methods
        public double Area()
        {
            return width * length;
        }

        public double Diagonal()
        {
            return Math.Sqrt(width * width + length * length);
        }

        public static void SortBy(List<Rectangle> rectList, CompareBy order)
        {
            var sorted = rectList.OrderBy(r => order()).Select(r => r);

            foreach (var rectangle in sorted)
            {
                Console.WriteLine(rectangle);
            }
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0}, W:{1:F}, L:{2:F}, A:{3:F}", upperLeftPoint, width, length, Area());
        }
    }

}
