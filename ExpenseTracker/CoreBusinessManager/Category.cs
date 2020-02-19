using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessManager
{
    public class Category
    {
        public Category(int iD, String name)
        {
            CategoryID = iD;
            CategoryName = name;
        }
        public int CategoryID { get; set; }
        public String CategoryName { get; set; }
    }
}
