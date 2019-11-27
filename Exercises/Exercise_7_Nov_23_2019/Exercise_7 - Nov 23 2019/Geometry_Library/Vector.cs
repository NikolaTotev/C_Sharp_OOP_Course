using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Library
{
    public struct Vector : Geometry_Library.IComparable
    {
        private Point start;
        private Point end;

        public Vector(Point start, Point end) : this()
        {
            Start = start;
            End = end;
        }

        public Point End
        {
            get { return end; }
            set { end = value; }
        }
        public Point Start
        {
            get { return start; }
            set { start = value; }
        }
        #region Explicit IComparable implementation

        double IComparable.SizeOf()
        {
            double dX = start.X - end.X;
            double dY = start.Y - end.Y;
            double dZ = start.Z - end.Z;
            return Math.Sqrt(dX * dX + dY * dY + dZ * dZ);
        }
        IComparable IComparable.this[string index]
        {
            get => index != null && index == "vector" ? this : new Vector();
            set => this = index != null
                          && index == "vector"
                          && value is Vector ?
                (Vector)value : new Vector();

        }
        #endregion
        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", start, end));
        }
    }
}
