using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.PubSubEvents;

namespace ExpenseTracker
{
    public class EventAggregatorProvider
    {
        [Export(typeof(IEventAggregator))]
        public IEventAggregator eventAggregator { get { return new EventAggregator(); } }
    }
}
