using LockWarden.DataAccess.Interfaces;
using LockWarden.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class CreateDatabase
{
    ITableCreate tableCreate = new TableCreate();
    public void DatabaseCreate()
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        string dirpath = path + "\\Lock Warden";
        string filepath = dirpath + "\\lock-warden.db";
        if (!(new FileInfo(filepath).Exists))
        {
            Directory.CreateDirectory(dirpath);
            File.WriteAllText(filepath,"");
            tableCreate.CreateTableAsync();
            Console.WriteLine(dirpath);
        }
    }
}

