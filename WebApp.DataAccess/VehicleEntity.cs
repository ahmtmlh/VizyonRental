using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.DataAccess
{
    public class VehicleEntityBase
    {
        public int VehicleID { get; set; }
        public string model { get; set; }
        public bool available { get; set; }
        public string economy { get; set; }
        public string price_pd { get; set; }
        public string brand { get; set; }
        public string tier { get; set; }
        public int production_year { get; set; }
        public int size { get; set; }
        public string color { get; set; }
        public string type { get; set; }
        public string img_src { get; set; }
        public int officeId { get; set; }
        
    }
    public class VehicleEntity : VehicleEntityBase
    {
        public string officeName { get; set; }
        public string getInfo()
        {
            return "Brand: " + brand + " \nModel: " + model + " \nProduction Year: " + production_year + " \nType: " + type + " \nColor: " + color; 
        }
        public decimal price(int days)
        {
            return Convert.ToDecimal(price_pd) * (decimal)days;
        }
        public bool isAvailable()
        {
            //Available holds the number of cars that are in the stock currently.
            //If stock has more than zero cars at stock, car is available.
            return available;
        }
        /**
         * This function checks if the given vehicle is the same as the current vehicle. Some attributes are not checked such as
         * color and availability since there attributes doesn't affect vehicle equality at all. All other given information must be same 
         */
        public bool isSame(VehicleEntity vehicle)
        {
            return VehicleID == vehicle.VehicleID && model.Equals(vehicle.model) && 
                economy.Equals(vehicle.economy) && price_pd.Equals(vehicle.price_pd) && brand.Equals(vehicle.brand)
                && tier.Equals(vehicle.tier) && production_year == vehicle.production_year && size == vehicle.size && type.Equals(vehicle.type);
        }
    }
}
