using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_8___General_exer
{
    public interface IConvertibleCopy
    {
        string ConvertToCSharp(string vbCode);
        string ConvertToVB2015(string cSharpCode);
    }
}
