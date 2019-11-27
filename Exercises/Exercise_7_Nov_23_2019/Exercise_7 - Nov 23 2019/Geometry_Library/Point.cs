using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Library
{
    public struct Point : Geometry_Library.IComparable
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        #region Explicit IComparable implementation

        IComparable IComparable.this[string index]
        {
            get => index != null && index == "point" ? this : new Point();
            set => this = index != null
                          && index == "point"
                          && value is Point ?
                (Point)value : new Point();
        }

        double IComparable.SizeOf()
        {
            return Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
        }
        #endregion
        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", X, Y, Z));
        }
    }
}
