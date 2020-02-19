using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Common
{
    public class StatusMessage
    {
        public MessageType.MessageTypes messageType { get; set; }
        public string message { get; set; }
        
        public StatusMessage(MessageType.MessageTypes messageType1, string p)
        {
            // TODO: Complete member initialization
            this.messageType = messageType1;
            this.message = p;
        }

    }
}
