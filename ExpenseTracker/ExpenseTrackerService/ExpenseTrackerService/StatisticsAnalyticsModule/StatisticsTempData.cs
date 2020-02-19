using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerService.StatisticsAnalyticsModule
{
     [DataContract]
    public class StatisticsTempData
    {
        public StatisticsTempData(String CategoryName, Int32 Quantity, float Amount)
        {
            this.CategoryName = CategoryName;
            this.Quantity = Quantity;
            this.Amount = Amount;
        }

          [DataMember]
        public String CategoryName { get; set; }

          [DataMember]
        public Int32 Quantity { get; set; }

          [DataMember]
          public float Amount { get; set; }
    }
}
