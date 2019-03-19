using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class LoginDAO
    {
        public static LoginEntity login(string username, string password)
        {
            LoginEntity result = null;
            string sqlCommand = "SELECT * FROM Login WHERE username = '" + username + "' AND password = '" + password + "'";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if(com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                read.Read();
                result = new LoginEntity
                {
                    LoginId = Convert.ToInt32(read["login_ID"]),
                    Username = read["username"].ToString(),
                    Password = read["password"].ToString(),
                    Type = read["type"].ToString().Equals("1") ? true : false
                };
            }
            //Close connection and return value. If not found, return null;
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static bool hasUser(string username)
        {
            bool result = false;
            string sqlCommand = "SELECT * FROM Login WHERE username='" + username + "'";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if(com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            //If the given username does contained by the login table, no other entry should be allowed inside the table with
            //the same username
            SqlDataReader read = com.ExecuteReader();
            result = read.HasRows;
            read.Close();
            //Close the connection.
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int signUp_cust(string username, string password)
        {
            //login_ID is determined as 'counter-1', since the increment operation is done at customer insertion.
            //Type = 0 -> Customer
            string sqlCommand = String.Format("INSERT INTO Login(username ,login_ID, password,type) VALUES('{0}',{1},'{2}',{3})", username, Counters.getCustCount() - 1, password , 0);
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if(com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            //No error checking is required, all controls has been done before this point.
            int result = com.ExecuteNonQuery();
            com.Dispose();
            com.Connection.Close();
            return result;
        }
    }
}
