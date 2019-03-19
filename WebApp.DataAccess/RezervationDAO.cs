using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class RezervationDAO
    {
        //Logged in customer will be known and customerId can be read by that. 
        public static int reserve(int customerId, DateTime resDate, string cardInfo)
        {
            string sqlCommand = String.Format("INSERT INTO Rezervation(rezervation_id,customer_id,card_number,reservation_date) VALUES({0},{1},'{2}','{3}')",
                                     Counters.getReservationCount(), customerId, cardInfo, resDate.ToString("yyyy-MM-dd"));
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //Open connection if connection is closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = 0;
            try
            {
                result = com.ExecuteNonQuery();
            }
            catch
            {
                result = 0;
            }
            if(result != 0)
            {
                Counters.incrementReservationCount();
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int getLatestReservation()
        {
            return getMaxResId();
        }
        public static List<RezervationEntitiy> getAllReservations()
        {
            List<RezervationEntitiy> list = null;
            string sqlCommand = "SELECT * FROM Rezervation";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if(com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<RezervationEntitiy>();
                while (read.Read())
                {
                    list.Add(new RezervationEntitiy
                    {
                        rezervation_date = Convert.ToDateTime(read["rezervation_date"].ToString()),
                        rezervationId = Convert.ToInt32(read["rezervation_id"].ToString()),
                        cardNumber = read["card_number"].ToString(),
                        customerId = Convert.ToInt32(read["customer_id"].ToString())

                    });
                }
            }
            com.Dispose();
            com.Connection.Close();
            return list;
        }
        //Remove reservation, if needed. 
        public static int deleteRezervation(int resId)
        {
            string sqlCommand = "DELETE FROM Rezervation WHERE rezervation_id=" + resId;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if(com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        //Only delete rezervations older than specifed amount of time.
        public static int deleteReservationsOlderThan(DateTime date)
        {
            string sqlCommand = "DELETE FROM Rezervation WHERE reservation_date <'" + date.ToString("yyyy-MM-dd") + "'";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int getMaxResId()
        {
            string sqlCommand = "SELECT MAX(rezervation_id) AS r FROM Rezervation";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            int result = 0;
            if (read.HasRows)
            {
                read.Read();
                try
                {
                    result = Convert.ToInt32(read["r"].ToString());
                }
                catch(Exception e)
                {
                    result = 0;
                }
            }
            com.Dispose();
            com.CommandText.Clone();
            return result;
        }      
    }
}
