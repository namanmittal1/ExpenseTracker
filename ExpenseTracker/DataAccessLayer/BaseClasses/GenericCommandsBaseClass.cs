using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseClasses
{
    public class GenericCommandsBaseClass
    {
        public static Boolean InsertUpdateRemoveEntity(SQLiteCommand cmd, SQLiteConnection connection)
        {
            SQLiteTransaction trans;
            trans = connection.BeginTransaction();
            cmd.Transaction = trans;
            int retval = 0;
            try
            {
                retval = cmd.ExecuteNonQuery();
                if (retval == 1)
                {
                    trans.Commit();
                    return true;
                }
                else
                {
                    trans.Rollback();
                    return false;
                }
            }
            catch (SQLiteException ex)
            {
                trans.Rollback();
                return false;
            }
            finally
            {                
               
            }
        }

        public static SQLiteDataReader GetAllEntities(SQLiteCommand cmd, SQLiteConnection connection)
        {
            try
            {
                SQLiteDataReader r = cmd.ExecuteReader();
                return r;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        public static Boolean UpdateEntity(SQLiteCommand cmd, SQLiteConnection connection)
        {
            return (InsertUpdateRemoveEntity(cmd, connection));
        }

        public static Boolean RemoveEntity(SQLiteCommand cmd, SQLiteConnection connection)
        {
            return (InsertUpdateRemoveEntity(cmd, connection));
        }
    }
}
