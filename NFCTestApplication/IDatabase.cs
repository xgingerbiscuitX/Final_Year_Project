using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFCTestApplication
{
  public  interface IDatabase
    {
        void openConnection();
        void closeConnection();
        System.Data.SqlClient.SqlConnection getConnection();
        void saveUID(string getUID, string getTType);
    }
}
