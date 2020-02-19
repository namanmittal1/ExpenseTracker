using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.StatisticsAnalyticsModule;
using ExpenseTracker.DataBaseConnectionModule;
using ExpenseCommon;

namespace ExpenseTrackerService.StatisticsAnalyticsModule
{
    public class StatisticsAnalyticsService :IStatisticsAnalyticsService
    {
        DataBaseConnection sbConnection = DataBaseConnection.GetDbInstance();

        #region Analytics
        public List<AnalyticsData> GetAnalyticsData(Int32 LoggedUserId, Int32 categoryId, Int32 itemId, String fromDate, String toDate, String source)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                List<AnalyticsData> data = new List<AnalyticsData>();
                connection = sbConnection.GetDBConnection();
                string SQL = GetSQLQuery(LoggedUserId, categoryId, itemId, fromDate, toDate, source);                
                
                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = StatisticsAnalyticsManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    data.Add(new AnalyticsData(reader.GetString(0),reader.GetString(1),reader.GetInt32(2),
                        reader.GetInt32(3), reader.GetString(4), reader.GetDateTime(5), 
                        reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8)));
                }

                return data;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        private string GetSQLQuery(int LoggedUserId, int categoryId, int itemId, String fromDate, String toDate, string source)
        {
            string SQL = "Select Name, ItemName, Quantity, Amount, Remarks, DateCreated, RadioHomeSelected, RadioOfficeSelected, RadioNoneSelected From Expenses INNER JOIN Items ON Expenses.ItemId = Items.Id INNER JOIN Categories ON Expenses.CategoryId = Categories.Id Where Expenses.LoggedinUserId = " + LoggedUserId;
            if (categoryId != 0)
            {
                SQL += " AND Expenses.CategoryId =" + categoryId;
            }
            if (itemId != 0)
            {
                SQL += " AND Expenses.ItemId =" + itemId;
            }
            if (fromDate != DateTime.MinValue.ToString() && toDate != DateTime.MinValue.ToString())
            {
                 SQL += " AND DateCreated BETWEEN'" + fromDate+"' AND '"+toDate+"'";
            }
            if (!source.Equals(""))
            {
                if (source.Contains("Home"))
                    SQL += " AND RadioHomeSelected =" + 1;

                else if (source.Contains("Office"))
                    SQL += " AND RadioOfficeSelected =" + 1;

                else if (source.Contains("None"))
                    SQL += " AND RadioNoneSelected =" + 1;
            }
            return SQL;
        }

        #endregion

        #region Statistics


        public List<StatisticsData> GetExpensesFromDataBase(Int32 LoggedUserId)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;

            String fromDate = GetFromDate();
            String toDate = GetToDate();

            try
            {
                List<StatisticsTempData> data = new List<StatisticsTempData>();
                connection = sbConnection.GetDBConnection();
                string SQL = "Select Name, Quantity, Amount From Expenses INNER JOIN Items ON Expenses.ItemId = Items.Id INNER JOIN Categories ON Expenses.CategoryId = Categories.Id Where Expenses.LoggedinUserId = " + LoggedUserId + " AND DateCreated BETWEEN'" + fromDate + "' AND '" + toDate + "'";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = StatisticsAnalyticsManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    data.Add(new StatisticsTempData(reader.GetString(0),reader.GetInt32(1),
                        reader.GetFloat(2)));
                }

                return (GenerateSortedCollectionWithCategoryAndAmount(data));
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        private List<StatisticsData> GenerateSortedCollectionWithCategoryAndAmount(List<StatisticsTempData> tempData)
        {
            List<StatisticsData> data = new List<StatisticsData>();
            foreach(StatisticsTempData d in tempData)
            {
                StatisticsData sd = new StatisticsData(d.CategoryName, d.Quantity * d.Amount);
                data.Add(sd);
            }
            data.Sort();
            return (GenerateCollectionWithSingleCategoryTotalAmount(data));
        }

        private List<StatisticsData> GenerateCollectionWithSingleCategoryTotalAmount(List<StatisticsData> data)
        {
            List<StatisticsData> finalData = new List<StatisticsData>();
            finalData = data.GroupBy(x => x.CategoryName).Select(itemGroup => new StatisticsData(
              itemGroup.Key,
              itemGroup.Sum(item => item.ExpenseAmount))).ToList <StatisticsData>();

            return finalData;
        }

        private String GetFromDate()
        {
            return (new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1).ToString("yyyy-MM-dd"));           
        }

        private String GetToDate()
        {
            var dt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
            var tm = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString());
            dt = dt + tm;
            return dt.ToString("yyyy-MM-dd h:mm:ss tt");
        }
        #endregion
    }
}
