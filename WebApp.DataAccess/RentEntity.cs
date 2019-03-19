using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class RentEntityBase
    {
        public int receive_office { get; set; }
        public int delivery_office { get; set; }
        public int rentId { get; set; }
        public int customerId { get; set; }
        public int vehicleId { get; set; }
        public DateTime receiveDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public decimal price { get; set; }
    }
    public class RentEntity : RentEntityBase
    {
        public void Info()
        {
            //Return all information as string
            //  *Both receive and delivery office information, comes from OfficeDAO.cs
            //  *Vehicle Information, comes from VehicleDAO.cs
            //  *Customer Information, comes from CustomerDAO.cs
            //  *All date and price informations.
            //  *Rent Id,
            //This function may be used in rezervation info!!!!!!
            
        }
        public void CustomerInfo()
        {

        }
        public void VehicleInfo()
        {

        }
        //whichOffice -> True: delivery Office
        //            -> False: receive Office
        public void OfficeInfo(bool whichOffice)
        {
            //Comes from OfficeDAO
        }
    }
}
