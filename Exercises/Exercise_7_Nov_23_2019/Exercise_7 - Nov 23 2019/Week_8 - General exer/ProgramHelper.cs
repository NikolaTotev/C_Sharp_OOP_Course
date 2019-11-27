using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_8___General_exer
{
    public class ProgramHelper : IConvertible, ICodeChecker, IConvertibleCopy
    {



        #region Public Interface implementation
        public virtual string ConvertToVB2015(string cSharpCode)
        {
            Console.WriteLine("ConvertToVB: converted {0} to VB", cSharpCode);
            return "ConvertToVB: converted... ";
        }

        public virtual string ConvertToCSharp(string vbCode)
        {
            Console.WriteLine("ConvertToCSharp: converted {0} to CSharp", vbCode);
            return "ConvertToCSharp: converted... ";
        }
        #endregion

        #region Explicit IConvertible implementation


        string IConvertible.ConvertToCSharp(string vbCode)
        {
            Console.WriteLine("IConvertible.ConvertToCSharp: converted {0} to CS", vbCode);
            return "IConvertible.ConvertToCSharp: converted... ";
        }
        string IConvertible.ConvertToVB2015(string cSharpCode)
        {
            Console.WriteLine("IConvertible.ConvertToVB2015: converted {0} to VB", cSharpCode);
            return "IConvertible.ConvertToVB: converted... ";
        }

        #endregion

        #region Explicit interface ICodeChecker implementation
        bool ICodeChecker.CodeCheckSyntax(string code2Check, string language)
        {
            Console.WriteLine("ICodeChecker.CodeCheckSyntax: code {0} to {1}",
                               code2Check, language);
            return true;
        }
        #endregion


        string IConvertibleCopy.ConvertToCSharp(string vbCode)
        {
            Console.WriteLine("IConvertibleCopy.ConvertToCSharp: converted {0} to CS", vbCode);
            return "IConvertible.ConvertToCSharp: converted... ";
        }
        string IConvertibleCopy.ConvertToVB2015(string cSharpCode)
        {
            Console.WriteLine("IConvertibleCopy.ConvertToVB2015: converted {0} to VB", cSharpCode);
            return "IConvertible.ConvertToVB: converted... ";
        }
    }
}
