using System;
using System.Collections.Generic;
using WebApp.DataAccess;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Business
{
    public class Bill
    {
        public static List<BillEntity> getAllBills()
        {
            return BillDAO.getAllBills();
        }
        public static BillEntity getBillById(int bill_ID)
        {
            return BillDAO.getBillById(bill_ID);
        }
        public static string deleteBill(int bill_ID)
        {
            int res = BillDAO.deleteBill(bill_ID);
            if(res==0)
            {
                return "Bill is not found. Deletion is not successful";
            }
            else
            {
                return "Successful";
            }
        }
    }
}
