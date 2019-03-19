using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class Managers
    {
        public static int mngr_IdCount = 1;
        public static List<ManagerEntity> getAllManagers()
        {
            return ManagerDAO.getAllManagers();
        }
        public static ManagerEntity getManagerById(int managerId)
        {
            if(isAcceptableId(managerId))
                return ManagerDAO.getManagerById(managerId);
            return null;
        }
        public static string updateManager(int managerId, string attrName, string newData)
        {
            if (isAcceptableId(managerId))
            {
                int result = ManagerDAO.updateManager(managerId, attrName, newData);
                if (result == 0)
                {
                    return "No manager was affected. Check if manager exist";
                }
                else
                {
                    return "Successful";
                }
            }
            else
            {
                return "Manager id can't be lower than zero";
            }
        } 
        public static string deleteManager(int managerId)
        {
            if (isAcceptableId(managerId))
            {
                int result = ManagerDAO.deleteManager(managerId);
                if (result == 0)
                {
                    return "Manager with id = " + managerId + " doesn't exist.";
                }
                else
                {
                    return "Deletion Successful";
                }
            }
            else
            {
                return "Manager id can't be lower than zero";
            }
        }
        public static string addManager(string username, string password, string name, string surname, DateTime bDate, string address, string phone, string mail)
        {
            int result = ManagerDAO.addManager(username, password, name, surname, bDate, address, phone, mail);
            if(result != -1)
            {
                return "Successful";
            }
            else
            {
                return "Error on insertion. Username already exist";
            }
        }
        private static bool isAcceptableId(int id)
        {
            //If id is less than zero, it should't be allowed to run in sql command
            return id > 0;
        }
    }
}
