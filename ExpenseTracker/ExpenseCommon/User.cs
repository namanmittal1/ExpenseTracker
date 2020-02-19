using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseCommon
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }

         [DataMember]
        public String UserName { get; set; }

         [DataMember]
        public String Password { get; set; }
    }
}
