using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _30_NgoThiThuyLinh_Buoi08
{
    public class ConnectDB
    {
        public SqlConnection connect;
        public ConnectDB()
        {
            connect = new SqlConnection("Data Source =ADMIN\\SQLEXPRESS; Initial Catalog= Test_Net; Integrated Security = true");
        }
        public ConnectDB(string strcn)
        {
            connect = new SqlConnection(strcn);
        }
    }
}
