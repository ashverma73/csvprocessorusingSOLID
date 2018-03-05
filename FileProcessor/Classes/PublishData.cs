using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;

namespace FileProcessor
{
    public class PublishData : IPublishData
    {
        public void DisplayData(IEnumerable<IBaseFile> data, string fileName, double median)
        {
            if (data == null || data.Count() == 0)
            {
                Console.WriteLine($"No Outliers for file {fileName} and median {median}. ");
                return;
            }
            Console.WriteLine("{file name}\t\t {datetime}\t {value}\t {median value} ");
            foreach (var r in data)
            {
                var dt = r as BaseFileType;
                var val = r is LPFileType ? (r as LPFileType)?.Datavalue : (r as TOUFileType)?.Energy;
                Console.WriteLine($"{fileName}\t {dt?.DateTime} \t {val } \t {median}");
            }
        }
    }
}
