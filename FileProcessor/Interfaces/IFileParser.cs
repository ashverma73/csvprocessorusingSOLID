using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;

namespace FileProcessor
{
    public interface IFileParser
    {
        IEnumerable<IBaseFile> ParseFile(string fileName, IBaseFile fileInstance);
    }
}
