using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;

namespace Project_1
{
    class Program
    {

        public static void Display<T>(IEnumerable<T> query, string header)
        {
            Console.WriteLine("LINQ execution:{0}", header);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            Invoice[] invoices =
            {
                new Invoice(83, "Electric Sander", 7, 57.98m),
                new Invoice(24, "Power saw", 18, 99.99m),
                new Invoice(7, "Sledge hammer", 11, 21.50m),
                new Invoice(77, "Hammer", 76, 11.99m),
                new Invoice(77, "Hammer", 30, 12m),
                new Invoice(39, "Lawn mower", 3, 79.50m),
                new Invoice(39, "Lawn mower", 6, 79.50m),
                new Invoice(68, "Screwdriver", 106, 6.99m),
                new Invoice(56, "Jig saw", 21, 11.00m),
                new Invoice(3, "Wrench", 34, 7.50m)
            };

            List<Invoice> invoiceList = new List<Invoice>()
            {
                new Invoice(83, "Electric Sander", 7, 57.98m),
                new Invoice(24, "Power saw", 18, 99.99m),
                new Invoice(7, "Sledge hammer", 11, 21.50m),
                new Invoice(77, "Hammer", 76, 11.99m),
                new Invoice(77, "Hammer", 30, 12m),
                new Invoice(39, "Lawn mower", 3, 79.50m),
                new Invoice(39, "Lawn mower", 6, 79.50m),
                new Invoice(68, "Screwdriver", 106, 6.99m),
                new Invoice(56, "Jig saw", 21, 11.00m),
                new Invoice(3, "Wrench", 34, 7.50m)
            };

            Display(SortByPrice(invoices), "Sort by price with lambda"); //Nov 6
            Display(SortByDescQuantity(invoices), "Sorted with tuples & lambda"); //Nov 6
            Display(SortByDescQuantity(invoiceList), "Same as previous but with list"); //Nov 6
            Display(SortByDescQuantityAsString(invoices), "Sorted with tuples as string"); //Nov 6

            Console.WriteLine("Dislpaying groups");
            Console.WriteLine();
            foreach (var grouping in GroupByPrice(invoices))
            {
                Console.WriteLine("Group {0} has {1} elements", grouping.Key, grouping.Count());
                foreach (var item in grouping)
                {
                    Console.WriteLine("{0}", item);
                }

                Console.WriteLine();
            }
                                                
        }


        //From previous exercise;
        private static void LINQasQuery(Invoice[] invoices)
        {
            var sortedByDesc = from invoice in invoices
                               orderby invoice.PartDescription
                               select invoice;

            Display(sortedByDesc, "Sorted by description.");


            var sortedByQuantity = from invoice in invoices
                                   orderby invoice.Quantity
                                   select invoice;

            Display(sortedByQuantity, "Sorted by quantity.");


            var sortedByQuantity2 = from invoice in invoices
                                    orderby invoice.PartNumber descending
                                    select new { Description = invoice.PartDescription, Quantity = invoice.Quantity };

            foreach (var item in sortedByQuantity2)
            {
                Console.WriteLine("{0, 20}{1 ,5}", item.Description, item.Quantity);
            }
            Console.WriteLine();


            var sortedByQuantityWithDoubles = from invoice in invoices //this is what var is IEnumerable<(string, int)>
                                              orderby invoice.PartNumber descending
                                              select (invoice.PartDescription, invoice.Quantity); ///Here you can return a couple of things at once.



            foreach (var item in sortedByQuantityWithDoubles)
            {
                Console.WriteLine("{0, 20}{1 ,5}", item.PartDescription, item.Quantity);
            }
            Console.WriteLine();

            foreach ((string, int) item in sortedByQuantityWithDoubles)
            {
                Console.WriteLine("{0, 20}{1 ,5}", item.Item1, item.Item2);
            }
            Console.WriteLine();


            var sortedInRange = from invoice in invoices
                                let total = invoice.Quantity * invoice.Price
                                orderby total
                                where total > 200 && total < 500
                                select (Description: invoice.PartDescription, TotalPrice: total);
            Console.WriteLine("{0, -20}{1,10}", "Description", "Total Price");
            foreach (var item in sortedInRange)
            {
                Console.WriteLine("{0, -20} {1 ,10:C}", item.Description, item.TotalPrice);
            }
            Console.WriteLine();


            //===================== Grouping 

            var groupInvoices = from invoice in invoices
                                group invoice by GetGroupName(invoice.Price) into grp
                                select grp;



            Console.WriteLine("List invoices by group");
            foreach (var invoiceGroup in groupInvoices)
            {
                Console.WriteLine("Group: {0}, contains: {1} elements", invoiceGroup.Key, invoiceGroup.Count());
                foreach (var invoice in invoiceGroup)
                {
                    Console.WriteLine(invoice);
                }
                Console.WriteLine();
            }
        }
        //=======================
        private static string GetGroupName(decimal price)
        {
            if (price == 12)
            {
                return "Equal to 12";
            }
            return price < 12 ? "Price below 12" : "Price above 12";
        }

        ///From here its Nov 6th Exercise ==========================================================================================
        public static IEnumerable<Invoice> SortByPrice(Invoice[] invoices)
        {
            var sortByPrice = invoices
                .OrderBy(invoice => invoice.PartDescription)
                .ThenByDescending(invoice => invoice.Price)
                .Select(invoice => invoice);
            return sortByPrice;
        }

        public static IEnumerable<(string, int)> SortByDescQuantity(Invoice[] invoices)
        {
            var sortedWithTuples = invoices
                .OrderByDescending(inv => inv.Quantity)
                .Select(inv => (inv.PartDescription, inv.Quantity));
            return sortedWithTuples;
        }

        /// <summary>
        /// With list.
        /// </summary>
        /// <param name="invoices"></param>
        /// <returns></returns>
        public static IEnumerable<(string, int)> SortByDescQuantity(List<Invoice> invoices)
        {
            var sortedWithTuples = invoices
                .OrderByDescending(inv => inv.Quantity)
                .Select(inv => (inv.PartDescription, inv.Quantity));
            return sortedWithTuples;
        }

        public static IEnumerable<string> SortByDescQuantityAsString(Invoice[] invoices)
        {
            var sortedWithTuples = invoices
                .OrderByDescending(inv => inv.Quantity)
                .Select(inv => new { inv.PartDescription, inv.Quantity });

            foreach (var item in sortedWithTuples)
            {
                string output = string.Format("{0} -> {0}", item.PartDescription, item.Quantity);
                yield return output;
            }
        }

        public static IEnumerable<IGrouping<string, Invoice>> GroupByPrice(Invoice[] invoices)
        {
            var groupInvoices = invoices
                .OrderBy(invoice => invoice.PartDescription)
                .GroupBy(invoice => GetGroupName(invoice.Price));


            return groupInvoices;
        }
        ///=========================================================================================================================
    }
}
