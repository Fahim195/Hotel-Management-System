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
    class SignInBLL
    {
        public bool Check_UserID_and_PasswordBLL(SystemAccess aSystemAccess)
        {
            bool res=false ;
            int ab = 0;
            if (aSystemAccess .Username =="" || aSystemAccess .Password =="" || aSystemAccess.Username == "User Name" || aSystemAccess.Password == "Password")
            {
                
                return res;
            }
            else
            {
                SignInDAL aSignInDAL = new SignInDAL();
                DataTable dTable = aSignInDAL.Check_UserID_and_PasswordDAL(aSystemAccess);
                
                try {
                    
                    ab =int.Parse(dTable.Rows[0][0].ToString());
                    if (ab != 0)
                    {
                        res = true;

                    }
                }
                catch {
                     res = false;
                }

                return res;
            }  
        }
        public bool Check_AccessID_and_PasswordBLKL(SystemAccess aSystemAccess)
        {
            bool res = false;
            int ab = 0;
            if (aSystemAccess.Username == "" || aSystemAccess.Password == "" || aSystemAccess.Username == "User Name" || aSystemAccess.Password == "Password")
            {

                return res;
            }
            else
            {
                SignInDAL aSignInDAL = new SignInDAL();
                DataTable dTable = aSignInDAL.Check_AccessID_and_PasswordDAL(aSystemAccess);

                try
                {

                    ab = int.Parse(dTable.Rows[0][0].ToString());
                    if (ab != 0)
                    {
                        res = true;

                    }
                }
                catch
                {
                    res = false;
                }

                return res;
            }
        }

     }
}
