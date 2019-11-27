using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9b_Problem_2
{
    class AlarmEventArgs: EventArgs
    {
        private int nRings;

        public AlarmEventArgs(int nrings)
        {
            NRings = nrings;
        }

        public int NRings
        {
            get{ return nRings;}
            set{nRings = value;
            }
        }
    }
}
