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
    class PaymentDAL
    {
        public bool Confirm_PaymentDAL(Customer aCustomer, Record aRecord, Cost aCost)
        {

            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE CUSTOMER set CUSTOMER.Name = '" + aCustomer.Name + "',CUSTOMER.Age = " + aCustomer.Age + ",CUSTOMER.Sex = '" + aCustomer.Sex + "',CUSTOMER.DOB = '" + aCustomer.DOB + "',CUSTOMER.Profession = '" + aCustomer.Profession + "',CUSTOMER.ProfessionAddress = '" + aCustomer.ProfessionAddress + "',CUSTOMER.PermanentAddress = '" + aCustomer.PermanentAddress + "',CUSTOMER.PresentAddress = '" + aCustomer.PresentAddress + "',CUSTOMER.ContactNo = '" + aCustomer.ContactNo + "',CUSTOMER.Email = '" + aCustomer.Email + "',CUSTOMER.[NID/PassportNo] = '" + aCustomer.NIDorPassportNo + "' where CUSTOMER.Id = " + aCustomer.Id + " UPDATE RECORD set RoomId = " + aRecord.RoomID + ", RoomNo = '" + aRecord.RoomNO + "', BookingDate = '" + aRecord.BookingDate + "', CheckInDate = '" + aRecord.CheckInDate + "', CheckOutDate = '" + aRecord.CheckOutDate + "', PaymentStatus = '" + aRecord.PaymentStatus + "', CustomerStatus = 'Checked Out' where RECORD.Id = " + aCustomer.Id + "  UPDATE COST Set Total= " + aCost.TotalCost + ", Due = " + aCost.Due + " where COST.Id = " + aCustomer.Id + "";
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

        public DataTable ViewPayment_InformationIn_textboxDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select CUSTOMER.Name,CUSTOMER.Age,CUSTOMER.Sex,CUSTOMER.DOB,CUSTOMER.Profession,CUSTOMER.ProfessionAddress,CUSTOMER.PermanentAddress,CUSTOMER.PresentAddress,CUSTOMER.ContactNo,CUSTOMER.Email,CUSTOMER.[NID/PassportNo],RECORD.RoomId,RECORD.RoomNo,RECORD.BookingDate,RECORD.CheckInDate,RECORD.CheckOutDate,COST.Total,COST.DUE FROM CUSTOMER join RECORD on CUSTOMER.Id=RECORD.Id  join Cost on CUSTOMER.Id=COST.Id where Customer.Id=" + aCustomer.Id + " ";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = Action;
            sda.Fill(dTable);
            return dTable;

        }
        public DataTable Payment_ConfirmationDAL(Customer aCustomer)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Record.ID,Customer.name,Record.RoomNo,Record.BookingDate,Record.CheckInDate,Record.CheckOutDate,Record.PaymentStatus,Record.CustomerStatus,Customer.ContactNo from RECORD join Customer on Record.Id=Customer.Id where Customer.id='" + aCustomer.Id+ "'";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool Cancel_PaymentDAL(int ReservationID, Cost aCost)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE COST set Due=" + aCost.Due + " +(select LastPayment from Cost where Id=" + ReservationID + ") where ID=" + ReservationID + " ";
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
        public DataTable Get_CustomerDetails_For_DiscountDAL(Cost aCost)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Customer.ID,Customer.Name,Cost.Total,Cost.Due from Customer join Cost on Customer.id=Cost.id where Customer.id="+aCost .Id+"";
            SqlCommand Action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = Action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool Save_Customer_DiscountDAL(Cost aCost)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE COST set Total="+aCost .TotalCost+",Due="+aCost.Due+",Discount="+aCost .Discount +" where id="+aCost .Id +"";
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
        public bool Cancel_Customer_DiscountDAL(Cost aCost)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE COST set Total=" + aCost.TotalCost + "+ (Select Discount from Cost where id=" + aCost.Id + "),Due=" + aCost.Due + "+( Select Discount from Cost where id="+aCost.Discount+") ,Discount=" + aCost.Discount + " +( Select Discount from Cost where id=" + aCost.Discount + ")   where id=" + aCost.Id + "";
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
