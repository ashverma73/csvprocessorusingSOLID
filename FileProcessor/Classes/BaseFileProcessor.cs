using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;


namespace FileProcessor
{
   public class BaseFileProcessor : IBaseFileProcessor
    {
      public double CalcMedian(double[] arrData)
        {
            double median = 0;
            var values = arrData.OrderBy(p => p).ToArray();
            var size = values.Length;
            var mid = size / 2;
            median = (size % 2 != 0) ? values[mid] : (values[mid] + values[mid + 1]) / 2;
            return median;
        }

        public virtual double CalcMedian(IBaseFile[] data)
        {
            return 0;
        }

        public virtual IEnumerable<IBaseFile> GetOutliers(IBaseFile[] data, double thresholdPercentage, double median)
        {
            return null;
        }

    
    }
}
