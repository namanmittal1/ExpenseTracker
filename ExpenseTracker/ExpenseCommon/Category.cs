using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace ExpenseCommon
{
  [DataContract]
    public class Category
    {
        public Category(Int32 ID, String name, Int32 userId)
        {
            CategoryID = ID;
            CategoryName = name;
            UserId = userId;
        }

       [DataMember]
        public Int32 CategoryID { get; set; }

       [DataMember]
        public String CategoryName { get; set; }

       [DataMember]  
         public Int32 UserId { get; set; }
    }
}
