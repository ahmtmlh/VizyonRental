using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class Office
    {
        public static List<OfficeEntity> getAllOffices()
        {
            return OfficeDAO.getAllOffices();
        }
        public static OfficeEntity getOfficeById(int officeId)
        {
            return OfficeDAO.getOfficeById(officeId);
        }
        public static string addOffice(int officeId, string name, string address)
        {
            int res = OfficeDAO.addOffice(officeId, name, address);
            if(res == -1)
            {
                return "Insertion is not succesful. Office ID already exist";
            }
            else
            {
                return "Succesful";
            }
        }
        public static string deleteOffice(int officeId)
        {
            int res = OfficeDAO.deleteOffice(officeId);
            if (res == 0)
            {
                return "Deletion is not succesful. Check if office exist and has no car in it";
            }
            else
            {
                return "Succesful";
            }
        }
        public static int getOfficeIdByName(string office_name)
        {
            return OfficeDAO.getOfficeIdByName(office_name);
        }
        public static string updateOffice(int officeId, string attrName, string newData)
        {
            int res = OfficeDAO.update(officeId, attrName, newData);
            if(res == 0)
            {
                return "Error on update. Office doesn't exist";
            }
            else
            {
                return "Succesful";
            }
        }
    }
}
