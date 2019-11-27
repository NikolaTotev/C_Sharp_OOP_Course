using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibarary
{
    public struct Triangle
    {
        private Vector a;
        private Vector b;

        public Triangle(Vector a, Vector b):this()
        {
            A = a;
            B = b;
        }

        #region Properties
        public Vector B
        {
            get { return b; }
            set { b = value; }
        }
        public Vector A
        {
            get { return a; }
            set { a = value; }
        } 
        #endregion

    }
}
