using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ExpenseTracker.MainRegionModule.ViewModels
{
    public class MethodLogger : IDisposable
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger
     (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static Object syncObj=new Object();
        private string methodName;
        public String MethodName
        {
            get { return methodName; }
            set
            {
                lock (syncObj)
                {
                    if (methodName != value) methodName = value;
                }
            }
        }
       
        public MethodLogger(MethodBase methodBase)
        {
            log = log4net.LogManager.GetLogger(methodBase.DeclaringType);
            MethodName=methodBase.Name;
            log.Info(methodBase.Name + " Started");
        }

        public void Dispose()
        {
            log.Info(MethodName + "Stopped");
        }
    }
    
}
