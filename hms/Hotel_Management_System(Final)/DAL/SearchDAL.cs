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
    class SearchDAL
    {
        public DataTable SearchResultDAL(Customer aCustomer,Record aRecord,Room aRoom)
        {
            string query = "SELECT Customer.Id,Customer.Name,Customer.Age,Customer.Sex,Customer.DOB,Customer.Profession,Customer.ProfessionAddress,Customer.PermanentAddress,Customer.PresentAddress,Customer.ContactNo,Customer.Email,Customer.[NID/PassportNo],Record.RoomId,Record.RoomNo,Record.BookingDate,Record.CheckinDate,Record.CheckoutDate,Record.PaymentStatus,Record.CustomerStatus,Cost.Total,Cost.Due from CUSTOMER  join Record on Customer.id=RECORD.id join Cost on Customer.Id=Cost.id ";
            string Condition = "";
            bool Condition_joiner = false;
            if (aCustomer .Name !="")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.Name like '%"+aCustomer .Name +"%'";
                Condition_joiner = true;
            }
             if (aCustomer .Age !=0)
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.Age like '%"+ aCustomer.Age+"%'";
                Condition_joiner = true;
            }
            if (aCustomer .Id  !=0)
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.id like '%"+ aCustomer.Id +"%' ";
                Condition_joiner = true;
            }
            if (aCustomer .ProfessionAddress!="")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.ProfessionAddress like '%"+ aCustomer.ProfessionAddress+"%'";
                Condition_joiner = true;
            }
            if (aCustomer.PresentAddress!= "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.PresentAddress like '%" + aCustomer.PresentAddress + "%'";
                Condition_joiner = true;
            }
            if (aCustomer.PermanentAddress != "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.PermanentAddress like '%"+aCustomer.PermanentAddress+"%'";
                Condition_joiner = true;
            }
            if (aCustomer.ContactNo != "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.ContactNo like '%"+ aCustomer.ContactNo +"%'";
                Condition_joiner = true;
            }
            if (aCustomer.Email!= "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.Email like '%" + aCustomer.Email+ "%'";
                Condition_joiner = true;
            }
            if (aCustomer.NIDorPassportNo != "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Customer.[NID/PassportNo] like '%" + aCustomer.NIDorPassportNo +"%'";
                Condition_joiner = true;
            }
            if (aRoom.Floor!= "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Room.Floor like '%" + aRoom.Floor + "%'";
                Condition_joiner = true;
            }
            if (aRecord .RoomNO!= "")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Record.RoomNo like '%" + aRecord.RoomNO + "%'";
                Condition_joiner = true;
            }
            if (aRecord.BookingDate!= "" && aRecord.BookingDate != "yyyy-MM-dd")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Record.BookingDate=('" + aRecord.BookingDate + "')";
                Condition_joiner = true;
            }
            if (aRecord.CheckInDate != "" && aRecord.CheckInDate != "yyyy-MM-dd\r\n")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Record.CheckInDate=('" + aRecord.CheckInDate + "') ";
                Condition_joiner = true;
            }
            if (aRecord.CheckOutDate  != "" && aRecord.CheckOutDate != "yyyy-MM-dd\r\n")
            {
                if (Condition_joiner)
                {
                    Condition += " and ";
                }
                Condition += " Record.CheckOutDate=('" + aRecord.CheckOutDate + "')";
                Condition_joiner = true;
            }
            if (Condition_joiner )
            {
                query += " Where ";
            }

            query += Condition;
            SqlConnection connection = DBconnection.OpenConnection();
            SqlCommand Action = new SqlCommand(query ,connection );
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dTable = new DataTable();
            sda.SelectCommand = Action;
            sda.Fill(dTable );
            return dTable;
        }
    }
}
