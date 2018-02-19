using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Final_.DAL
{
    class RecordBLL
    {
        public DataTable ViewSpecificRecordinGridview(int CheckIn,int CheckOut,string DateForSpecificRecordView)
        {

            if (CheckIn ==0 && CheckOut ==0)
            {
                DataTable dTable = null;
                return dTable;
            }
           else
            {
                RecordDAL aRecordDAL = new RecordDAL();
                DataTable dTable = aRecordDAL.ViewSpecificRecordView(CheckIn,CheckOut, DateForSpecificRecordView);
                return dTable;
            }
        }
        public DataTable ViewRecord_OfSpecific_TimePeriod(string DateforTimePerod_RecodView,int CheckIn,int CheckOut,string ComboboxText)
        {
           
            if (CheckIn == 0 && CheckOut == 0 || ComboboxText =="")
            {
                DataTable dTable = null;
                return dTable;
            }
            else
            {
                RecordDAL aRecordDAL = new RecordDAL();
                DataTable dTable = aRecordDAL.ViewRecordINGridview(DateforTimePerod_RecodView, CheckIn, CheckOut, ComboboxText);
                return dTable;
            }
        }
        public int Reservation_validityCheckBLL(string TodaysDate)
        {
            RecordDAL aRecordDAL = new RecordDAL();
            int No_ofReservationExpired = aRecordDAL.Reservation_validityCheckDAL(TodaysDate);
            return No_ofReservationExpired;
        }
        public int No_of_Reservation_Expired_BLL(string TodaysDate)
        {
            RecordDAL ArECORDdAL = new RecordDAL();
            int nUMBER = ArECORDdAL.No_of_Reservation_Expired(TodaysDate);
            return nUMBER;
        }
        public DataTable ReservationExired_List_BLL(string TodaysDate)
        {
            RecordDAL ArECORDdAL = new RecordDAL();
            DataTable dTable= ArECORDdAL.ReservationExired_List_DAL(TodaysDate);
            return dTable;
        }
        }
}
