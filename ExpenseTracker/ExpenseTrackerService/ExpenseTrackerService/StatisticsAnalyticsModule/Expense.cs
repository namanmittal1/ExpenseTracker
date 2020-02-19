using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ExpenseCommon;

namespace ExpenseTrackerService.StatisticsAnalyticsModule
{
    [DataContract]
    public class Expense
    {
        [DataMember]
        public int ExpenseID { get; set; }
        [DataMember]
        public User LoggedInUser { get; set; }
        [DataMember]
        public Category SelectedCategory { get; set; }
        [DataMember]
        public Item SelectedItem { get; set; }
        [DataMember]
        public String Remarks { get; set; }
        [DataMember]
        public Boolean RadioHomeSelected { get; set; }
        [DataMember]
        public Boolean RadioOfficeSelected { get; set; }
        [DataMember]
        public Boolean RadioNoneSelected { get; set; }

    }
}
