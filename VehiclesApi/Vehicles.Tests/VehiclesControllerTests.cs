
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Vehicles.Controllers;
using Vehicles.Services;

namespace Vehicles.Tests
{
    public class VehiclesControllerTests
    {

        private static VehiclesController MakeController()
        {
            return new VehiclesController(TestDoubles.MakeVehicleServices());
        }
        
        [Test]
        public void Requesting_vehicles_from_a_new_user_returns_not_found()
        {
            var controller = MakeController();

            var result = controller.GetVehicles("new user") as NotFoundResult;

            Assert.That(result.StatusCode, Is.EqualTo(404));
        }
        
        [Test]
        public void Requesting_vehicles_from_a_user_with_one_vehicle_returns_that_vehicle()
        {
            var controller = MakeController();

            var result = controller.GetVehicles("user with 1 vehicle") as ObjectResult;

            var vehicles = result.Value as IEnumerable<Vehicle>;

            Assert.That(vehicles, Is.EqualTo(new []
            {
                new Vehicle
                {
                    Model = "S1",
                    VehicleId = "vehicle 1",
                    YearOfConstruction = 2022
                }
            }));
        }

    }
}
