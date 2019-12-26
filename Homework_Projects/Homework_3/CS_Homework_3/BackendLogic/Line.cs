using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendLogic
{
    public class Line:MyPoint
    {
        public MyPoint SMyPoint { get; set; }
        public MyPoint EMyPoint { get; set; }

        public Line()
        {
            SMyPoint = new MyPoint(CoordX, CoordY);
            Random r = new Random();
            Weight = r.Next(10000);
        }

        public Line(double sCoordX, double sCoordY, double eCoordX, double eCoordY, double weight)
        {
            CoordX = sCoordX;
            CoordY = sCoordY;
            SMyPoint = new MyPoint(CoordX, CoordY);
            EMyPoint = new MyPoint(eCoordX, eCoordY);
            Weight = weight;
        }

        public Line(Line previousLine)
        {
            SMyPoint = previousLine.SMyPoint;
            EMyPoint = previousLine.EMyPoint;
        }
    }
}
