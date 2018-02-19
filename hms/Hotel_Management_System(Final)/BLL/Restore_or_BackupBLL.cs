using Hotel_Management_System_Final_.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System_Final_.BLL
{
    class Restore_or_BackupBLL
    {
        public SqlDataReader DatabasesToComboboxBLL()
        {
            Restore_or_BackupDAL arestoreDAL = new Restore_or_BackupDAL();
            SqlDataReader reader = arestoreDAL.DatabasesToComboboxDAL();
            return reader;
        }
        public bool BackupDatabaseBLL(string database, string dataBase_Path)

        {
            Restore_or_BackupDAL arestoreDAL = new Restore_or_BackupDAL();
            bool res = arestoreDAL.BackupDatabaseDAL(database, dataBase_Path);
            if (res)
            {
                return res;
            }
            else
            {
                return res;
            }

        }

            public bool RestoreDatbaseBLL(string database, string dataBase_Path)
        {
            Restore_or_BackupDAL arestoreDAL = new Restore_or_BackupDAL();
            bool res = arestoreDAL.RestoreDatabaseDAL(database, dataBase_Path);
            return res;
        }
    }
}
