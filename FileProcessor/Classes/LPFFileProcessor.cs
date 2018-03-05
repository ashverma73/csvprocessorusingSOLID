using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;

namespace FileProcessor
{
    public class LPFFileProcessor : BaseFileProcessor
    {
        public override double CalcMedian(IBaseFile[] data)
        {
            LPFileType[] derivedist = data.OfType<LPFileType>().ToArray();

            return CalcMedian(derivedist.Select(p => p.Datavalue).ToArray());
         
        }
        public override IEnumerable<IBaseFile> GetOutliers(IBaseFile[] data, double thresholdPercentage, double median)
        {
            LPFileType[] derivedist = data.OfType<LPFileType>().ToArray();
            var upperThreshold = median + (thresholdPercentage / 100) * median;
            var lowerThreshold = median - (thresholdPercentage / 100) * median;
            return derivedist.Where(p => p.Datavalue > upperThreshold || p.Datavalue < lowerThreshold);
        }



    }
}
