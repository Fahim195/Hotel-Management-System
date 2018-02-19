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
    class SearchBLL
    { 
        public DataTable SearchResultBLL(Customer aCustomer, Record aRecord, Room aRoom)
        {
            DataTable dTable = null;
            if (aCustomer .Id ==0 && aCustomer .Name =="" && aCustomer .Age ==0 && aCustomer.ProfessionAddress ==""&& aCustomer .PresentAddress =="" && aCustomer .PermanentAddress =="" && aCustomer .ContactNo =="" && aCustomer .Email =="" && aCustomer .NIDorPassportNo =="" && aRoom .Floor =="" && aRecord .RoomNO =="" && aRecord .BookingDate =="" && aRecord .CheckInDate =="" && aRecord .CheckOutDate ==""&& aRecord.BookingDate == "yyyy-MM-dd" && aRecord.CheckInDate == "yyyy-MM-dd" && aRecord.CheckOutDate == "yyyy-MM-dd")
            {
                return dTable;
            }
            else
            {
                SearchDAL aSearchDDAL = new SearchDAL();
                dTable = aSearchDDAL.SearchResultDAL(aCustomer,aRecord ,aRoom);
                return dTable;
            } 
        }
    }
}
