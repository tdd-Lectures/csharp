
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Vehicles.Gateways;
using Vehicles.Services;

namespace Vehicles.Tests
{
    public class VehicleServicesTests
    {

        private static IVehicleServices MakeVehicleServices() => TestDoubles.MakeVehicleServices();

        private static void AssertEqualVehicle(Vehicle actual, Vehicle expected)
        {
            Assert.That(actual.Model, Is.EqualTo(expected.Model));
            Assert.That(actual.VehicleId, Is.EqualTo(expected.VehicleId));
            Assert.That(actual.YearOfConstruction, Is.EqualTo(expected.YearOfConstruction));
        }

        [Test]
        public void Getting_vehicles_from_a_new_user_returns_empty_list()
        {
            var service = MakeVehicleServices();

            var vehicles = service.GetVehicles("new user");
            
            Assert.That(vehicles, Is.Empty);
        }

        [Test]
        public void Getting_vehicles_from_a_user_with_1_vehicle_return_that_vehicle()
        {
            var service = MakeVehicleServices();

            var vehicles = service.GetVehicles("user with 1 vehicle").ToList();
            
            Assert.That(vehicles, Is.Not.Empty);
            AssertEqualVehicle(vehicles[0], new Vehicle
            {
                Model = "S1",
                VehicleId = "vehicle 1",
                YearOfConstruction = 2022
            });
        }

        [Test]
        public void Getting_vehicles_from_another_user_with_1_vehicle_return_that_vehicle()
        {
            var service = MakeVehicleServices();

            var vehicles = service.GetVehicles("another user with 1 vehicle").ToList();
            
            Assert.That(vehicles, Is.Not.Empty);
            AssertEqualVehicle(vehicles[0], new Vehicle
            {
                Model = "S3",
                VehicleId = "vehicle 3",
                YearOfConstruction = 1987
            });
        }

        [Test]
        public void Getting_vehicles_from_user_with_2_vehicles_return_those_vehicles()
        {
            var service = MakeVehicleServices();

            var vehicles = service.GetVehicles("user with 2 vehicle").ToList();
            
            Assert.That(vehicles, Is.EqualTo(new []
            {
                new Vehicle { Model = "S3", VehicleId = "vehicle 3", YearOfConstruction = 1987},
                new Vehicle { Model = "S4", VehicleId = "vehicle 4", YearOfConstruction = 2022},
            }));
        }

    }
}
