using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class Customers
    {
        public static List<CustomerEntity> getAllCustomers()
        {
            return CustomerDAO.getAllCustomers();
        }
        public static CustomerEntity getCustomerById(int customerId)
        {
            if(isAcceptableId(customerId))
                return CustomerDAO.getCustomerById(customerId);
            return null;
        }
        public static string updateCustomer(int customerId, string attrName, string newData)
        {
            if (isAcceptableId(customerId))
            {
                int result = CustomerDAO.updateCustomer(customerId, attrName, newData);
                if (result == 0)
                {
                    return "No customer was affected.\nCheck if customer exist";
                }
                else
                {
                    return "Update successful";
                }
            }
            else
            {
                return "Error on update.\nCustomer id can't be lower than 0";
            }

        }
        public static string deleteCustomer(int customerId)
        {
            if (isAcceptableId(customerId))
            {
                int result = CustomerDAO.deleteCustomer(customerId);
                if (result == 0)
                {
                    return "Customer with id = " + customerId + "\ndoesn't exist.";
                }
                else
                {
                    return "Successful";
                }
            }
            else
            {
                return "Error on deletion.\nCustomer id can't be lower than 0";
            }
        }
        public static string addCustomer(string name, string surname, DateTime bDate, string address, string phone, string mail)
        {
            int result = CustomerDAO.addCustomer(name, surname, bDate, address, phone, mail);
            if(result != -1)
            {
               return "Successful";
            }
            else
            {
                return "Error on insertion";
            }
        }
        private static bool isAcceptableId(int id)
        {
            //If id is less than zero, it should't be allowed to run in sql command
            return id > 0;
        }
    }
}
