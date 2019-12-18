using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompableComparerLab
{
    public class Car : IComparable<Car>
    {
        // Beginning of nested classes.

        // Nested class to do ascending sort on year property.
        //Option 1
        private class SortYearAscendingHelper : IComparer<Car>
        {
            int IComparer<Car>.Compare(Car c1, Car c2)
            {

                if (c1.year > c2.year)
                    return 1;

                if (c1.year < c2.year)
                    return -1;

                else
                    return 0;
            }
        }
        //Option 2
        public static int SortYearAscending (Car c1, Car c2)
        {
            if (c1.year > c2.year)
                return 1;

            if (c1.year < c2.year)
                return -1;

            else
                return 0;
        }

        // Nested class to do descending sort on year property.
        private class SortYearDescendingHelper : IComparer<Car>
        {
            int IComparer<Car>.Compare(Car c1, Car c2)
            {
                if (c1.year < c2.year)
                    return 1;

                if (c1.year > c2.year)
                    return -1;

                else
                    return 0;
            }
        }

        // Nested class to do descending sort on make property.
        private class SortMakeDescendingHelper : IComparer<Car>
        {
            int IComparer<Car>.Compare(Car c1, Car c2)
            {
                return String.Compare(c2.make, c1.make);
            }
        }

        // End of nested classes.

        private int year;
        private string make;

        public Car(string Make, int Year)
        {
            make = Make;
            year = Year;
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        // Implement IComparable CompareTo to provide default sort order.
        int IComparable<Car>.CompareTo(Car car)
        {

            return String.Compare(this.make, car.make);
        }

        // Method to return IComparer object for sort helper.
        public static IComparer<Car> SortYearAscending()
        {
            return (IComparer<Car>)new SortYearAscendingHelper();
        }

        // Method to return IComparer object for sort helper.
        public static IComparer<Car> SortYearDescending()
        {
            return (IComparer<Car>)new SortYearDescendingHelper();
        }

        // Method to return IComparer object for sort helper.
        public static IComparer<Car> SortMakeDescending()
        {
            return (IComparer<Car>)new SortMakeDescendingHelper();
        }
    }
}
