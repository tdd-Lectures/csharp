using System.Collections.Generic;

namespace Vehicles.Gateways
{
    public interface IVehicleGateway
    {
        IEnumerable<VehicleModel> GetVehicles(string userId);
        VehicleModel GetVehicle(string userId, string vehicleId);
        void BuyVehicle(string userId, string vehicleId);
    }
}
