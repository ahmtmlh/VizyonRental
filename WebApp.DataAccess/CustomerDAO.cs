using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class CustomerDAO
    {
        public static List<CustomerEntity> getAllCustomers()
        {
            string selectCustomers = "SELECT * FROM Customer";
            List <CustomerEntity> list = null;

            SqlCommand com = new SqlCommand(selectCustomers, Connections.Con);
            //If connection is closed, open the connection
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<CustomerEntity>();
                while (read.Read())
                {
                    list.Add(new CustomerEntity
                    {
                        CustomerId = Convert.ToInt32(read["customerID"]),
                        CustomerName = read["name"].ToString(),
                        CustomerSurname = read["surname"].ToString(),
                        CustomerAddress = read["address"].ToString(),
                        CustomerBirthDay = Convert.ToDateTime(read["birthDate"]),
                        CustomerMail = read["mail"].ToString(),
                        CustomerPhone = read["phone_number"].ToString()
                    });
                }
            }
            //Close current connection
            com.Dispose();
            com.Connection.Close();
            return list;
        }
        public static CustomerEntity getCustomerById(int id)
        {
            CustomerEntity result = null;
            string sqlCommand = "SELECT * FROM Customer WHERE customerID = " + id;
            Console.WriteLine(sqlCommand);
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            //If customer is found in the table
            if (read.HasRows)
            {
                read.Read();
                //Fill the CustomerEntity object from the table
                result = new CustomerEntity
                {
                    CustomerId = Convert.ToInt32(read["customerID"]),
                    CustomerName = read["name"].ToString(),
                    CustomerSurname = read["surname"].ToString(),
                    CustomerAddress = read["address"].ToString(),
                    CustomerBirthDay = Convert.ToDateTime(read["birthDate"]),
                    CustomerMail = read["mail"].ToString(),
                    CustomerPhone = read["phone_number"].ToString()
                };
            }
            //Close connection and return found value. If no value found, return null
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int updateCustomer(int customerId, string attrName, string newData)
        {
            string sqlCommand = "UPDATE Customer SET " + attrName + "='" + newData + "' WHERE customerID =" + customerId;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = 0;
            //Try to update data. If fails, return 0 so UI can show error message
            try
            {
                result = com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally
            {
                com.Dispose();
                com.Connection.Close();
            }
            return result;
        }
        /*
         * This function onyl adds customer entities to one Customer tables not Login table. Demo web page doesn't requeire a register
         * system as it doesn't get any username or passwords parameters.
         * 
         * As for the login table, this function will take username and passwords in later versions so that it can be added into login table.
         * NOT IMPLEMENTED AT THIS POINT
         */
        public static int addCustomer(string name, string surname, DateTime bDate, string address, string phone, string mail)
        {
            string sqlCommand = String.Format("INSERT INTO Customer(customerID, name, surname, birthDate, address, phone_number, mail) VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                           Counters.getCustCount(),name,surname,bDate.ToString("yyyy-MM-dd"),address, phone, mail);
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
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
            finally
            { 
                if(result != -1)
                {
                    //Insertion was successful. Instead of runnging a querry on database
                    //increment the customer counter.
                    Counters.incrementCustCount();
                }
                //Close connection

                com.Dispose();
                com.Connection.Close();
            }
            return result;
        }
        public static int deleteCustomer(int customerId)
        {
            string sqlCommand = "DELETE FROM Customer WHERE customerID = " + customerId;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            //No error handling is required in case of deletion. 
            int result = com.ExecuteNonQuery();
            if(result != 0)
            {
                //Deletion was successful. Find the maxiumum customer Id from the table and use that
                //as a reference point from now on.
                Counters.updateCustCount();
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int getMaxCustomerId()
        {
            //Find the max customer id from the Customer table to use in web application.
            string sqlCommand = "SELECT MAX(customerID) AS c FROM Customer";
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
                if (!read["c"].ToString().Equals(""))
                {
                    result = Convert.ToInt32(read["c"].ToString());
                }
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
    }
}
