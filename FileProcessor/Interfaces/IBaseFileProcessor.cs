using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;


namespace FileProcessor
{
    public interface IBaseFileProcessor
    {
        double CalcMedian(IBaseFile[] data);
        IEnumerable<IBaseFile> GetOutliers(IBaseFile[] data, double thresholdPercentage, double median);
     }
}
