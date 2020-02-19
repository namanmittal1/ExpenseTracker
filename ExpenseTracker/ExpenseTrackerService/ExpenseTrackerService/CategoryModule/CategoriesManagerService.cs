using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.CategoryModule;
using ExpenseTracker.DataBaseConnectionModule;
using ExpenseCommon;

namespace ExpenseTrackerService.CategoryModule
{
    public class CategoriesManagerService :ICategoriesManagerService
    {
        DataBaseConnection sbConnection = DataBaseConnection.GetDbInstance();

        public Boolean AddCategory(Category category)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {                
                connection = sbConnection.GetDBConnection();
                string SQL = "INSERT INTO Categories (Name, LoggedinUserId) VALUES";
                SQL += "(@name,@LoggedinUserId)";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@name", category.CategoryName);
                cmd.Parameters.AddWithValue("@LoggedinUserId", category.UserId);
                Boolean result = CategoriesManager.InsertUpdateRemoveEntity(cmd, connection);
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }

        }

        public Boolean UpdateCategory(Category category)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                connection = sbConnection.GetDBConnection();
                string SQL = "Update Categories set Name='" + category.CategoryName + "' where Id=" + category.CategoryID + " AND LoggedinUserId = " + category.UserId;

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;
                Boolean result = CategoriesManager.UpdateEntity(cmd, connection);
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }

        public Boolean RemoveCategory(Category category)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
               
                connection = sbConnection.GetDBConnection();
                string SQL = "DELETE FROM Categories" + " WHERE Id=" + category.CategoryID + " AND LoggedinUserId =" + category.UserId;

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;
                Boolean result = CategoriesManager.RemoveEntity(cmd, connection);
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                cmd.Dispose();
                connection.Close();
            }
        }


        public List<Category> GetCategories(Int32 userId)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                List<Category> categories = new List<Category>();
                
                connection = sbConnection.GetDBConnection();
                string SQL = "Select * From Categories Where LoggedinUserId = " + userId;

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = CategoriesManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    categories.Add(new Category(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }

                return categories;
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

    }
}
