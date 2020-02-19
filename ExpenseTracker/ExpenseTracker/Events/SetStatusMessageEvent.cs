using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Common;
using Microsoft.Practices.Prism.Events;

namespace ExpenseTracker.Events
{
    class SetStatusMessageEvent : CompositePresentationEvent<StatusMessage>
    {
    }
}
