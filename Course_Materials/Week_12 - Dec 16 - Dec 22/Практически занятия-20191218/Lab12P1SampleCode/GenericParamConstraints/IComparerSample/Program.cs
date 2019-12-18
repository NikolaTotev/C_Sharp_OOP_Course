using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparerSample
{

    /// <summary>
   
       /// Covariance
    // Enables you to use a more derived type than originally specified.
    // You can assign an instance of IEnumerable<Derived> (IEnumerable(Of Derived) in Visual Basic) to a variable of type IEnumerable<Base>.
    
       ///Contravariance
    // Enables you to use a more generic (less derived) type than originally specified.
    // You can assign an instance of IEnumerable<Base> (IEnumerable(Of Base) in Visual Basic) to a variable of type IEnumerable<Derived>.
  
        /// Invariance
    //  Means that you can use only the type originally specified; so an invariant generic type parameter is neither covariant nor contravariant.
    //  You cannot assign an instance of IEnumerable<Base> (IEnumerable(Of Base) in Visual Basic) to a variable of type IEnumerable<Derived> or vice versa.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // You can pass ShapeAreaComparer, which implements IComparer<Shape>,
            // even though the constructor for SortedSet<Circle> expects 
            // IComparer<Circle>, because type parameter T of IComparer<T> is
            // contravariant.
            SortedSet<Circle> circlesByArea =
                new SortedSet<Circle>(new ShapeAreaComparer())
                    { new Circle(7.2), new Circle(100), null, new Circle(.01) };

            foreach (Circle c in circlesByArea)
            {
                Console.WriteLine(c == null ? "null" : "Circle with area " + c.Area);
            }
        }
    }

    /* This code example produces the following output:

    null
    Circle with area 0.000314159265358979
    Circle with area 162.860163162095
    Circle with area 31415.9265358979
     */
}
