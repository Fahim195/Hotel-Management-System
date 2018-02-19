using Hotel_Management_System_Final_.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Final_.DAL
{
    class SignInDAL
    {
        public DataTable Check_UserID_and_PasswordDAL(SystemAccess aSystemAccess)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select ID from SystemAccess where ( UserID='"+aSystemAccess.Username+"' and Password='"+aSystemAccess .Password+"')";
            SqlCommand Action = new SqlCommand(query ,connection);
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            DataTable dTable = new DataTable();
            Sda.Fill(dTable );
            return dTable;
        }
        public DataTable Check_AccessID_and_PasswordDAL(SystemAccess aSystemAccess)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select ID from SystemAccess where ( UserID='" + aSystemAccess.Username + "' and Password='" + aSystemAccess.Password + "' and AccessType='"+aSystemAccess.UserType+"')";
            SqlCommand Action = new SqlCommand(query, connection);
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            DataTable dTable = new DataTable();
            Sda.Fill(dTable);
            return dTable;
        }
    }
}
