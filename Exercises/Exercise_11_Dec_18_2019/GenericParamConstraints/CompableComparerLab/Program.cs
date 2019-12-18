using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompableComparerLab
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Create an arary of Car objects.      
            Car[] arrayOfCars = new Car[6]
            {
            new Car("Ford",1992),
            new Car("Fiat",1988),
            new Car("Buick",1932),
            new Car("Ford",1932),
            new Car("Dodge",1999),
            new Car("Honda",1977)
            };

            // Write out a header for the output.
            Console.WriteLine("Array - Unsorted\n");

            foreach (Car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);

            // Demo IComparable by sorting array with "default" sort order.
            Array.Sort(arrayOfCars);
            Console.WriteLine("\nArray - Sorted by Make (Ascending - IComparable)\n");

            foreach (Car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);

            // Demo ascending sort of numeric value with IComparer.
            // Option 1. Use lambda expression
            Array.Sort(arrayOfCars, (c1, c2)=>Car.SortYearAscending(c1, c2));
            Console.WriteLine("\nArray - Sorted by Year (Ascending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);

            // Demo ascending sort of numeric value with IComparer.
            // Option 2. Use lambda expression
            Array.Sort(arrayOfCars, Car.SortYearAscending());
            Console.WriteLine("\nArray - Sorted by Year (Ascending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);

            // Demo descending sort of string value with IComparer.
            Array.Sort(arrayOfCars, Car.SortMakeDescending());
            Console.WriteLine("\nArray - Sorted by Make (Descending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);

            // Demo descending sort of numeric value using IComparer.
            Array.Sort(arrayOfCars, Car.SortYearDescending());
            Console.WriteLine("\nArray - Sorted by Year (Descending - IComparer)\n");

            foreach (Car c in arrayOfCars)
                Console.WriteLine(c.Make + "\t\t" + c.Year);

            Console.ReadLine();
        }
    }

}

