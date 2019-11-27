using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8
{
    public interface ICodeChecker: IConvertible
    {
        bool CodeCheckSyntax(string code2Check, string language);
    }
}
