using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DataAccess;

namespace WebApp.Business
{
    public class Vehicle
    {
        //TODO: Add mode to determeine sorting. Maybe use stored procedures ? 
        public static List<VehicleEntity> getAllVehicles(string attribute)
        {
            return VehicleDAO.getAllVehicles(attribute);
        }
        public static VehicleEntity getVehicleById(int vehicleId)
        {
            return VehicleDAO.getVehicleById(vehicleId);
        }
        public static string addVehicle(int vehicleID, string model, bool available, string economy, decimal price_pd, string brand, string tier, int production_year, int size, string color, string type, int office_id, string img)
        {
            int res = VehicleDAO.addNewVehicle(vehicleID, model, available, economy, price_pd, brand, tier, production_year, size, color, type, office_id, img);
            if(res == -1)
            {
                return "Error on insertion. Vehicle ID exist";
            }
            else
            {
                return "Succesful";
            }
        }
        public static List<VehicleEntity> getVehicleByOfficeId(int office_id, string attribute)
        {
            return VehicleDAO.getVehicleByOfficeID(office_id, attribute);
        }
        public static string deleteVehicle(int vehicleId)
        {
            int res = VehicleDAO.deleteVehicle(vehicleId);
            if(res > 0)
            {
                return "Succesful";
            }
            else
            {
                return "No vehicle is found with given vehicle id";
            }
        }
        public static string updateVehicle(int vehicleId , string attribute_name , string newData)
        {
            int res = VehicleDAO.updateVehicle(vehicleId, attribute_name, newData);
            if(res == -1)
            {
                return "Error on update";
            }
            else if(res == 0)
            {
                return "No vehicle is found with given vehicle id";
            }
            else
            {
                return "Succesful";
            }
        }

        public static int updateVehicleStatus(int vehicleID, bool rent)
        {
            return VehicleDAO.updateRentStatus(vehicleID, rent);
        }
    }
}
