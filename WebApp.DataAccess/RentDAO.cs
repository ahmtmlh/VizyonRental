using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class RentDAO
    {
        public static List<RentEntity> getAllRents()
        {
            List<RentEntity> list = null;
            string sqlCommand = "SELECT * FROM Rent";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //If connection is closed, open conection
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<RentEntity>();
                while (read.Read())
                {
                    list.Add(new RentEntity
                    {
                        rentId = Convert.ToInt32(read["rent_id"].ToString()),
                        customerId = Convert.ToInt32(read["cust_id"].ToString()),
                        vehicleId = Convert.ToInt32(read["vehicle_id"].ToString()),
                        receive_office = Convert.ToInt32(read["receive_office"].ToString()),
                        delivery_office = Convert.ToInt32(read["delivery_office"].ToString()),
                        deliveryDate = Convert.ToDateTime(read["delivery_date"].ToString()),
                        receiveDate = Convert.ToDateTime(read["receive_date"].ToString()),
                        price = Convert.ToDecimal(read["price"].ToString())
                    });
                }
            }
            com.Dispose();
            com.Connection.Close();
            return list;
        }
        public static List<RentEntity> getRentsByField(string attributeName, object data)
        {
            List<RentEntity> list = null;
            string sqlCommand = "";
            if(data is int || data is decimal)
            {
                sqlCommand = "SELECT * FROM Rent WHERE" + attributeName + "=" + data;
            }
            else
            {
                sqlCommand = "SELECT * FROM Rent WHERE" + attributeName + "='" + data + "'";
            }
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //If connection is closed, open conection
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<RentEntity>();
                while (read.Read())
                {
                    list.Add(new RentEntity
                    {
                        rentId = Convert.ToInt32(read["rent_id"].ToString()),
                        customerId = Convert.ToInt32(read["cust_id"].ToString()),
                        vehicleId = Convert.ToInt32(read["vehicle_id"].ToString()),
                        receive_office = Convert.ToInt32(read["receive_office"].ToString()),
                        delivery_office = Convert.ToInt32(read["delivery_office"].ToString()),
                        deliveryDate = Convert.ToDateTime(read["delivery_date"].ToString()),
                        receiveDate = Convert.ToDateTime(read["receive_date"].ToString()),
                        price = Convert.ToDecimal(read["price"].ToString())
                    });
                }
            }
            com.Dispose();
            com.Connection.Close();
            return list;
        }
        public static int deleteRentById(int rent_id)
        {
            string sqlCommand = "DELETE Rent WHERE rent_id =" +rent_id;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //If connection is closed, open connection
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int addRent(int reservation, int delivery_office, int receive_office, int vehicle, int customer, DateTime receiveDate, DateTime deliveryDate, decimal price)
        {
            //A reservation must exist before this operations happens
            SqlCommand com = new SqlCommand("InsertRent", Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RentID", reservation);
            com.Parameters.AddWithValue("@CustomerID", customer);
            com.Parameters.AddWithValue("@VehicleID", vehicle);
            com.Parameters.AddWithValue("@ReceiveOffice", receive_office);
            com.Parameters.AddWithValue("@DeliveryOffice", delivery_office);
            com.Parameters.AddWithValue("@ReceiveDate", receiveDate.ToString("yyyy-MM-dd"));
            com.Parameters.AddWithValue("@DeliveryDate", deliveryDate.ToString("yyyy-MM-dd"));
            com.Parameters.AddWithValue("@Price", price);
            //If connection is closed, open connection
            if(com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        
        public static int endRents()
        {
            SqlCommand com = new SqlCommand("EndRent", Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DateNow", DateTime.Now.ToString("yyyy-MM-dd"));
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        
        //Add more functions on demand
    }
}
