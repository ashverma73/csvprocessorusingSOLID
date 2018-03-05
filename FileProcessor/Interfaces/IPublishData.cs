using DataModel.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
     interface IPublishData
    {
       void DisplayData(IEnumerable<IBaseFile> data, string fileName, double median);
    }
}
