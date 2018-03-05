using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Classes;
using FileProcessor;

namespace CSVFileProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
         
              
            ProcessFile(FileTypes.Files.LPF, @"C:\Users\ashish\Downloads\Samplefiles\Samplefiles\LP_214612653_20150907T220027915.csv");
            Console.ReadKey();
            ProcessFile(FileTypes.Files.TOU, @"C:\Users\ashish\Downloads\Samplefiles\Samplefiles\TOU_214667141_20150901T040057.csv");
            Console.ReadKey();
            
        }
        static void ProcessFile(FileTypes.Files fileType, string fileName)
        {
            try
            {
                IFileParser fileParser = new FileParser();
                IBaseFile baseFileType = null;
                IBaseFileProcessor basefileProcessor = null;
                switch (fileType)
                {
                    case FileTypes.Files.LPF:
                        baseFileType = new LPFileType();
                        basefileProcessor = new LPFFileProcessor();
                        break;
                    case FileTypes.Files.TOU:
                        baseFileType = new TOUFileType();
                        basefileProcessor = new TOUFileProcessor();
                        break;
                }
                if (!System.IO.File.Exists(fileName))
                {
                    Console.WriteLine("File does not exist");
                    return;
                }
                System.IO.FileInfo finfo = new System.IO.FileInfo(fileName);
                if (finfo.Extension != ".csv")
                {
                    Console.WriteLine("Invalid File");
                    return;
                }
                var data = fileParser.ParseFile(fileName, baseFileType);
               
                var median = basefileProcessor.CalcMedian(data.ToArray());
                var outliers = basefileProcessor?.GetOutliers(data.ToArray(),20,median);
                PublishData pub = new PublishData();
                pub.DisplayData(outliers, finfo.Name, median);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
