using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probelm_3_StoreManager
{
    class Employee: EventArgs
    {
        private int quantity;
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
