using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ExpenseCommon;

namespace ExpenseTrackerService.StatisticsAnalyticsModule
{
     [ServiceContract]
    public interface IStatisticsAnalyticsService
    {
         [OperationContract]
         List<AnalyticsData> GetAnalyticsData(Int32 LoggedUserId, Int32 categoryId, Int32 itemId, String fromDate, String toDate, String source);

         [OperationContract]
         List<StatisticsData> GetExpensesFromDataBase(Int32 LoggedUserId);
     }
}
