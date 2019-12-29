using System;
using System.Linq;

namespace Utilities
{
    public static class InvoiceExtensions
    {
        public static void AddAllInvoice(this Invoice invoice, InvoiceDetail[] detailsToAdd)
        {
            if (invoice is null || detailsToAdd is null || detailsToAdd.Length == 0)
            {
                return;
            }

            if (invoice.InvoiceItems is null || invoice.InvoiceItems.Length == 0)
            {
                invoice.InvoiceItems = detailsToAdd;
            }
            else
            {
                invoice.InvoiceItems = detailsToAdd.Concat(invoice.InvoiceItems).ToArray();
            }
        }
    }
}