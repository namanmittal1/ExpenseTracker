using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.NewAccountModule;
using ExpenseTracker.DataBaseConnectionModule;
using ExpenseCommon;

namespace ExpenseTrackerService.NewAccountModule
{
    public class NewAccountManagerService :INewAccountManagerService
    {
        DataBaseConnection sbConnection = DataBaseConnection.GetDbInstance();
        public Boolean CreateNewAccount(User user)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                
                connection = sbConnection.GetDBConnection();
                string SQL = "INSERT INTO Users (USERNAME,PASSWORD) VALUES";
                SQL += "(@username, @password)";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);

                Boolean result = CreateNewUserAccount.InsertUpdateRemoveEntity(cmd, connection);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }
              
    }
}
