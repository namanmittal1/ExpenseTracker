using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerService.StatisticsAnalyticsModule
{
    [DataContract]
    public class StatisticsData :IComparable
    {
        public StatisticsData(String CategoryName, float ExpenseAmount)
        {
            this.CategoryName = CategoryName;
            this.ExpenseAmount = ExpenseAmount;
        }

        [DataMember]
        public String CategoryName { get; set; }

        [DataMember]
        public float ExpenseAmount { get; set; }
           
        public int CompareTo(object obj)
        {
            if (this.ExpenseAmount < (obj as StatisticsData).ExpenseAmount) return 1;
            else if (this.ExpenseAmount > (obj as StatisticsData).ExpenseAmount) return -1;
            else return 0;
        }
    }
}
