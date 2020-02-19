using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessManager
{
    public class Expense
    {
        public User LoggedInUser { get; set; }
        public int Quantity {get; set;}
        public int Amount { get; set; }
        public String Remarks { get; set; }
        public Boolean RadioHomeSelected { get; set; }
        public Boolean RadioOfficeSelected { get; set; }
        public Boolean RadioNoneSelected { get; set; }
        public Category SelectedCategory { get; set; }
        public String SelectedItem { get; set; }
    }
}
