using CrystalDecisions.CrystalReports.Engine;
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
    class ReportingDAL
    {
        public DataTable  Customer_Billing_SlipDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID, Customer.Name,Record.RoomNo,Record.BookingDate,Record.CheckinDate,Record.CheckOutDate,Customer.ContactNo,Cost.Total from CUSTOMER JOIN Record on Customer.Id=Record.Id JOIN Cost on Customer.id=Cost.id where Customer.id="+aCustomer .Id+"";
            SqlCommand Action = new SqlCommand(query ,connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dtable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dtable);
            return dtable;

        }
        public DataTable Specific_Customer_DetailsDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "SELECT Customer.Id,Customer.Name,Customer.Age,Customer.DOB,Customer.Profession,Customer.ProfessionAddress,Customer.PermanentAddress,Customer.PresentAddress,Customer.ContactNo,Customer.Email,Customer.[NID/PassportNo],Record.RoomNo,Record.BookingDate,Record.CheckinDate,Record.CheckoutDate,Record.PaymentStatus,Record.CustomerStatus,Cost.Total,Cost.Due from CUSTOMER  join Record on Customer.id=RECORD.id join Cost on Customer.Id=Cost.id where Customer.id="+aCustomer .Id+"";
            SqlCommand Action = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dtable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dtable);
            return dtable;
        }
        public DataTable AllRoomDetaisDAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select * from Room";
            SqlCommand Action = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dtable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dtable);
            return dtable;
        }
        public DataTable Current_week_reportDAL(string TodayDate)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID, Customer.Name,Record.RoomNo,Record.BookingDate,Record.CheckinDate,Record.CheckOutDate,Customer.ContactNo,Cost.Total from CUSTOMER JOIN Record on Customer.Id=Record.Id JOIN Cost on Customer.id=Cost.id where (Record.CheckInDate Between (select DATEADD(DAY, -7,'" + TodayDate + "')) AND '" + TodayDate + "') or(Record.BookingDate Between (select DATEADD(DAY, -7,'" + TodayDate + "')) AND '" + TodayDate + "') or (CheckOutDate Between (select DATEADD(DAY, -7,'" + TodayDate + "')) AND '" + TodayDate + "')";
            SqlCommand Action = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dtable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dtable);
            return dtable;
        }
        public DataTable Current_Month_reportDAL(string TodayDate)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID, Customer.Name,Record.RoomNo,Record.BookingDate,Record.CheckinDate,Record.CheckOutDate,Customer.ContactNo,Cost.Total from CUSTOMER JOIN Record on Customer.Id=Record.Id JOIN Cost on Customer.id=Cost.id where (Record.CheckInDate Between (select DATEADD(DAY, -30,'" + TodayDate + "')) AND '" + TodayDate + "') or(Record.BookingDate Between (select DATEADD(DAY, -30,'" + TodayDate + "')) AND '" + TodayDate + "') or (CheckOutDate Between (select DATEADD(DAY, -30,'" + TodayDate + "')) AND '" + TodayDate + "')";
            SqlCommand Action = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dtable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dtable);
            return dtable;
        }
        public DataTable Last_15Days_reportDAL(string TodayDate)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID, Customer.Name,Record.RoomNo,Record.BookingDate,Record.CheckinDate,Record.CheckOutDate,Customer.ContactNo,Cost.Total from CUSTOMER JOIN Record on Customer.Id=Record.Id JOIN Cost on Customer.id=Cost.id where (Record.CheckInDate Between (select DATEADD(DAY, -15,'" + TodayDate + "')) AND '" + TodayDate + "') or(Record.BookingDate Between (select DATEADD(DAY, -15,'" + TodayDate + "')) AND '" + TodayDate + "') or (CheckOutDate Between (select DATEADD(DAY, -15,'" + TodayDate + "')) AND '" + TodayDate + "')";
            SqlCommand Action = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dtable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dtable);
            return dtable;
        }
        //public DataTable CreateCustomized(Customer aCustomer)
        //{
        //    SqlConnection connection = DBconnection.OpenConnection();
        //    string query1 = "Insert";
        //    string query2 = "Select Record.ID, Customer.Name,Record.RoomNo,Record.BookingDate,Record.CheckinDate,Record.CheckOutDate,Customer.ContactNo,Cost.Total from CUSTOMER JOIN Record on Customer.Id=Record.Id JOIN Cost on Customer.id=Cost.id where (Record.CheckInDate Between '"+aCustomer .FromDate +"' AND '" +aCustomer .ToDate+ "') or(Record.BookingDate Between Between '" + aCustomer.FromDate + "' AND '" + aCustomer.ToDate + "') or (CheckOutDate Between Between '" + aCustomer.FromDate + "' AND '" + aCustomer.ToDate + "')";

        //}

    }
}
