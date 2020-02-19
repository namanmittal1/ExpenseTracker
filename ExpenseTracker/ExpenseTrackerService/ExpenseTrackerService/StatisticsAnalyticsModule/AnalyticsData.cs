using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerService.StatisticsAnalyticsModule
{
     [DataContract]
    public class AnalyticsData
    {
         public AnalyticsData(String categoryname, String itemName, Int32 quantity, Int32 amount, String remarks, DateTime date, Int32 radioHome, Int32 radiOffice, Int32 radioNone)
         {
             CategoryName = categoryname;
             ItemName = itemName;
             Quantity = quantity;
             Amount = amount;
             Remarks = remarks;
             Date = date;
             RadioHomeSelected = radioHome;
             RadioNoneSelected = radioNone;
             RadioOfficeSelected = radiOffice;
         }

        [DataMember]
        public String CategoryName { get; set; }
        [DataMember]
        public String ItemName { get; set; }
        [DataMember]
        public Int32 Quantity { get; set; }
        [DataMember]
        public Int32 Amount { get; set; }
        [DataMember]
        public String Remarks { get; set; }
        [DataMember]
        public String Source { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Int32 RadioHomeSelected { get; set; }

        [DataMember]
        public Int32 RadioOfficeSelected { get; set; }
        [DataMember]
        public Int32 RadioNoneSelected { get; set; }
    }
}
