using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.DataAccess.Constants
{
    public static class DB_Constants
    {

        static public string DB_Path_Directory = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Lock Warden";
        
        static public string DB_Path_File = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Lock Warden" + "\\lock-warden.db";
    }
}
