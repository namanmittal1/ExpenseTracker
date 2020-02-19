using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.LogingLogoutModule;
using ExpenseTracker.DataBaseConnectionModule;
using ExpenseCommon;
using ExpenseTrackerService.CategoryModule;
using System.Data;

namespace ExpenseTrackerService.LoginModule
{
    public class LoginManagerService : ILoginManagerService
    {
        DataBaseConnection sbConnection = DataBaseConnection.GetDbInstance();
        CategoriesManagerService categoryManagerService = new CategoriesManagerService();
        public Int32 Login(User loggedInuser)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                Boolean status = false;
                Int32 userID = 0;
                connection = sbConnection.GetDBConnection();
                string SQL = "Select * From Users WHERE USERNAME='" + loggedInuser.UserName + "' AND PASSWORD='" + loggedInuser.Password + "'";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = LoginLogoutManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    userID = reader.GetInt32(0);
                }
                if (userID != 0)
                {
                    status = SetCurrentUser(userID);
                    if (status)
                        status = GenerateBasicCategories(userID);
                }
                return userID;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        private Boolean SetCurrentUser(Int32 userID)
        {
            SQLiteConnection connection = null;
            connection = sbConnection.GetDBConnection();
            string SQL = "Update CurrentUser set UserId= " + userID + " where Id=1";

            SQLiteCommand cmd = new SQLiteCommand(SQL);
            cmd.Connection = connection;
            Boolean result = LoginLogoutManager.InsertUpdateRemoveEntity(cmd, connection);

            return result;
        }

        public Boolean Logout()
        {
            return (SetCurrentUser(0));
        }

        public Int32 GetCurrentUser()
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                Int32 userID = 0;
                connection = sbConnection.GetDBConnection();
                string SQL = "Select UserId From CurrentUser";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = LoginLogoutManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    userID = reader.GetInt32(0);
                }
                return userID;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        private Boolean GenerateBasicCategories(Int32 UserId)
        {
            try
            {
                List<Category> categories = categoryManagerService.GetCategories(UserId);
                Boolean status = false;
                if (categories.Count == 0)
                {
                    var basicCategories = Enum.GetValues(typeof(CategoriesEnum));
                    foreach (CategoriesEnum categoryName in basicCategories)
                    {
                        Category category = new Category(0, categoryName.ToString(), UserId);
                        status = categoryManagerService.AddCategory(category);
                    }
                }
                if (status)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Int32 GetUsersCount()
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                Int32 userID = 0;
                connection = sbConnection.GetDBConnection();
                string SQL = "Select * From Users";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = LoginLogoutManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    userID = reader.GetInt32(0);
                }
                return userID;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }
    }
}
