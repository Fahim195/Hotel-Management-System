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
    class RoomDAL
    {
        public bool SaveRoomsDAL(Room aRoom)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Insert into Room(Floor,RoomNo,Type,Class,Rent,Status) values ('"+aRoom .Floor+ "','"+aRoom .RoomNo + "','"+aRoom .Type+ "','"+aRoom .Class + "',"+aRoom .Rent + ",'Available') ";
            SqlCommand Action = new SqlCommand(query ,connection);
            int Result=Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable ExistingRoomsDAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select * from Room";
            SqlCommand Action = new SqlCommand(query ,connection);
            SqlDataAdapter sda = new SqlDataAdapter() ;
            DataTable Dtable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(Dtable);
            return Dtable;
        }
        public bool UpdateRoomInfoDAL(Room aRoom)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Update ROOM set Floor='"+aRoom .Floor+"',RoomNo='"+aRoom .RoomNo+"',Type='"+aRoom .Type+"',Class='"+aRoom .Class +"',Rent="+aRoom .Rent+" where Room_Id="+aRoom .Id+" ";
            SqlCommand Action = new SqlCommand(query, connection);
            int result= Action.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable PredictRoomIDDAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "SELECT MAX(Room_ID) from Room";
            SqlCommand Action = new SqlCommand(query ,connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dTable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dTable);
            return dTable;
        }
        public bool DeleteRoomsDAL(Room aRoom)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "DELETE ROOM where Room_ID="+aRoom .Id+"";
            SqlCommand Action = new SqlCommand(query, connection);
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
