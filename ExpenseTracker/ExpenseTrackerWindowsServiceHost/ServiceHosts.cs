using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerWindowsServiceHost
{
    public partial class ServiceHosts : ServiceBase
    {
        public ServiceHosts()
        {
            InitializeComponent();
            ServiceName = "Expense Tracker Services";
        }

        protected override void OnStart(string[] args)
        {
            ExpenseCategoriesHost.Start();
            ExpenseLoginHost.Start();
            ExpenseManagerHost.Start();
            ExpenseNewAccountHost.Start();
            ExpenseSAHost.Start();
        }

        protected override void OnStop()
        {
            ExpenseCategoriesHost.Stop();
            ExpenseLoginHost.Stop();
            ExpenseManagerHost.Stop();
            ExpenseNewAccountHost.Stop();
            ExpenseSAHost.Stop();
        }
    }
}
