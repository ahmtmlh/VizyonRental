using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class CustomerEntityBase
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime CustomerBirthDay { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }

    }
    public class CustomerEntity : CustomerEntityBase
    {
        public string Info_Short()
        {
            
            {
                return CustomerName + " " + CustomerSurname;
            }
        }
        public string BirthdayStr()
        {
            
            {
                return CustomerBirthDay.ToString("dd.MM.yyyy dddd");
            }
        }
        public string Info_Long()
        {
            
            {
                //Name-Surname
                //BDate
                //Phone Number
                //E-Mail
                string info = "Customer Name: " + CustomerName + " " + CustomerSurname +
                    "\nCustomer Birthday: " + BirthdayStr() + "\nCustomer Address: " + CustomerAddress +
                    "\nCustomer Phone: " + CustomerPhone + "\nCustomer E-Mail: " + CustomerMail;
                return info;
            }
        }

    }
}
