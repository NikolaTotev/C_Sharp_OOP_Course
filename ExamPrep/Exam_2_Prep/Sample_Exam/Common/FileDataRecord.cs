using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class FileDataRecord
    {
        public string FileName { get; set; }
        public string FileContents { get; set; }

        public FileDataRecord(string fileName, string contents)
        {
            FileName = fileName;
            FileContents = contents;
        }
    }
}
