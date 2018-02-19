using Hotel_Management_System_Final_.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Final_.DAL
{
    class SystemAccessDAL
    {

           public bool Save_new_AccessDAL(SystemAccess aSystemAccess)
        { 
            SqlConnection Connection = DBconnection.OpenConnection();
            string query = "Insert Into SystemAccess values('"+aSystemAccess .Username +"', '"+ aSystemAccess.Password + "','" +aSystemAccess .UserType+"')";
            SqlCommand Action = new SqlCommand(query ,Connection);
            int result = Action.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        public DataTable View_Existing_UserAccessDAL(SystemAccess aSystemAccess)
        {
            string query = "";
            if (aSystemAccess .UserType=="Admin")
            {
                query = "Select UserID,Password,AccessType from SystemAccess";
                
            }
            else
            {
                query = "Select UserID,Password,AccessType from SystemAccess where AccessType='Stuff'";
            }
            SqlConnection Connection = DBconnection.OpenConnection();
            
            SqlCommand Action = new SqlCommand(query, Connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Action;
            sda.Fill(dTable);
            return dTable;
        }
        public bool Update_UserAccess_DAL(SystemAccess aSystemAccess)
        {
            
            SqlConnection Connection = DBconnection.OpenConnection();
            string query = "Update SystemAccess set UserID='"+aSystemAccess .Username+"', Password='"+ aSystemAccess.Password + "',AccessType='"+aSystemAccess .UserType+"' where ID=(select Id where UserID='"+ aSystemAccess.Username+ "') ";
            SqlCommand Action = new SqlCommand(query, Connection);
            int result = Action.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete_UserAccessDAL(SystemAccess aSystemAccess)
        {
            SqlConnection Connection = DBconnection.OpenConnection();
            string query = "Delete SystemAccess where ID=(select Id where UserID='" + aSystemAccess.Username + "')";
            SqlCommand Action = new SqlCommand(query, Connection);
            int result = Action.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       


}

}






