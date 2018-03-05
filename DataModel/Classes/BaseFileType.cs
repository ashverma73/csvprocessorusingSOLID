using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;


namespace DataModel.Classes
{
    public abstract class BaseFileType :IBaseFile
    {
        public int MeterPointCode { get; set; }
        public int SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime DateTime { get; set; }
        public string DataType { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
      
    }
}
