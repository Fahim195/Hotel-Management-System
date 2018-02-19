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
    class ReservationBLL
    {
        public DataTable ViewAvailableRoomsIn_ReservationBLL()
        {
            ReservationDAL aReseravtionDAL = new ReservationDAL();
            DataTable dTable = aReseravtionDAL.ViewAvailableRoomsIn_ReservationDAL();
            return dTable;
        }
        public DataTable ViewRoomReservationPeriodBLL(int RoomID)
        {
            ReservationDAL aReseravtionDAL = new ReservationDAL();
            DataTable dTable = aReseravtionDAL.ViewRoomReservationPeriodDAL (RoomID);
            return dTable;
        }
        public bool SaveReservationInformation_BLL(Customer aCustomer,Record aRecord,Cost aCost )
        {
            if (aCustomer .Id==0||aCustomer.Name == "" || aCustomer.Age < 18 || aCustomer.Sex == "" || aCustomer.DOB == "" || aCustomer.Profession == "" || aCustomer.ProfessionAddress == "" || aCustomer.PresentAddress == "" || aCustomer.PermanentAddress == "" || aCustomer.ContactNo == "" || aCustomer.Email == "" || aCustomer.NIDorPassportNo == "" || aRecord.RoomID == 0 || aRecord.RoomNO == "" || aRecord.BookingDate == "" || aRecord.CheckInDate == "" ||aRecord.CheckOutDate == "" ||aRecord .PaymentStatus == "" || aCost.TotalCost ==0||aCost .Due ==0 )
            {
                return false;
            }
            else
            {
                ReservationDAL aReservationDAL = new ReservationDAL();
                bool Result = aReservationDAL.SaveReservationInformation_DAL(aCustomer ,aRecord ,aCost);
                return Result;
            }
        }
        public DataTable Predict_Booking_ID_BLL()
        {
            ReservationDAL aReservationDAL = new ReservationDAL();
            DataTable  BookingID = aReservationDAL.Predict_Booking_ID_DAL();
            return BookingID;
        }
        public DataTable ViewReservationInformationIn_textboxBLL(Customer aCustomer)
        {
            DataTable dTable;
            if (aCustomer .Id==0)
            {
                 dTable = null;
                return dTable;
            }
            else
            {
                ReservationDAL aReservationDAL = new ReservationDAL();
                dTable = aReservationDAL.ViewReservationInformationIn_textboxBDAL(aCustomer);
                return dTable;
            }
        }
        public DataTable Update_ReservationInformationBLL(Customer aCustomer)
        {
            ReservationDAL aReservation = new ReservationDAL();
            DataTable dTable= aReservation.BookingConfirmationDAL(aCustomer);
            return dTable;
        }
        public bool Update_ReservationInformationBLL(Customer aCustomer, Record aRecord, Cost aCost)
        {
            if (aCustomer .Id==0)
            {
                return false;
            }
            else
            {
                ReservationDAL aReservationDAL = new ReservationDAL();
                bool Result = aReservationDAL.Update_ReservationInformationDAL(aCustomer ,aRecord ,aCost);
                if (Result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public DataTable BookingUpdate_ConfirmationBLL(Customer aCustomer)
        {
            ReservationDAL aReservation = new ReservationDAL();
            DataTable dTable = aReservation.BookingUpdate_ConfirmationDAL(aCustomer);
            return dTable;
        }
        public bool CancelReservationBLL(Customer aCustomer)
        {
            if (aCustomer .Id ==0)
            {
                return false;
            }
            else
            {
                ReservationDAL aReservation = new ReservationDAL();
                bool Result = aReservation.CancelReservationDAL(aCustomer);
                return Result;
            }
        }
        public DataTable BookingCancel_ConfirmationBLL(Customer aCustomer)
        {
            ReservationDAL aReservation = new ReservationDAL();
            DataTable dTable = aReservation.BookingCancel_ConfirmationDAL(aCustomer);
            return dTable;
        }
        public DataTable TotalCost_CalculateDAL(int Days, Room aRoom)
        {
            DataTable dTAble;
            if (aRoom.Id ==0)
            {
                dTAble = null;
                return dTAble;

            }
            else
            {
                ReservationDAL aReservation = new ReservationDAL();
                dTAble = aReservation.TotalCost_CalculateDAL(Days,aRoom);
                return dTAble;
            }

        }
        public bool RoomBooking_avilityBLL(Record aRecord)
        {
            if (aRecord .RoomNO =="" || aRecord.CheckInDate ==""|| aRecord .CheckOutDate =="")
            {
                return false;
            }
            else
            {
                ReservationDAL aReservationDAL = new ReservationDAL();
                bool Result = aReservationDAL.RoomBooking_avilityDAL(aRecord);
                if (Result)
                {
                    return Result;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
