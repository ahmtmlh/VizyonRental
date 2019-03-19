using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class OfficeDAO
    {
        public static List<OfficeEntity> getAllOffices()
        {
            List<OfficeEntity> list = null;
            string sqlCommand = "SelectAllOffices";
            SqlCommand com = new SqlCommand(sqlCommand , Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            //Open the connection if connection is closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<OfficeEntity>();
                while (read.Read())
                {
                    list.Add(new OfficeEntity
                    {
                        OfficeId = Convert.ToInt32(read["officeID"].ToString()),
                        address = read["address"].ToString(),
                        name = read["name"].ToString(),
                        Vehicle_Count = Convert.ToInt32(read["Vehicle Count"].ToString())
                    });
                }
            }
            //Dispose the command and close the connection.
            com.Dispose();
            com.Connection.Close();

            return list;
        }
        public static int getOfficeIdByName(string office_name)
        {
            string sqlCommand = "SELECT officeID FROM Office WHERE name='" +office_name + "'";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            //Open the connection if connection is closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            int result = -1;
            if (read.HasRows)
            {
                read.Read();
                result = Convert.ToInt32(read["officeID"].ToString());
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static OfficeEntity getOfficeById(int officeId)
        {
            OfficeEntity result = null;
            string sqlCommand = "SelectOfficeById";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OfficeID", officeId);
            //Open the connection if connection is closed
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                result = new OfficeEntity
                {
                    OfficeId = Convert.ToInt32(read["officeID"].ToString()),
                    address = read["address"].ToString(),
                    name = read["name"].ToString(),
                    Vehicle_Count = Convert.ToInt32(read["Vehicle Count"].ToString())
                };
            }
            //Dispose the command and close the connection.
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int addOffice(int officeID, string name, string address)
        {
            SqlCommand com = new SqlCommand("AddOffice", Connections.Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OfficeID", officeID);
            com.Parameters.AddWithValue("@Name", name);
            com.Parameters.AddWithValue("@Address", address);
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
                result = -1;
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int update(int officeID, string attrName, string newData)
        {
            string sqlCommand = String.Format("UPDATE Office SET {0}='{1}' WHERE officeID={2}" , attrName,newData,officeID);
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
        public static int deleteOffice(int officeId)
        {
            string sqlCommand = String.Format("DELETE FROM Office WHERE officeID={0} AND (SELECT COUNT(office_Id) FROM Vehicle WHERE office_Id=Office.officeID)=0", officeId);
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
        public static int getMaxOfficeId()
        {
            //Find the max customer id from the Customer table to use in web application.
            string sqlCommand = "SELECT MAX(officeID) AS o FROM Office";
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
                if (!read["o"].ToString().Equals(""))
                {
                    result = Convert.ToInt32(read["o"].ToString());
                }
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
    }
}
