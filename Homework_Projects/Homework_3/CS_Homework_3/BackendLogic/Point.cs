using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLogic
{
    class Point:HeavyElement
    {
        public double CoordX { get; set; }
        public double CoordY{ get; set; }

        /// <summary>
        /// Default constructor/
        /// </summary>
        public Point()
        {
            CoordX = 0;
            CoordY = 0;
        }

        /// <summary>
        /// General purpose constructor.
        /// </summary>
        /// <param name="coordY"></param>
        /// <param name="coordX"></param>
        public Point(double coordY, double coordX)
        {
            CoordX = coordX;
            CoordY = coordY;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="previousPoint"></param>
        public Point(Point previousPoint)
        {
            CoordX = previousPoint.CoordX;
            CoordY = previousPoint.CoordY;
        }

        public override double CalcWeight()
        {
            return Weight;
        }
    }
}
