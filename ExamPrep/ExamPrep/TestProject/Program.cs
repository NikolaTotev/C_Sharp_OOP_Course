using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random sumGen = new Random();
            int numberOfDetails = 10;
            InvoiceDetail[] invoiceDetails = new InvoiceDetail[numberOfDetails];

            for (int i = 0; i < numberOfDetails; i++)
            {
                invoiceDetails[i] = new InvoiceDetail(sumGen.Next(0, 50));
            }

            Invoice invoice1 = new Invoice();
            Invoice invoice2 = new Invoice();

            invoice1.InvoiceItems = new[] { invoiceDetails[0] };
            invoice2.InvoiceItems = new[] { invoiceDetails[1] };

            IReceivable i1 = invoice1;
            IOutgoing i2 = invoice2;

            invoice1.AddAllInvoice(invoiceDetails);
            List<Invoice> myInvoices = new List<Invoice>(){invoice1, invoice2};
            Invoice.PrintInvoices(myInvoices.ToArray());
            
            Console.WriteLine("i1 & i2 are {0}", (i1.Equals(i2)? "equal":"not equal"));
            Console.WriteLine();
            Console.WriteLine("i1: {0}", i1.ToString());
            Console.WriteLine();
            Console.WriteLine("i2: {0}", i2.ToString());
        }
    }
}
