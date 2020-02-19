using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerService.CategoryModule;
using ExpenseTrackerService.ExpenseModule;

namespace ExpenseTrackerWindowsServiceHost
{
    internal class ExpenseManagerHost
    {
         static ServiceHost serviceHost = null;
         public ExpenseManagerHost()
        {
            
        }

        internal static void Start()
        {
           if (serviceHost != null)
           {
               serviceHost.Close();
           }

           //Create a ServiceHost for the ProductService type 
           //and provide base address.
           serviceHost =new ServiceHost(typeof(ExpenseService));

           //Open the ServiceHostBase to create listeners  
           //and start listening for messages.
           serviceHost.Open();
        }

        internal static void Stop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
