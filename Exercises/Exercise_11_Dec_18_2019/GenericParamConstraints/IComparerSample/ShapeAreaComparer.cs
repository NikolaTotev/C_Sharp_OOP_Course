using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparerSample
{
    using System;
    using System.Collections.Generic;

    abstract class Shape
    {
        public virtual double Area { get { return 0; } }
    }

    class Circle : Shape
    {
        private double r;
        public Circle(double radius) { r = radius; }
        public double Radius { get { return r; } }
        public override double Area { get { return Math.PI * r * r; } }
    }

    class ShapeAreaComparer : System.Collections.Generic.IComparer<Shape>
    {
        int IComparer<Shape>.Compare(Shape a, Shape b)
        {
            if (a == null) return b == null ? 0 : -1;
            return b == null ? 1 : a.Area.CompareTo(b.Area);
        }
    }


}
