using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class Rent
    {
        public static int insertRent(int reservation, int delivery_office, int receive_office, int vehicle, int customer, DateTime receiveDate, DateTime deliveryDate, decimal price)
        {
            return RentDAO.addRent(reservation, delivery_office, receive_office , vehicle , customer, receiveDate, deliveryDate, price);
        }
        public static List<RentEntity> getAllRents()
        {
            return RentDAO.getAllRents();
        }
        public static List<RentEntity> getRentBy(string attrName,object data)
        {
            return RentDAO.getRentsByField(attrName , data);
        }
        public static string endRents()
        {
            int res = RentDAO.endRents();
            if(res == 0)
            {
                return "No vehicle to refresh";
            }
            else
            {
                return "Vehicles has been refreshed";
            }
        }
        public static int deleteRentById(int rentID)
        {
            return RentDAO.deleteRentById(rentID);
        }
    }
}
