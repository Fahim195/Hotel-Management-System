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
    class ReservationDAL
    {
                           
        public DataTable ViewAvailableRoomsIn_ReservationDAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select ROOM.Room_Id,ROOM.RoomNo,ROOM.Status from ROOM" ;
            SqlCommand Action = new SqlCommand(query ,connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
        public DataTable ViewRoomReservationPeriodDAL(int RoomID)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select CheckInDate,CheckOutDate from RECORD where RECORD.RoomId="+RoomID+"";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool SaveReservationInformation_DAL(Customer aCustomer, Record aRecord, Cost aCost)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Insert into CUSTOMER(Name,Age,Sex,DOB,Profession,ProfessionAddress,PermanentAddress,PresentAddress,ContactNo,Email,[NID/PassportNo]) Values('" + aCustomer.Name +"',"+aCustomer .Age + ",'" + aCustomer.Sex + "','" + aCustomer.DOB + "','" + aCustomer.Profession + "','" + aCustomer.ProfessionAddress + "','" + aCustomer.PermanentAddress + "','" + aCustomer.PresentAddress + "','" + aCustomer.ContactNo + "','" + aCustomer.Email + "','" + aCustomer.NIDorPassportNo+ "') INSERT into RECORD(Id,RoomId,RoomNo,BookingDate,CheckInDate,CheckOutDate,PaymentStatus,CustomerStatus) values("+aCustomer .Id+" ," + aRecord .RoomID +",'"+aRecord .RoomNO +"','"+aRecord .BookingDate+"','"+aRecord .CheckInDate+"','"+aRecord .CheckOutDate+"','"+aRecord .PaymentStatus + "','Boocked')  INSERT into COST values(" + aCustomer.Id + " ," + aCost .TotalCost +","+aCost .Due+","+aCost .LastPayment+",0)";
            SqlCommand Action = new SqlCommand(query ,connection);
            int Result = Action.ExecuteNonQuery();
            if (Result >0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DataTable Predict_Booking_ID_DAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "SELECT MAX(ID) from Customer";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Action;
            sda.Fill(dt);
            return dt;

        }
        public DataTable ViewReservationInformationIn_textboxBDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select CUSTOMER.Name,CUSTOMER.Age,CUSTOMER.Sex,CUSTOMER.DOB,CUSTOMER.Profession,CUSTOMER.ProfessionAddress,CUSTOMER.PermanentAddress,CUSTOMER.PresentAddress,CUSTOMER.ContactNo,CUSTOMER.Email,CUSTOMER.[NID/PassportNo],RECORD.RoomId,RECORD.RoomNo,RECORD.BookingDate,RECORD.CheckInDate,RECORD.CheckOutDate,COST.Total,COST.DUE FROM CUSTOMER join RECORD on CUSTOMER.Id=RECORD.Id join COST on CUSTOMER.Id=COST.Id where (Customer.Id="+aCustomer .Id+ " and RECORD.CustomerStatus !='Checked In' and RECORD.CustomerStatus !='Checked Out')";
            SqlCommand Action = new SqlCommand(query ,connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Action;
            sda.Fill(dTable);
            return dTable;

        }
        public DataTable BookingConfirmationDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID,Customer.name,Record.RoomNo,Record.BookingDate,Record.CheckInDate,Record.CheckOutDate,Record.PaymentStatus,Record.CustomerStatus,Customer.ContactNo from RECORD join Customer on Record.Id=Customer.Id where Customer.ContactNo ='" + aCustomer.ContactNo + "'";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool Update_ReservationInformationDAL(Customer aCustomer,Record aRecord,Cost aCost)
        {

            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE CUSTOMER set CUSTOMER.Name='" + aCustomer.Name + "',CUSTOMER.Age=" + aCustomer.Age + ",CUSTOMER.Sex='" + aCustomer.Sex + "',CUSTOMER.DOB='" + aCustomer.DOB + "',CUSTOMER.Profession='" + aCustomer.Profession + "',CUSTOMER.ProfessionAddress='" + aCustomer.ProfessionAddress + "',CUSTOMER.PermanentAddress='" + aCustomer.PermanentAddress + "',CUSTOMER.PresentAddress='" + aCustomer.PresentAddress + "',CUSTOMER.ContactNo='" + aCustomer.ContactNo + "',CUSTOMER.Email='" + aCustomer.Email + "',CUSTOMER.[NID/PassportNo]='" + aCustomer.NIDorPassportNo + "' where CUSTOMER.Id="+aCustomer .Id+" UPDATE RECORD set RoomId=" + aRecord.RoomID + ",RoomNo='" + aRecord.RoomNO + "',BookingDate='" + aRecord.BookingDate + "',CheckInDate='" + aRecord.CheckInDate + "',CheckOutDate='" + aRecord.CheckOutDate + "',PaymentStatus='" + aRecord.PaymentStatus + "',CustomerStatus='Boocked' where RECORD.Id="+aCustomer .Id+"  UPDATE COST Set Total=" + aCost.TotalCost+ ",Due=" + aCost.Due + ",LastPayment="+aCost .LastPayment+" where COST.Id=" + aCustomer .Id+"";
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable BookingUpdate_ConfirmationDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID,Customer.name,Record.RoomNo,Record.BookingDate,Record.CheckInDate,Record.CheckOutDate,Record.PaymentStatus,Record.CustomerStatus,Customer.ContactNo from RECORD join Customer on Record.Id=Customer.Id where Customer.ContactNo ='" + aCustomer.ContactNo + "'";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool CancelReservationDAL(Customer aCustomer)
        {

            SqlConnection connection = DBconnection.OpenConnection();
            string query = " UPDATE RECORD set  CustomerStatus='Reservation Cancelled' where RECORD.Id=" + aCustomer.Id + "";
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable TotalCost_CalculateDAL(int Days, Room aRoom)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Rent*"+Days+" from ROOM where Room_id="+aRoom .Id+"";
            SqlCommand Action = new SqlCommand(query ,connection);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Action;
            DataTable dTable = new DataTable();
            sda.Fill(dTable);
            return dTable;
        }
        public bool RoomBooking_avilityDAL(Record aRecord)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string Query = "UPDATE Record set RoomNo='" + aRecord.RoomNO + "' where RoomNo='" + aRecord.RoomNO + "' and (CheckInDate='" + aRecord.CheckInDate + "' or CheckInDate='" + aRecord.CheckOutDate + "' or CheckOutDate='" + aRecord.CheckInDate + "' or CheckOutDate='" + aRecord.CheckOutDate + "' or(CheckInDate Between '" + aRecord.CheckInDate + "' and '" + aRecord.CheckOutDate + "') or (CheckOutDate between  '" + aRecord.CheckInDate + "' and '" + aRecord.CheckOutDate+ "' ))";
            SqlCommand Action = new SqlCommand(Query, connection);
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
        public DataTable BookingCancel_ConfirmationDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID,Customer.name,Record.RoomNo,Record.BookingDate,Record.CheckInDate,Record.CheckOutDate,Record.PaymentStatus,Record.CustomerStatus,Customer.ContactNo from RECORD join Customer on Record.Id=Customer.Id where Customer.id ='" + aCustomer.Id+ "'";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
    }
}
