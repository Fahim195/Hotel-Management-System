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
    class CheckOutBLL
    {
        public DataTable ViewCheckIN_InformationIn_textboxBLL(Customer aCustomer)
        {
            DataTable dTable;
            if (aCustomer.Id == 0)
            {
                dTable = null;
                return dTable;
            }
            else
            {
                CheckInDAL aCheckInDAL = new CheckInDAL();
                dTable = aCheckInDAL.ViewCheckIN_InformationIn_textboxDAL(aCustomer);
                return dTable;
            }

        }
        public DataTable Checkin_ConfirmationBLL(Customer aCustomer)
        {
            CheckInDAL aCheckinDAL = new CheckInDAL();
            DataTable dTable = aCheckinDAL.Checkin_ConfirmationDAL(aCustomer);
            return dTable;
        }
        public bool SaveCheckinInformation_BLL(Customer aCustomer, Record aRecord, Cost aCost)
        {
            if (aCustomer.Name == "" || aCustomer.Age < 18 || aCustomer.Sex == "" || aCustomer.DOB == "" || aCustomer.Profession == "" || aCustomer.ProfessionAddress == "" || aCustomer.PresentAddress == "" || aCustomer.PermanentAddress == "" || aCustomer.ContactNo == "" || aCustomer.Email == "" || aCustomer.NIDorPassportNo == "" || aRecord.RoomID == 0 || aRecord.RoomNO == "" || aRecord.BookingDate == "" || aRecord.CheckInDate == "" || aRecord.CheckOutDate == "" || aRecord.PaymentStatus == "" || aCost.TotalCost == 0 || aCost.Due == 0)
            {
                return false;
            }
            else
            {
                CheckInDAL aCheckinDAL = new CheckInDAL();
                bool Result= aCheckinDAL.Confirm_CheckinInformationDAL(aCustomer ,aRecord,aCost);
                return Result;
            }
        }
        public bool Cancel_checkInBLL(int ReservationID,Cost aCost)
        {
            CheckInDAL aCheckinDAL = new CheckInDAL();
            bool result= aCheckinDAL.Cancel_checkInDAL(ReservationID,aCost);
            return result;
        }
    }
}
