using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class ManagerEntityBase
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public DateTime ManagerBirthDate { get; set; }
        public string ManagerAddress { get; set; }
        public string ManagerPhone { get; set; }
        public string ManagerMail { get; set; }

    }
    public class ManagerEntity : ManagerEntityBase
    {
        public string Info_Short
        {
            get
            {
                return ManagerName + " " + ManagerSurname;
            }
        }
        public string BirthDateStr
        {
            get
            {
                return ManagerBirthDate.ToString("dd.MM.yyyy dddd");
            }
        }
        public string Info_Long
        {
            get
            {
                string info = "Manager Name: " + ManagerName + " " + ManagerSurname + 
                    "\nManager Birth Date: " + BirthDateStr + "\nManager Address: " + ManagerAddress+ 
                    "\nManager Phone: " + ManagerPhone + "\nManager E-Mail: " + ManagerMail;
                return info;
            }
        }
    }
}
