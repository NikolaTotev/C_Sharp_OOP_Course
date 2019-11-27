using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_8___General_exer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramHelper ph = new ProgramHelper();
            string vbCode = "Vb code";
            string cSharpCode = "C# code";
            string convertedVBCode = ((IConvertible)ph).ConvertToVB2015(cSharpCode);
            Console.WriteLine(convertedVBCode);
            string convertedCSCode = ((IConvertible)ph).ConvertToCSharp(vbCode);
            Console.WriteLine(convertedCSCode);

            bool isChecked = ((ICodeChecker)ph).CodeCheckSyntax(vbCode, "VB");
            Console.WriteLine(isChecked);

            Console.WriteLine("Use the explict version of the interface implementation");
            convertedCSCode = ((ICodeChecker)ph).ConvertToCSharp(vbCode);
            Console.WriteLine(convertedCSCode);
            Console.WriteLine("Use the public version of the interface implementation");
            Console.WriteLine("Bad practice!");
            convertedCSCode = ph.ConvertToCSharp(vbCode);
            Console.WriteLine(convertedCSCode);
        }
    }
}
