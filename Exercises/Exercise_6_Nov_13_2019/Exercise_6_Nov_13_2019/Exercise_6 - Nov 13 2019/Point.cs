using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise_6___Nov_13_2019
{
    public class Point //Notice how it is public. This is mandatory when creating a dll
    {

        private int[] coords;

        //Point ID
        public readonly string PId;
        private static long idCounter = 0;
        public int[] Coords
        {
            get { return new[] { coords[0], coords[1] }; }
            set
            {
                if (value != null && value.Length == 2)
                {
                    coords = new int[value.Length];
                    coords = new[] { value[0], value[1] };
                }
                else
                {
                    coords = new int[2];
                }
            }
        }

        //How to make the constructors in general an for when a test.
        public Point(int[] coords)
        {
            Coords = coords;
            PId = string.Format("P{0:D05}", idCounter++);
        }

        public Point() : this(new[] { 0, 0 })
        {

        }

        public Point(Point point) : this(point.coords)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}: [{1}]",PId, string.Join(", ", coords));
        }
    }
}
