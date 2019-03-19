using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class OfficeEntityBase
    {
        public int OfficeId { get; set; }
        public string address { get; set; }
        public string name { get; set; }


    }
    public class OfficeEntity : OfficeEntityBase
    {
        public int Vehicle_Count { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
