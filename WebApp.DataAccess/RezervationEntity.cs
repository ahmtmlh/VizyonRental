using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class RezervationEntityBase
    {
        public int rezervationId { get; set; }
        public int customerId { get; set; }
        public string cardNumber { get; set; }
        public DateTime rezervation_date { get; set; }

    }
    public class RezervationEntitiy : RezervationEntityBase
    {
        public string customerInfo()
        {
            return null;
        }
        public string Info()
        {
            return "Date: " + rezervation_date.ToString("dd.MM.yyyy dddd") + "\n Reservation ID: " + rezervationId;
        }
        public string cardInfo()
        {
            return null;
        }
    }
}
