using System;
using Moq;
using NUnit.Framework;
using Vehicles.Gateways;
using Vehicles.Services;

namespace Vehicles.Tests
{
    public class VehicleServicesTests
    {
        [Test]
        public void Returns_vehicles_from_gateway()
        {
            var service = MakeVehicleServices();

            var vehicles = service.GetVehicles("1");

            VehicleAssertions.AssertVehicles(vehicles, new[]
            {
                new Vehicle
                {
                    Model = "my model 1",
                    VehicleId = "my vehicle 1",
                    YearOfConstruction = 2019,
                },
            });
        }

        [Test]
        public void Returns_vehicles_from_gateway_that_are_not_null()
        {
            var service = MakeVehicleServices();

            var vehicles = service.GetVehicles("listWithUndefined");

            VehicleAssertions.AssertVehicles(vehicles, new[]
            {
                new Vehicle
                {
                    Model = "my model 2",
                    VehicleId = "my vehicle 2",
                    YearOfConstruction = 2010,
                },
                new Vehicle
                {
                    Model = "my model 3",
                    VehicleId = "my vehicle 3",
                    YearOfConstruction = 2020,
                },
            });
        }

        private static VehicleServices MakeVehicleServices()
        {
            var mock = new Mock<IVehicleGateway>();

            mock.Setup(e => e.GetVehicles("listWithUndefined"))
                .Returns(new[]
                {
                    new VehicleModel
                    {
                        Model = "my model 2",
                        VehicleId = "my vehicle 2",
                        DateOfConstruction = new DateTime(2010, 1, 1),
                    },
                    null,
                    new VehicleModel
                    {
                        Model = "my model 3",
                        VehicleId = "my vehicle 3",
                        DateOfConstruction = new DateTime(2020, 1, 1),
                    },
                });

            mock.Setup(e => e.GetVehicles("1"))
                .Returns(new[]
                {
                    new VehicleModel
                    {
                        Model = "my model 1",
                        VehicleId = "my vehicle 1",
                        DateOfConstruction = new DateTime(2019, 1, 1),
                    },
                });

            return new VehicleServices(mock.Object);
        }
    }
}
