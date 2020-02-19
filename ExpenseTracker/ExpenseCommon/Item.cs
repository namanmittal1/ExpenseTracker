using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseCommon
{
     [DataContract]
    public class Item
    {
         public Item(Int32 ID, String name, Int32 userId)
         {
             ItemID = ID;
             ItemName = name;
             LoggedinUserId = userId;
         }

          [DataMember]
         public int ItemID { get; set; }

           [DataMember]
         public String ItemName { get; set; }

           [DataMember]
         public int ItemQuantity { get; set; }

           [DataMember]
           public float ItemAmount { get; set; }

          [DataMember]
          public int LoggedinUserId { get; set; }
    }
}
