using Hotel_Management_System_Final_.DAL;
using Hotel_Management_System_Final_.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Final_.BLL
{
    class CheckoutBLL
    {
        public bool SaveCheckOutInformation_BLL(Customer aCustomer, Record aRecord, Cost aCost)
        {
            if (aCustomer.Name == "" || aCustomer.Age < 18 || aCustomer.Sex == "" || aCustomer.DOB == "" || aCustomer.Profession == "" || aCustomer.ProfessionAddress == "" || aCustomer.PresentAddress == "" || aCustomer.PermanentAddress == "" || aCustomer.ContactNo == "" || aCustomer.Email == "" || aCustomer.NIDorPassportNo == "" || aRecord.RoomID == 0 || aRecord.RoomNO == "" || aRecord.BookingDate == "" || aRecord.CheckInDate == "" || aRecord.CheckOutDate == "")
            {
                return false;
            }
            else
            {
                CheckOutDAL aCheckOutDAL = new CheckOutDAL();
                bool Result = aCheckOutDAL.Confirm_CheckoutnformationDAL(aCustomer, aRecord, aCost);
                return Result;
            }
        }
        public DataTable CheckOut_ConfirmationBLL(Customer aCustomer)
        {
            CheckOutDAL aCheckOutDAL = new CheckOutDAL();
            DataTable dTable = aCheckOutDAL.checkOut_ConfirmationDAL(aCustomer);
            return dTable;
        }
        public DataTable ViewCheckOut_InformationIn_textboxBLL(Customer aCustomer)
        {
            CheckOutDAL aCheckoutDAL = new CheckOutDAL();
            DataTable dTable = aCheckoutDAL.ViewCheckOut_InformationIn_textboxDAL(aCustomer);
            return dTable;
        }
        public bool Cancel_checkOutBLL(int ReservationID,Cost aCost)
        {
            CheckOutDAL aCheckoutDAL = new CheckOutDAL();
            bool res = aCheckoutDAL.Cancel_checkOutDAL(ReservationID, aCost);
            return res;
        }
    }
}
