using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BackendLogic
{
    public abstract class HeavyElement
    {
        public double Weight { get; set; }

        public HeavyElement()
        {
            Random r = new Random();
            Weight = r.Next(10000);
        }

        public HeavyElement(double weight)
        {
            Weight = weight;
        }

        public abstract double CalcWeight();



    }
}
