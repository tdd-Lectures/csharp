using System.Collections.Generic;

namespace Vehicles.Services
{
    public interface IVehicleServices
    {
        IEnumerable<Vehicle> GetVehicles(string userId);
        Vehicle GetVehicle(string userId, string vehicleId);
    }
}
