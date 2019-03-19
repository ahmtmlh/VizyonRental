using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class BillDAO
    {
        public static List<BillEntity> getAllBills()
        {
            List<BillEntity> list = null;
            string sqlCommand = "SELECT * FROM Bill";

            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<BillEntity>();
                while (read.Read())
                {
                    list.Add(new BillEntity
                    {
                        bill_ID = Convert.ToInt32(read["bill_ID"].ToString()),
                        reservation_ID = Convert.ToInt32(read["reservation_ID"].ToString())
                    });
                }
            }
            //Dispose the command and close the connection.
            com.Dispose();
            com.Connection.Close();

            return list;
        }

        public static BillEntity getBillById(int bill_ID)
        {
            BillEntity result = null;
            string sqlCommand = "SELECT * FROM Bill WHERE bill_ID=" + bill_ID;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //Open the connection if connection is closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                result = new BillEntity
                {
                    bill_ID = Convert.ToInt32(read["bill_ID"].ToString()),
                    reservation_ID = Convert.ToInt32(read["reservation_ID"].ToString())
                };
            }
            //Dispose the command and close the connection.
            com.Dispose();
            com.Connection.Close();
            return result;
        }

        public static int deleteBill(int bill_ID)
        {
            string sqlCommand = "DELETE FROM Bill WHERE bill_ID=" + bill_ID;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //If connection is closed, open the connection.
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        

    }
}
