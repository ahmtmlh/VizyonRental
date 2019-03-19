using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class Rezervation
    {
        public static int reserve(int customerId, DateTime resDate, string cardInfo)
        {
            return RezervationDAO.reserve(customerId, resDate, cardInfo);
        }
        public static int getLatestReservation()
        {
            return RezervationDAO.getLatestReservation();
        }
        public static List<RezervationEntitiy> getAllReservations()
        {
            return RezervationDAO.getAllReservations();
        }
        public static int deleteRezervation(int resId)
        {
            return RezervationDAO.deleteRezervation(resId);
        }
        public static int deleteReservationsOlderThan(DateTime date)
        {
            return RezervationDAO.deleteReservationsOlderThan(date);
        }
    }
}
