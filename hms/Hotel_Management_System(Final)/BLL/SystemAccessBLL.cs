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
    class SystemAccessBLL
    {
        public bool Save_new_AccessBLL(SystemAccess aSystemAccess)
        {
            if (aSystemAccess.Username == "" || aSystemAccess.Password == "")
            {
                return false;
            }
            else {
                SystemAccessDAL aSystemAccessDAL = new SystemAccessDAL();
                bool Result = aSystemAccessDAL.Save_new_AccessDAL(aSystemAccess);
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

        public DataTable View_Existing_UserAccessBLL(SystemAccess aSystemAccess)
        {
            SystemAccessDAL aSystemAccessDAL = new SystemAccessDAL();
            DataTable dTable = aSystemAccessDAL.View_Existing_UserAccessDAL(aSystemAccess);
            return dTable;
        }
        public bool Update_UserAccess_BLL(SystemAccess aSystemAccess)
        {
            SystemAccessDAL aSystemAccessDAL = new SystemAccessDAL();
            bool Result = aSystemAccessDAL.Update_UserAccess_DAL(aSystemAccess);
            if (Result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete_UserAccessBLL(SystemAccess aSystemAccess)
        {
            SystemAccessDAL aSystemAccessDAL = new SystemAccessDAL();
            bool Result = aSystemAccessDAL.Delete_UserAccessDAL(aSystemAccess);
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
}
