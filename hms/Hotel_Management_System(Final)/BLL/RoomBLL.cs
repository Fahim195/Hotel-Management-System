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
    class RoomBLL
    {
        public bool SaveRoomsBLL(Room aRoom)
        {
            if (aRoom .Floor =="" || aRoom .Type =="" || aRoom .Class =="" || aRoom .Rent ==0 )
            {
                return false;
            }
            else
            {
                RoomDAL aRoomDAL = new RoomDAL();
                bool result = aRoomDAL.SaveRoomsDAL(aRoom );
                if (result)
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
        }
        public DataTable ExistingRoomsBLL()
        {
            RoomDAL aRoomDAL = new RoomDAL();
            DataTable Dtable = aRoomDAL.ExistingRoomsDAL();
            return Dtable;
        }

        public bool UpdateRoomInfoLBL(Room aRoom)
        {
            RoomDAL aRoomDAL = new RoomDAL();
            bool result = aRoomDAL.UpdateRoomInfoDAL(aRoom);
            return result;
        }
        public DataTable PredictRoomIDBLL()
        {
            RoomDAL aRoomDAL = new RoomDAL();
            DataTable dTable = aRoomDAL.PredictRoomIDDAL();
            return dTable;
        }
        public bool DeleteRoomsDAL(Room aRoom)
        {
            if (aRoom .Id==0)
            {
                return false;
            }
            else
            {
                RoomDAL aRoomDAL = new RoomDAL();
                bool result= aRoomDAL.DeleteRoomsDAL(aRoom);
                if (result )
                {
                    return result;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
