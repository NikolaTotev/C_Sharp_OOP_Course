using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLogic
{
    public class MyPoint:HeavyElement
    {
        public double CoordX { get; set; }
        public double CoordY{ get; set; }

        /// <summary>
        /// Default constructor/
        /// </summary>
        public MyPoint()
        {
            CoordX = 0;
            CoordY = 0;
        }

        /// <summary>
        /// General purpose constructor.
        /// </summary>
        /// <param name="coordY"></param>
        /// <param name="coordX"></param>
        public MyPoint(double coordY, double coordX)
        {
            CoordX = coordX;
            CoordY = coordY;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="previousMyPoint"></param>
        public MyPoint(MyPoint previousMyPoint)
        {
            CoordX = previousMyPoint.CoordX;
            CoordY = previousMyPoint.CoordY;
        }

        public override double CalcWeight()
        {
            return Weight;
        }
    }
}
