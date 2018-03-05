using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;

namespace FileProcessor
{
   public class TOUFileProcessor :BaseFileProcessor
    {
        public override double CalcMedian(IBaseFile[] data)
        {
            TOUFileType[] derivedist = data.OfType<TOUFileType>().ToArray();
            return CalcMedian(derivedist.Select(p => p.Energy).ToArray());
          
        }

        public override IEnumerable<IBaseFile> GetOutliers(IBaseFile[] data, double thresholdPercentage, double median)
        {
            TOUFileType[] derivedist = data.OfType<TOUFileType>().ToArray();
            var upperThreshold = median + (thresholdPercentage / 100) * median;
            var lowerThreshold = median - (thresholdPercentage / 100) * median;
            return derivedist.Where(p => p.Energy > upperThreshold || p.Energy < lowerThreshold);
        }
    }
}
