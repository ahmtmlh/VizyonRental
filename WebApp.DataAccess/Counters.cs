using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class Counters
    {
        private static int mngr_IdCount = ManagerDAO.getMaxManagerId() + 1;
        private static int cust_IdCount = CustomerDAO.getMaxCustomerId() + 1;
        private static int office_IdCount = OfficeDAO.getMaxOfficeId() + 1;
        private static int reservation_IdCount = RezervationDAO.getMaxResId()+1 ;
        
        //UPDATE FACILITY
        public static void updateCustCount()
        {
            cust_IdCount = CustomerDAO.getMaxCustomerId() + 1;
        }
        public static void updateMngrCount()
        {
            mngr_IdCount = ManagerDAO.getMaxManagerId() + 1;
        }
        public static void updateOfficeCount()
        {
            office_IdCount = OfficeDAO.getMaxOfficeId() + 1;
        }
        public static void updateReservationCount()
        {
            reservation_IdCount = RezervationDAO.getMaxResId() + 1;
        }
        //GETTERS
        public static int getMngrCount()
        {
            return mngr_IdCount;
        }
        public static int getCustCount()
        {
            return cust_IdCount;
        }
        public static int getReservationCount()
        {
            return reservation_IdCount;
        }
        public static int getOfficeCount()
        {
            return office_IdCount;
        }
        //INCREMENTERS
        public static void incrementMngrCount()
        {
            mngr_IdCount++;
        }
        public static void incrementCustCount()
        {
            cust_IdCount++;
        }
        public static void incrementReservationCount()
        {
            reservation_IdCount++;
        }
        public static void incrementOfficeCount()
        {
            office_IdCount++;
        }
    }
}
