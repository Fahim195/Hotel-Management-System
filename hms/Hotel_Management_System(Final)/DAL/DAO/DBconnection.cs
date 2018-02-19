using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Final_.DAL.DAO
{
    class DBconnection
    {
        public static SqlConnection OpenConnection()
        {
            string userName = System.Environment.UserName;
            string sqlServer = File.ReadAllText(@"C:\Users\"+userName+ @"\Documents\DataSource.txt");
            SqlConnection connection = new SqlConnection();
            string DbSereverLink = "Data Source="+sqlServer+ ";Database=HMS2;Integrated Security=SSPI";
            connection.ConnectionString = DbSereverLink;
            connection.Open();
            return connection;
        }
        public static SqlConnection OpneMasterConnction()
        {
            string sqlServer = File.ReadAllText(@"D:\DataSource.txt");
            SqlConnection connection = new SqlConnection();
            string DbSereverLink = "Data Source=" + sqlServer + ";Database=master;Integrated Security=SSPI";
            connection.ConnectionString = DbSereverLink;
            connection.Open();
            return connection;

        }
    }
}
