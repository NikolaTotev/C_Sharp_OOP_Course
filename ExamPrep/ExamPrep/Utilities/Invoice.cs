using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Invoice : IReceivable, IOutgoing
    {
        private static long m_InstanceCounter;
        public long InvoiceNumber { get; private set; }
        public InvoiceDetail[] InvoiceItems { get; set; } = { };

        public Invoice()
        {
            this.InvoiceNumber = ++m_InstanceCounter;
        }

        public override string ToString()
        {
            string[] invoiceItemElements = new string[InvoiceItems.Length];
            for (int i = 0; i < InvoiceItems.Length; i++)
            {
                invoiceItemElements[i] = InvoiceItems[i].ToString();
            }
            string invoiceItems = string.Join($"{Environment.NewLine} - ", invoiceItemElements);
            return $"Invoice number: {InvoiceNumber}{Environment.NewLine}InvoiceItems:{Environment.NewLine} - {invoiceItems}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Invoice invoice)
            {
                return InvoiceTotal() == invoice.InvoiceTotal();
            }

            return false;
        }

        public decimal InvoiceTotal()
        {
            decimal sum = 0;
            foreach (var invoiceItem in InvoiceItems)
            {
                sum += invoiceItem.DbLineTotal;
            }

            return sum;
        }


        decimal IReceivable.InvoiceTotal => InvoiceTotal();

        decimal IOutgoing.InvoiceTotal => -InvoiceTotal();

        public static void PrintInvoices(Invoice[] invoices)
        {
            foreach (Invoice invoice in invoices)
            {
                var sortedInvoiceDetails =
                    from invoiceItem in invoice.InvoiceItems
                    orderby invoiceItem.DbLineTotal descending
                    select invoiceItem;

                Console.WriteLine("Invoice: {0}", invoice.InvoiceNumber);
                foreach (var sortedInvoiceDetail in sortedInvoiceDetails)
                {
                    Console.WriteLine("{0:C2}", sortedInvoiceDetail.DbLineTotal);
                }

                Console.WriteLine("Total: {0:C}", invoice.InvoiceTotal());

                Console.WriteLine();
            }
        }
    }
}
