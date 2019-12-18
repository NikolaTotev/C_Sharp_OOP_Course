using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericParamConstraints
{
    class Alpha<X>
      where X : class
    { }
    // can apply constraints to multiple parameters, and multiple constraints to a single parameter
    
    class Beta<T, U>
      where T : class
      where U : class, T // the reference contraint class is required
    {
        Alpha<U> alpha; // won't compile without the reference contraint class for U
    }
    class Program
    {
       static void Main()
        {
            Beta<object, string> a = new Beta<object, string>();
            // illegal
            // Beta<object, int> b = new Beta<object, int>();
            // int is not a reference type
        }
    }
}
