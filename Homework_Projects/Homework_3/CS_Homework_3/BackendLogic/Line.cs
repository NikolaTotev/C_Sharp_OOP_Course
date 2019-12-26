using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLogic
{
    class Line:Point
    {
        public Point sPoint { get; set; }
        public Point ePoint { get; set; }

        public Line()
        {
            sPoint = new Point(CoordX, CoordY);
        }

        public Line(double sCoordX, double sCoordY, double eCoordX, double eCoordY)
        {
            CoordX = sCoordX;
            CoordY = sCoordY;
            sPoint = new Point(CoordX, CoordY);
            ePoint = new Point(eCoordX, eCoordY);
        }

        public Line(Line previousLine)
        {
            sPoint = previousLine.sPoint;
            ePoint = previousLine.ePoint;
        }
    }
}
