using System;
using System.Linq;
using System.Collections.Generic;
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
                new Invoice(77, "Hammer", 30, 11.99m),
                new Invoice(39, "Lawn mower", 3, 79.50m),
                new Invoice(39, "Lawn mower", 6, 79.50m),
                new Invoice(68, "Screwdriver", 106, 6.99m),
                new Invoice(56, "Jig saw", 21, 11.00m),
                new Invoice(3, "Wrench", 34, 7.50m)
            };

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
                                orderby total where total > 200 && total < 500
                                select (invoice.PartDescription, total);

            Display(sortedInRange, "Totals where total between 200 and 500");

        }
    }
}
