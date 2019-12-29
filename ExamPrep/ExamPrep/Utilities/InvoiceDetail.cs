using System.Threading;

namespace Utilities
{
    public class InvoiceDetail
    {
        public decimal DbLineTotal { get; set; }

        public InvoiceDetail()
        {
            DbLineTotal = 0;
        }

        public InvoiceDetail(decimal lineTotal)
        {
            DbLineTotal = lineTotal;
        }

        public override string ToString()
        {
            return string.Format("{0:C2}", DbLineTotal);
        }
    }
}