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
    class CheckOutDAL
    {
        public bool Confirm_CheckoutnformationDAL(Customer aCustomer, Record aRecord, Cost aCost)
        {

            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE CUSTOMER set CUSTOMER.Name='" + aCustomer.Name + "',CUSTOMER.Age=" + aCustomer.Age + ",CUSTOMER.Sex='" + aCustomer.Sex + "',CUSTOMER.DOB='" + aCustomer.DOB + "',CUSTOMER.Profession='" + aCustomer.Profession + "',CUSTOMER.ProfessionAddress='" + aCustomer.ProfessionAddress + "',CUSTOMER.PermanentAddress='" + aCustomer.PermanentAddress + "',CUSTOMER.PresentAddress='" + aCustomer.PresentAddress + "',CUSTOMER.ContactNo='" + aCustomer.ContactNo + "',CUSTOMER.Email='" + aCustomer.Email + "',CUSTOMER.[NID/PassportNo]='" + aCustomer.NIDorPassportNo + "' where CUSTOMER.Id=" + aCustomer.Id + " UPDATE RECORD set RoomId=" + aRecord.RoomID + ",RoomNo='" + aRecord.RoomNO + "',BookingDate='" + aRecord.BookingDate + "',CheckInDate='" + aRecord.CheckInDate + "',CheckOutDate='" + aRecord.CheckOutDate + "',PaymentStatus='" + aRecord.PaymentStatus + "',CustomerStatus='Checked Out' where RECORD.Id=" + aCustomer.Id + "  UPDATE COST Set Total=" + aCost.TotalCost + ",Due=" + aCost.Due + ",LastPayment=" + aCost.LastPayment + " where COST.Id=" + aCustomer.Id + " UPDATE ROOM set ROOM.Status='Available' where Room_Id=" + aCustomer.Id + "";
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
        public DataTable checkOut_ConfirmationDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID,Customer.name,Record.RoomNo,Record.BookingDate,Record.CheckInDate,Record.CheckOutDate,Record.PaymentStatus,Record.CustomerStatus,Customer.ContactNo from RECORD join Customer on Record.Id=Customer.Id where Customer.id ='" + aCustomer.Id + "'";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
        public DataTable ViewCheckOut_InformationIn_textboxDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select CUSTOMER.Name,CUSTOMER.Age,CUSTOMER.Sex,CUSTOMER.DOB,CUSTOMER.Profession,CUSTOMER.ProfessionAddress,CUSTOMER.PermanentAddress,CUSTOMER.PresentAddress,CUSTOMER.ContactNo,CUSTOMER.Email,CUSTOMER.[NID/PassportNo],RECORD.RoomId,RECORD.RoomNo,RECORD.BookingDate,RECORD.CheckInDate,RECORD.CheckOutDate,COST.Total,COST.DUE FROM CUSTOMER join RECORD on CUSTOMER.Id=RECORD.Id  join COST on CUSTOMER.Id=COST.Id where (Customer.Id=" + aCustomer.Id + " and (RECORD.CustomerStatus ='Checked In' or RECORD.CustomerStatus ='Checked Out') )";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Action;
            sda.Fill(dTable);
            return dTable;

        }
        public bool Cancel_checkOutDAL(int ReservationID,Cost aCost)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE RECORD set CustomerStatus='Checked In' where RECORD.Id=" + ReservationID + "   UPDATE ROOM set ROOM.Status='Available' where Room_Id=(SELECT RECORD.RoomId from RECORD where Record.id=" + ReservationID + ") Upadte COST set Due=" + aCost.Due + " +(select LastPayment from Cost where Id=" + ReservationID + ") where ID=" + ReservationID + "";
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
    }
}
