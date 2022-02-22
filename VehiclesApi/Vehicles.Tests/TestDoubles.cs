using System;
using Moq;
using Vehicles.Gateways;
using Vehicles.Services;

namespace Vehicles.Tests
{
    public class TestDoubles
    {
        
        public static IVehicleServices MakeVehicleServices() => new VehicleServices(MakeVehicleGateway());

        public static IVehicleGateway MakeVehicleGateway()
        {
            var gateway = new Mock<IVehicleGateway>();

            gateway.Setup(e => e.GetVehicles("new user"))
                .Returns(Array.Empty<VehicleModel>());
            gateway.Setup(e => e.GetVehicles("user with 1 vehicle"))
                .Returns(new []
                {
                    new VehicleModel
                    {
                        Model = "S1",
                        VehicleId = "vehicle 1",
                        DateOfConstruction = new DateTime(2022, 01,01)
                    }
                });
            gateway.Setup(e => e.GetVehicles("another user with 1 vehicle"))
                .Returns(new []
                {
                    new VehicleModel
                    {
                        Model = "S3",
                        VehicleId = "vehicle 3",
                        DateOfConstruction = new DateTime(1987, 01,01)
                    }
                });
            gateway.Setup(e => e.GetVehicles("user with 2 vehicle"))
                .Returns(new []
                {
                    new VehicleModel
                    {
                        Model = "S3",
                        VehicleId = "vehicle 3",
                        DateOfConstruction = new DateTime(1987, 01,01)
                    },
                    new VehicleModel
                    {
                        Model = "S4",
                        VehicleId = "vehicle 4",
                        DateOfConstruction = new DateTime(2022, 01, 01)
                    },
                });

            return gateway.Object;
        }

    }
}