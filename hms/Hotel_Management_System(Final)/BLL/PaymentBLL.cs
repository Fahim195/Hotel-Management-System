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
    class PaymentBLL
    {
        public bool Confirm_PaymentBLL(Customer aCustomer, Record aRecord, Cost aCost)
        {
            if (aCustomer.Name == "" || aCustomer.Age < 18 || aCustomer.Sex == "" || aCustomer.DOB == "" || aCustomer.Profession == "" || aCustomer.ProfessionAddress == "" || aCustomer.PresentAddress == "" || aCustomer.PermanentAddress == "" || aCustomer.ContactNo == "" || aCustomer.Email == "" || aCustomer.NIDorPassportNo == "" || aRecord.RoomID == 0 || aRecord.RoomNO == "" || aRecord.BookingDate == "" || aRecord.CheckInDate == "" || aRecord.CheckOutDate == "" || aRecord.PaymentStatus == "" || aCost.TotalCost == 0 || aCost.Due == 0)
            {
                return false;
            }
            else
            {
                PaymentDAL aPaymentDAL = new PaymentDAL(); 
                bool Result = aPaymentDAL .Confirm_PaymentDAL(aCustomer, aRecord, aCost);
                return Result;
            }
        }
        public DataTable ViewPayment_InformationIn_textboxBLL(Customer aCustomer)
        {
            PaymentDAL aPaymentDAL = new PaymentDAL();
            DataTable dTable = aPaymentDAL.ViewPayment_InformationIn_textboxDAL(aCustomer);
            return dTable;
        }
        public DataTable Payment_ConfirmationBLL(Customer aCustomer)
        {
            PaymentDAL aPaymentDAL = new PaymentDAL();
            DataTable dTable = aPaymentDAL.Payment_ConfirmationDAL(aCustomer);
            return dTable;
        }
        public bool Payment_Cancel(int ReservationID, Cost aCost)
        {
            PaymentDAL aPaymentDAL = new PaymentDAL();
            bool res = aPaymentDAL.Cancel_PaymentDAL(ReservationID, aCost);
            return res;
        }
        public DataTable Get_CustomerDetails_For_DiscountBLL(Cost aCost)
        { DataTable dTable = null;
            if (aCost .Id ==0)
            {
                return dTable;
            }
            else
            {
                PaymentDAL aPaymentDAL = new PaymentDAL();
                dTable = aPaymentDAL.Get_CustomerDetails_For_DiscountDAL(aCost);
                return dTable;
            }
            
        }
        public bool Save_Customer_DiscountBLL(Cost aCost)
        {
            if (aCost.TotalCost == 0 || aCost.Due == 0 || aCost .Discount ==0 )
            {
                return false;
            }
            else
            {
                PaymentDAL aPaymentDAL = new PaymentDAL();
                bool Result = aPaymentDAL.Save_Customer_DiscountDAL(aCost);
                return Result;
            }
        }
        public bool Cancel_Customer_DiscountBLL(Cost aCost)
        {

            if (aCost.TotalCost == 0 || aCost.Due == 0 || aCost.Discount == 0)
            {
                return false;
            }
            else
            {
                PaymentDAL aPaymentDAL = new PaymentDAL();
                bool Result = aPaymentDAL.Cancel_Customer_DiscountDAL(aCost);
                return Result;
            }
        }


        }

}
