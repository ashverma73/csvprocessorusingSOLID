using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataModel.Classes
{ 
    public class TOUFileType : BaseFileType
    {
        public double Energy { get; set; }
        public int MaxDemand { get; set; }
        public DateTime TimeMaxDemand { get; set; }
        public string Period { get; set; }
        public bool DlsActive { get; set; }
        public int BillingResetCount { get; set; }
        public DateTime BillingResetDate { get; set; }
        public string Rate { get; set; }
    }
}
