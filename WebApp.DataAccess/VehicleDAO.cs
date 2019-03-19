using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class VehicleDAO
    {
        public static int addNewVehicle(int vehicleID, string model, bool available, string economy, decimal price_pd, string brand, string tier, int production_year, int size, string color, string type, int office_id, string img)
        {
            //Add new vehicle with given specs. Error checking will be done with try-catch-finally blocks.
            SqlCommand com = new SqlCommand("InsertVehicle", Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            //Add parameters as attributes to vehicle
            com.Parameters.AddWithValue("@VehicleID", vehicleID);
            com.Parameters.AddWithValue("@Model", model);
            com.Parameters.AddWithValue("@Available", available ? 1:0);
            com.Parameters.AddWithValue("@Economy", economy);
            com.Parameters.AddWithValue("@Price_pd", price_pd);
            com.Parameters.AddWithValue("@Brand", brand);
            com.Parameters.AddWithValue("@Tier", tier);
            com.Parameters.AddWithValue("@Production_Year", production_year);
            com.Parameters.AddWithValue("@Size", size);
            com.Parameters.AddWithValue("@Color", color);
            com.Parameters.AddWithValue("@Type", type);
            com.Parameters.AddWithValue("@Office_ID", office_id);
            com.Parameters.AddWithValue("@ImageSrc", img);
            //If connection is closed, open connection
            if(com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = 0;
            try
            {
                result = com.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                result = -1;
            }
            com.Dispose();
            com.Connection.Close();
            return result;

        }
        /**
         * This function sets the availability bit on Vehicle to given value
         * @Param: vehicleID -> Given id is going to be updated.
         * @Param: rented -> True/False value. True means car is rented, which represents as available 0 on table
         * and vice versa 
         */
        public static int updateRentStatus(int vehicleID, bool rented)
        {
            SqlCommand com = new SqlCommand("SetAvailability", Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Availability", rented ? 0:1);
            com.Parameters.AddWithValue("@VehicleId", vehicleID);
            //Open the connection if connection is closed 
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static VehicleEntity getVehicleById(int vehicleID)
        {
            VehicleEntity result = null;
            string sqlCommand = "SelectAllVehiclesByVehicleId";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@VehicleID", vehicleID);
            //Open connection if closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            //If there is a vehicle exist in the given
            if (read.HasRows)
            {
                read.Read();
                result = new VehicleEntity
                {
                    VehicleID = Convert.ToInt32(read["vehicleID"].ToString()),
                    model = read["model"].ToString(),
                    available = read["available"].ToString().Equals("1"),
                    economy = read["economy"].ToString(),
                    price_pd = read["price_pd"].ToString(),
                    brand = read["brand"].ToString(),
                    tier = read["tier"].ToString(),
                    production_year = Convert.ToInt32(read["production_year"].ToString()),
                    size = Convert.ToInt32(read["size"].ToString()),
                    color = read["color"].ToString(),
                    type = read["type"].ToString(),
                    officeId = Convert.ToInt32(read["office_Id"].ToString()),
                    img_src = read["image_src"].ToString(),
                    officeName = read["Office Name"].ToString()     
                };
            }
            //Close reader
            read.Close();
            //Drop command and close connection
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        /**
         * This querry is runned when customer selects a car right before rent is registered into database.
         * Called procedure selects all the vehicles that are both available and owned by the given office id.
         */
        public static List<VehicleEntity> getVehicleByOfficeID(int officeID, string attribute)
        {
            List<VehicleEntity> list = null;
            string sqlCommand;
            if (attribute.Equals(String.Empty))
            {
                sqlCommand = String.Format("SELECT Vehicle.*, Office.name AS [Office Name] FROM Vehicle INNER JOIN Office ON Vehicle.office_Id = Office.officeID WHERE Vehicle.office_Id={0} AND available=1", officeID);
            }
            else
            {
                sqlCommand = String.Format("SELECT Vehicle.*, Office.name AS [Office Name] FROM Vehicle INNER JOIN Office ON Vehicle.office_Id = Office.officeID WHERE Vehicle.office_Id={0} AND available=1 ORDER BY {1}", officeID, attribute);
            }
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //Open connection if closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            //If there is a vehicle exist in the given
            if (read.HasRows)
            {
                list = new List<VehicleEntity>();
                while (read.Read())
                {
                    list.Add(new VehicleEntity
                    {
                        VehicleID = Convert.ToInt32(read["vehicleID"].ToString()),
                        model = read["model"].ToString(),
                        available = read["available"].ToString().Equals("1"),
                        economy = read["economy"].ToString(),
                        price_pd = read["price_pd"].ToString(),
                        brand = read["brand"].ToString(),
                        tier = read["tier"].ToString(),
                        production_year = Convert.ToInt32(read["production_year"].ToString()),
                        size = Convert.ToInt32(read["size"].ToString()),
                        color = read["color"].ToString(),
                        type = read["type"].ToString(),
                        officeId = Convert.ToInt32(read["office_Id"].ToString()),
                        img_src = read["image_src"].ToString(),
                        officeName = read["Office Name"].ToString()
                    });
                }              
            }
            //Close reader
            read.Close();
            //Drop command and close connection
            com.Dispose();
            com.Connection.Close();
            return list;
        }
        public static List<VehicleEntity> getAllVehicles(string attribute)
        {
            List<VehicleEntity> list = null;
            string sqlCommand;
            if (attribute.Equals(String.Empty))
            {
                sqlCommand = "SELECT Vehicle.*, Office.name AS [Office Name] FROM Vehicle INNER JOIN Office ON Vehicle.office_Id = Office.officeID";
            }
            else
            {
                sqlCommand = "SELECT Vehicle.*, Office.name AS [Office Name] FROM Vehicle INNER JOIN Office ON Vehicle.office_Id = Office.officeID ORDER BY " + attribute + " ASC";
            }

            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //Open connection if closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            //If there is a vehicle exist in the given
            if (read.HasRows)
            {
                list = new List<VehicleEntity>();
                while (read.Read())
                {
                    list.Add(new VehicleEntity
                    {
                        VehicleID = Convert.ToInt32(read["vehicleID"].ToString()),
                        model = read["model"].ToString(),
                        available = read["available"].ToString().Equals("1"),
                        economy = read["economy"].ToString(),
                        price_pd = read["price_pd"].ToString(),
                        brand = read["brand"].ToString(),
                        tier = read["tier"].ToString(),
                        production_year = Convert.ToInt32(read["production_year"].ToString()),
                        size = Convert.ToInt32(read["size"].ToString()),
                        color = read["color"].ToString(),
                        type = read["type"].ToString(),
                        officeId = Convert.ToInt32(read["office_Id"].ToString()),
                        img_src = read["image_src"].ToString(),
                        officeName = read["Office Name"].ToString()
                    });
                }
            }
            //Close reader
            read.Close();
            //Drop command and close connection
            com.Dispose();
            com.Connection.Close();
            return list;
        }
        public static int deleteVehicle(int vehicleId)
        {
            string sqlCommand = "DELETE FROM Vehicle WHERE vehicleID=" + vehicleId;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //Open the connection if connection is closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            //Return value is the number of rows affected by the querry executed.
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int updateVehicle(int vehicleId, string attributeName, object newData)
        {
            string sqlCommand = "";
            //If data is numeric, insertion should be done without ' character. Else, use ' character to insert data
            if (newData is int || newData is decimal)
                sqlCommand = "UPDATE Vehicle SET " + attributeName + "=" + newData + " WHERE vehicleID = " + vehicleId;
            else
                sqlCommand = "UPDATE Vehicle SET " + attributeName + "='" + newData + "' WHERE vehicleID = " + vehicleId;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //Open the connection if connection is closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = 0;
            try
            {
                //Try to execute querry, if problem occurs it will be down to catch block
                result = com.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                result = -1;
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        
    }
}
