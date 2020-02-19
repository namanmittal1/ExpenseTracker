using System;
using System.Collections.Generic;
using System.Data.SQLite;
using DataAccessLayer.ExpenseModule;
using ExpenseTracker.DataBaseConnectionModule;
using ExpenseCommon;

namespace ExpenseTrackerService.ExpenseModule
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ExpenseService : IExpenseService
    {
        DataBaseConnection sbConnection = DataBaseConnection.GetDbInstance();

        public Boolean EnterExpense(Expense value)
        {
            Boolean _status = false;
            Item NewcreatedItem=null;
            Item PreExistingItem = GetSelectedItem(value.SelectedItem);
            if (PreExistingItem != null)
            {
                if (PreExistingItem.ItemName.Equals(value.SelectedItem.ItemName) &&
                    PreExistingItem.ItemAmount == value.SelectedItem.ItemAmount &&
                    PreExistingItem.LoggedinUserId == value.SelectedItem.LoggedinUserId)
                {
                    value.SelectedItem.ItemQuantity += PreExistingItem.ItemQuantity;
                    _status = UpdateExistingItem(value.SelectedItem);
                }
                else
                {
                    Boolean status = InsertNewItem(value.SelectedItem);
                    if (status)
                        NewcreatedItem = GetSelectedItem(value.SelectedItem);
                    value.SelectedItem = NewcreatedItem;
                    _status = true;
                }
            }
            else
            {
                Boolean status = InsertNewItem(value.SelectedItem);
                if (status)
                    NewcreatedItem = GetSelectedItem(value.SelectedItem);
                value.SelectedItem = NewcreatedItem;
                _status = true;
            }
            if (_status)
                _status = InsertNewExpense(value);
            else
                _status = false;
            
            return _status;
        }

        private Boolean UpdateExistingItem(Item item)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {                
                connection = sbConnection.GetDBConnection();
                string SQL = "Update Items set Quantity='" + item.ItemQuantity + "', Amount='" + item.ItemAmount + "' where Id='" + item.ItemID + "' AND LoggedinUserId ='" + item.LoggedinUserId + "'";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;
                Boolean result = ExpenseManager.UpdateEntity(cmd, connection);
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
        private Boolean InsertNewItem(Item item)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                connection = sbConnection.GetDBConnection();
                string SQL = "INSERT INTO Items (ItemName,Quantity,Amount,LoggedinUserId,DateCreated_Item) VALUES";
                SQL += "(@itemname, @quantity,@amount,@LoggedinUserId,@datecreated)";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@itemname", item.ItemName);
                cmd.Parameters.AddWithValue("@quantity", item.ItemQuantity);
                cmd.Parameters.AddWithValue("@amount", item.ItemAmount);
                cmd.Parameters.AddWithValue("@LoggedinUserId", item.LoggedinUserId);
                cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);

                Boolean result = ExpenseManager.InsertUpdateRemoveEntity(cmd, connection);

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

        private Boolean InsertNewExpense(Expense expense)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                connection = sbConnection.GetDBConnection();
                string SQL = "INSERT INTO Expenses (LoggedinUserId,CategoryId,ItemId,Remarks,RadioHomeSelected,RadioOfficeSelected,RadioNoneSelected,DateCreated) VALUES";
                SQL += "(@LoggedinUserId, @CategoryId,@ItemId,@Remarks,@RadioHomeSelected,@RadioOfficeSelected,@RadioNoneSelected,@datecreated)";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@LoggedinUserId", expense.LoggedInUser.UserId);
                cmd.Parameters.AddWithValue("@CategoryId", expense.SelectedCategory.CategoryID);
                cmd.Parameters.AddWithValue("@ItemId", expense.SelectedItem.ItemID);
                cmd.Parameters.AddWithValue("@Remarks", expense.Remarks);
                cmd.Parameters.AddWithValue("@RadioHomeSelected", ParseRadioValues(expense.RadioHomeSelected));
                cmd.Parameters.AddWithValue("@RadioOfficeSelected", ParseRadioValues(expense.RadioOfficeSelected));
                cmd.Parameters.AddWithValue("@RadioNoneSelected", ParseRadioValues(expense.RadioNoneSelected));
                cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);
                Boolean result = ExpenseManager.InsertUpdateRemoveEntity(cmd, connection);

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

        private Int32 ParseRadioValues(Boolean val)
        {
            if (val)
                return 1;
            else
                return 0;
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

                SQLiteDataReader reader = ExpenseManager.GetAllEntities(cmd, connection);
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

        public List<Item> GetItems(Int32 userId)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                List<Item> items = new List<Item>();
                connection = sbConnection.GetDBConnection();
                string SQL = "Select * From Items Where LoggedinUserId = " + userId;

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = ExpenseManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    items.Add(new Item(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }

                return items;
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
 
        public Item GetSelectedItem(Item item)
        {
            SQLiteConnection connection = null;
            SQLiteCommand cmd = null;
            try
            {
                Item selectedItem = new Item(item.ItemID,item.ItemName,item.LoggedinUserId);
                connection = sbConnection.GetDBConnection();
                string SQL = "Select Id, ItemName, Quantity, Amount, LoggedinUserId From Items WHERE ItemName='" + item.ItemName + "' AND LoggedinUserId='" + item.LoggedinUserId + "' order by DateCreated_Item desc limit 1";

                cmd = new SQLiteCommand(SQL);
                cmd.Connection = connection;

                SQLiteDataReader reader = ExpenseManager.GetAllEntities(cmd, connection);
                while (reader.Read())
                {
                    selectedItem.ItemID = reader.GetInt32(0);
                    selectedItem.ItemName = reader.GetString(1);
                    selectedItem.ItemQuantity = reader.GetInt32(2);
                    selectedItem.ItemAmount = reader.GetFloat(3);
                    selectedItem.LoggedinUserId = reader.GetInt32(4);
                }

                if (selectedItem.ItemQuantity != 0)
                    return selectedItem;
                else
                    return null;
            }
            catch (Exception)
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
