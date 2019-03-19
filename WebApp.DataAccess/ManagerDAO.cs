using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class ManagerDAO
    {
        public static List<ManagerEntity> getAllManagers()
        {
            List<ManagerEntity> list = null;
            string sqlCommand = "SELECT * FROM Manager";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                list = new List<ManagerEntity>();
                while (read.Read())
                {
                    list.Add(new ManagerEntity
                    {
                        ManagerId = Convert.ToInt32(read["managerID"]),
                        ManagerName = read["name"].ToString(),
                        ManagerSurname = read["surname"].ToString(),
                        ManagerAddress = read["address"].ToString(),
                        ManagerBirthDate = Convert.ToDateTime(read["birthDate"]),
                        ManagerMail = read["mail"].ToString(),
                        ManagerPhone = read["phone_number"].ToString()
                    });
                }
            }
            com.Dispose();
            com.Connection.Close();
            return list;
        }
        public static ManagerEntity getManagerById(int id)
        {
            ManagerEntity result = null;
            string sqlCommand = "SELECT * FROM Manager WHERE managerID = " + id;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                read.Read();
                result = new ManagerEntity
                {
                    ManagerId = Convert.ToInt32(read["managerID"]),
                    ManagerName = read["name"].ToString(),
                    ManagerSurname = read["surname"].ToString(),
                    ManagerAddress = read["address"].ToString(),
                    ManagerBirthDate = Convert.ToDateTime(read["birthDate"]),
                    ManagerMail = read["mail"].ToString(),
                    ManagerPhone = read["phone_number"].ToString()
                };
            }
            //Close connection and return result.
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        /*
         * Update manager if manager is found. 'attrName' that comes as parameter is the correct
         * attribute name in the table at this point. Error checking is done before this stage.
         */
        public static int updateManager(int managerId, string attrName, string newData)
        {
            string sqlCommand = "UPDATE Manager SET " + attrName + "='" + newData + "' WHERE managerID =" + managerId;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = 0;
            //Try to update data. If fails, return -1 so UI can show error message
            try
            {
                result = com.ExecuteNonQuery();
            }
            catch(Exception e)
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
        /**
         * Check username from the login table before adding the manager in the Manager table. If there is no problem adding
         * add manager to the manager table and username-password to login table.
         */
        public static int addManager(string username, string password, string name, string surname, DateTime bDate, string address, string phone, string mail)
        {
            //Username is presented in the table
            if (LoginDAO.hasUser(username))
            {
                return -1;
            }
            string sqlCommand = String.Format("INSERT INTO Manager(managerID, name, surname, birthDate, address, phone_number, mail) VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                                              Counters.getMngrCount(), name, surname, bDate.ToString("yyyy-MM-dd"), address, phone, mail);
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
                com.Dispose();
                com.Connection.Close();
                if(result != -1)
                {
                    result = addManagerToLogin(username, password);
                    if (result > 0)
                    {
                        Counters.incrementMngrCount();
                    }
                    else
                    {
                        deleteManager(Counters.getMngrCount());
                    }
                    /*
                    //Insertion is successful. Insert to login table
                    int login_res = addManagerLogin(Counters.getMngrCount(), username, password);
                    if(login_res == -1)
                    {
                        //Username already exist. Delete previously inserted manager from the table.
                        deleteManager(Counters.getMngrCount());
                    }
                    else
                    {
                        //Insertion to login table is successful. Increment counter.
                        Counters.incrementMngrCount();
                    }
                    */                    
                }
            }
            return result;
        }
        /**
         * When a manager is added to the Manager table, it must be added to Login table too.
         * Providing that checks are done, this function adds manager with its unique username and
         * password to the Login table. Declared as private since only managers can add new managers
         * to the system.
         * -----------------------------------------------------------------------------------------
         * This can be done in the LoginDAO class. However, inserting managers into 
         * login table must not be accessable by other classes since only existing managers can add 
         * new managers. This is done privately in the ManagerDAO class.
         */
        private static int addManagerToLogin(string username, string password)
        {
            string sqlCommand = String.Format("INSERT INTO Login(login_ID,username,password,type) VALUES({0},'{1}','{2}',{3})", (Counters.getMngrCount()), username, password, 1);
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
                com.Dispose();
                com.Connection.Close();
            }
            return result;
        }
        public static int deleteManager(int managerId)
        {
            string sqlCommand = "DELETE FROM Manager WHERE managerID = " + managerId;
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if (com.Connection.State == ConnectionState.Closed)
            {
                com.Connection.Open();
            }
            int result = com.ExecuteNonQuery();
            if(result != 0)
            {
                //Deletion was successful. Update manager id count in the program from
                //the table to keep track of manager id's better.
                Counters.updateMngrCount();
            }
            com.Dispose();
            com.Connection.Close();
            return result;
        }
        public static int getMaxManagerId()
        {
            string sqlCommand = "SELECT MAX(managerID) AS c FROM Manager";
            SqlCommand com = new SqlCommand(sqlCommand, Connections.Con);
            if(com.Connection.State == ConnectionState.Closed)
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
