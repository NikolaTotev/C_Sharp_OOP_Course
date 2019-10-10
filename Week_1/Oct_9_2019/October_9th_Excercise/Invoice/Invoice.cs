using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invoice
{
    public class Invoice
    {
        private int partDescription;
        private int partNumber;
        private int pricePerItem;
        private int quantity;

        public int PartDescription
        {
            get => default;
            set
            {
            }
        }

        public int PartNumber
        {
            get => default;
            set
            {
            }
        }

        public int PricePerItem
        {
            get => default;
            set
            {
            }
        }

        public int Quantity
        {
            get => default;
            set
            {
            }
        }

        public void GetInvoiceAmount()
        {
            throw new System.NotImplementedException();
        }

        public void GetInvoice()
        {
            throw new System.NotImplementedException();
        }
    }
}