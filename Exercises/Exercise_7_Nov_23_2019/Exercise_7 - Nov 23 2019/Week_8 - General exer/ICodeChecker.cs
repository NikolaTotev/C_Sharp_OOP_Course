using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_8___General_exer
{

    public interface ICodeChecker : IConvertible
    {
        bool CodeCheckSyntax(string code2Check, string language);
    }
}
