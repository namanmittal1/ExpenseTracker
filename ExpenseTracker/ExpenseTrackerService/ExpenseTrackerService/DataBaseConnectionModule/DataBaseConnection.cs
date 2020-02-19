using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.DataBaseConnectionModule
{
    public class DataBaseConnection
    {
        private static DataBaseConnection dbInstance;
        //static string fileName=@"ExpenseTracker.db";

#if DEBUG
        private static String DATAPATH = @"Data Source = E:\ExpenseTracker\ExpenseTracker.db; Version = 3 ";
#else
        private static String ExePath = System.AppDomain.CurrentDomain.BaseDirectory;
        private static String DATAPATH = "Data Source = " + ExePath + @"ExpenseTrackerDataBase\ExpenseTracker.db" + "; Version = 3 ";
#endif
        private readonly SQLiteConnection conn = new SQLiteConnection(DATAPATH);

        private DataBaseConnection()
        {
        }

        public static DataBaseConnection GetDbInstance()
        {
            if (dbInstance == null)
            {
                dbInstance = new DataBaseConnection();
            }
            return dbInstance;
        }

        public SQLiteConnection GetDBConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    var pragma = new SQLiteCommand("PRAGMA foreign_keys = true;", conn);
                    pragma.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
            }
            finally
            {
            }
            return conn;
        }
    }
}