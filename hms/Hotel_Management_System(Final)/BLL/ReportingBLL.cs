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
    class ReportingBLL
    {
        public DataTable Customer_Billing_SlipBLL(Customer aCustomer,string ReportType)
        {

                ReportingDAL aReportingDAL = new ReportingDAL();
                DataTable  dTable= aReportingDAL.Customer_Billing_SlipDAL(aCustomer);
                return dTable;

        }
        public DataTable Specific_Customer_DetailsBLL(Customer aCustomer, string ReportType)
        {
            ReportingDAL aReportingDAL = new ReportingDAL();
            DataTable dTable = aReportingDAL.Specific_Customer_DetailsDAL(aCustomer);
            return dTable;
        }
        public DataTable AllRoomDetaisBLL()
        {
            ReportingDAL aReportingDAL = new ReportingDAL();
            DataTable dTable = aReportingDAL.AllRoomDetaisDAL();
            return dTable;
        }
        public DataTable Current_week_reportBLL(string TodayDate)
        {
            ReportingDAL aReportingDAL = new ReportingDAL();
            DataTable dTable = aReportingDAL.Current_week_reportDAL(TodayDate);
            return dTable;
        }
        public DataTable Current_Month_reportBLL(string TodayDate)
        {
            ReportingDAL aReportingDAL = new ReportingDAL();
            DataTable dTable = aReportingDAL.Current_Month_reportDAL(TodayDate);
            return dTable;
        }
        public DataTable Last_15Days_reportBLL(string TodayDate)
        {
            ReportingDAL aReportingDAL = new ReportingDAL();
            DataTable dTable = aReportingDAL.Current_Month_reportDAL(TodayDate);
            return dTable;
        }
    }
}
