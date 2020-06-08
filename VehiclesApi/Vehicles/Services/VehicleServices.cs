using System.Collections.Generic;
using System.Linq;
using Vehicles.Gateways;

namespace Vehicles.Services
{
    public class VehicleServices : IVehicleServices
    {
        private IVehicleGateway _vehicleGateway;

        public VehicleServices(IVehicleGateway vehicleGateway)
        {
            _vehicleGateway = vehicleGateway;
        }

        public IEnumerable<Vehicle> GetVehicles(string userId)
        {
            return _vehicleGateway.GetVehicles(userId)
                .Where(model => model != null)
                .Select(model => new Vehicle
                {
                    Model = model.Model,
                    VehicleId = model.VehicleId,
                    YearOfConstruction = model.DateOfConstruction.Year,
                });
        }
    }
}
