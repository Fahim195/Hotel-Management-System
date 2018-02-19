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
    class RecordDAL
    {

        public DataTable ViewRecordINGridview(string DateforTimePerod_RecodView, int CheckIn, int CheckOut, string ComboboxText)
        {
            string query = "Select Record.id,Customer.Name,Record.RoomNo,Record.BookingDate,CheckInDate,CheckOutDate,Record.PaymentStatus,Record.CustomerStatus from Record join Customer on Record.id=Customer.id ";
            string FirstDate = "";
            string LastDate = "";
            string add = "";
            bool check = false;
            if (ComboboxText == "Last   3  Days")
            {
                FirstDate = "(select DATEADD(DAY, -3,'" + DateforTimePerod_RecodView + "'))";
                LastDate = " '"+DateforTimePerod_RecodView+"' ";
            }
            else if (ComboboxText == "Next  3  Days")
            {
                FirstDate = " '" + DateforTimePerod_RecodView + "' ";
                LastDate = "(select DATEADD(DAY, 3,'" + DateforTimePerod_RecodView + "'))";
            }
            else if (ComboboxText == "Last   7  Days")
            {
                FirstDate = "(select DATEADD(DAY, -7,'" + DateforTimePerod_RecodView + "'))";
                LastDate = " '" + DateforTimePerod_RecodView + "' ";
            }
            else if(ComboboxText == "Next  7  Days")
            {
                FirstDate = " '" + DateforTimePerod_RecodView + "' ";
                LastDate = "(select DATEADD(DAY, 7,'" + DateforTimePerod_RecodView + "'))";
            }
            else if (ComboboxText == "Last  15 Days")
            {
                FirstDate = "(select DATEADD(DAY, -15,'" + DateforTimePerod_RecodView + "'))";
                LastDate = " '" + DateforTimePerod_RecodView + "' ";
            }
            else if (ComboboxText == "Next 15 Days")
            {
                FirstDate = " '" + DateforTimePerod_RecodView + "' ";
                LastDate = "(select DATEADD(DAY, 15,'" + DateforTimePerod_RecodView + "'))";
            }
            else if (ComboboxText == "Last  30 Days")
            {
                FirstDate = "(select DATEADD(DAY, -30,'" + DateforTimePerod_RecodView + "'))";
                LastDate = " '" + DateforTimePerod_RecodView + "' ";
            }
            else if (ComboboxText == "Next 30 Days")
            {
                FirstDate = " '" + DateforTimePerod_RecodView + "' ";
                LastDate = "(select DATEADD(DAY, 15,'" + DateforTimePerod_RecodView + "'))";
            }
            else if (ComboboxText == "All Records")
            {
                query = "Select Record.id,Customer.Name,Record.RoomNo,Record.BookingDate,CheckInDate,CheckOutDate,Record.PaymentStatus,Record.CustomerStatus from Record join Customer on Record.id=Customer.id ";
            }

            if (CheckIn == 1 && ComboboxText != "All Records")
            {
                if (check)
                {
                    add += "or";
                }
                add += "CheckInDate Between "+FirstDate +"AND "+LastDate+"";
                check = true;
            }
            else if (CheckOut == 1 && ComboboxText != "All Records")
            {

                if (check)
                {
                    add += "or";
                }
                add += "CheckOutDate Between " + FirstDate + " AND " + LastDate + " ";
                check = true;
            }
            if (check)
            {
                query += " where ";
            }
            query += add;
            query += " order by Record.ID DESC ";

            SqlConnection Connection = DBconnection.OpenConnection();
            SqlCommand Action = new SqlCommand(query ,Connection);
            DataTable aDtable = new DataTable();
            SqlDataAdapter SAdapter = new SqlDataAdapter();
            SAdapter.SelectCommand = Action;
            SAdapter.Fill(aDtable);
            return aDtable;
        }
        public DataTable ViewSpecificRecordView(int Checkin,int Checkout,string DateForSpecificRecordView)
        {
            string query = "Select Record.id,Customer.Name,Record.RoomNo,Record.BookingDate,CheckInDate,CheckOutDate,Record.PaymentStatus,Record.CustomerStatus from Record join Customer on Record.id=Customer.id ";
            string add = "";
            bool check = false;
            if (Checkin==1)
            {  
                if (check)
                {
                    add += "or";
                }
                add += "CheckInDate='"+DateForSpecificRecordView+"' ";
                check = true;
            }
            else if(Checkout ==1) {

                if (check)
                {
                    add += "or";
                }
                add += "CheckOutDate='"+DateForSpecificRecordView+"' ";
                check = true;
            }
            if (check)
            {
                query+= " where ";
            }
            query += add;

            SqlConnection Connection = DBconnection.OpenConnection();
            SqlCommand Action = new SqlCommand(query, Connection);
            DataTable aDtable = new DataTable();
            SqlDataAdapter SAdapter = new SqlDataAdapter();
            SAdapter.SelectCommand = Action;
            SAdapter.Fill(aDtable);
            return aDtable;
        }
        public int Reservation_validityCheckDAL(string TodaysDate)
        {
            try
            {
                SqlConnection connection = DBconnection.OpenConnection();
                string Query = "Update RECORD set RECORD.CustomerStatus='Reservation Expired' where(RECORD.CheckInDate=(select DATEADD(DAY, -1,'" + TodaysDate + "')) and RECORD .CustomerStatus = 'Boocked' and RECORD.BookingDate is not NULL) ";
                SqlCommand Action = new SqlCommand(Query, connection);
                int No_ofReservationExpired = Action.ExecuteNonQuery();
                return No_ofReservationExpired;
            } 
            catch
            {
                return 0;
            }
        }
        public int No_of_Reservation_Expired(string TodaysDate)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string Query = "Update RECORD set RECORD.CustomerStatus='Reservation Expired' where(RECORD.CheckInDate=(select DATEADD(DAY, -1,'" + TodaysDate + "')) and RECORD.CustomerStatus='Reservation Expired')";
            SqlCommand Action = new SqlCommand(Query, connection);
            int number= Action.ExecuteNonQuery();
            return number;
        }
        public DataTable ReservationExired_List_DAL(string TodaysDate)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string Query = "Select * from RECORD where (RECORD.CheckInDate=(select DATEADD(DAY, -1,'" + TodaysDate + "')) and RECORD.CustomerStatus='Reservation Expired')";
            SqlCommand Action = new SqlCommand(Query, connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dTable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dTable);
            return dTable;
        }
    }
}
