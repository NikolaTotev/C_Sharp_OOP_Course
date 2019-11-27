using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibarary
{
    public interface IComparable
    {
        double SizeOf();
        IComparable this[string index]
        {
            get;
            set;
        }
    }
}
