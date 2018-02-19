using Hotel_Management_System_Final_.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Final_.DAL
{
    class Restore_or_BackupDAL
    {
        public SqlDataReader DatabasesToComboboxDAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "EXEC sp_databases";
            SqlCommand action = new SqlCommand(query,connection);
            SqlDataReader reader= action.ExecuteReader();
            return reader;
        }
        public bool BackupDatabaseDAL(string database,string dataBase_Path)
        {
            try
            {
                SqlConnection connection = DBconnection.OpenConnection();
                string query = @"BACKUP DATABASE [" + database + "] TO DISK= '" + dataBase_Path + "\\" + database + " .bak'";
                SqlCommand action = new SqlCommand(query, connection);
                action.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }  
                
        }
        public bool RestoreDatabaseDAL(string database, string dataBase_Path)
        {
            
            try
            {
                SqlConnection connection = DBconnection.OpenConnection();
                string query = @"Restore database [" + database + "] from disk='" + dataBase_Path + "' with REPLACE ";
                SqlCommand action = new SqlCommand(query, connection); 
                action.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

    }
}
