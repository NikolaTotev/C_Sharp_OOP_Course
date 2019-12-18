using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericParamConstraints
{
    // Multiple constraints can be applied to the same type parameter, 
    // and the constraints themselves can be generic types
    class EmployeeList<T> where T : Employee, IEmployee, System.IComparable<T>, new()
    {
        // ...
    }

    internal interface IEmployee
    {
    }
}
