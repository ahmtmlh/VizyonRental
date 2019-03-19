using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class Login
    {
        public static LoginEntity login(string username,string password)
        {
            LoginEntity user = LoginDAO.login(username, password);
            return user;
        }
        public static string signUp_Customer(string username, string password, string name, string surname, DateTime bDate, string address, string phone, string mail)
        {
            if (LoginDAO.hasUser(username))
            {
                return "Username is taken.";
            }
            string result_customer_add = Customers.addCustomer(name, surname, bDate, address, phone, mail);
            int result = LoginDAO.signUp_cust(username, password);
            if(result == 0)
            {
                return "Sign Up Error. Username already exists.";
            }
            else
            {
                //If there was no problem inserting into table, result should equal to 'Successful'.
                return result_customer_add;
            }
        }
    }
}
