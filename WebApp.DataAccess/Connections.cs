using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    class Connections
    {
        //Sql connection string to current database
        public static readonly SqlConnection Con = new SqlConnection("server=AHMETMELIH-PC;database=CarRental;Trusted_Connection=true;MultipleActiveResultSets=True;");
    }
}
