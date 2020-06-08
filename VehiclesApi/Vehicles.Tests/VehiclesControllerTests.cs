using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Vehicles.Controllers;
using Vehicles.Gateways;
using Vehicles.Services;

namespace Vehicles.Tests
{
    public class VehiclesControllerTests
    {
        [Test]
        public void Getting_vehicles_without_user_a_bad_request()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles(null) as BadRequestResult;

            Assert.IsNotNull(result);
            Assert.AreEqual((int) HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void Getting_vehicles_returns_a_failed_dependency_when_unable_to_query_data()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("gatewayError") as StatusCodeResult;

            Assert.IsNotNull(result);
            Assert.AreEqual((int) HttpStatusCode.FailedDependency, result.StatusCode);
        }

        [Test]
        public void When_service_throws_exception_throws_exception_with_reason()
        {
            var controller = MakeVehiclesController();

            Assert.Throws<Exception>(() => controller.GetVehicles("unknownError"));
        }

        [Test]
        public void Getting_vehicles_returns_vehicles_for_the_given_user()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("1") as ObjectResult;

            Assert.IsNotNull(result, "result != null");
            Assert.IsNotNull(result.Value as IEnumerable<Vehicle>, "result.Value as IEnumerable<Vehicle> != null");

            var expect = new Vehicle
            {
                Model = "1",
                VehicleId = "2",
                YearOfConstruction = 2019
            };

            VehicleAssertions.AssertVehicles(result.Value as IEnumerable<Vehicle>, expect);
        }

        [Test]
        public void Getting_vehicles_returns_empty_list_vehicles_when_service_returns_empty_list()
        {
            var controller = MakeVehiclesController();

            var result = controller.GetVehicles("emptyList") as ObjectResult;

            Assert.IsNotNull(result, "result != null");
            Assert.IsNotNull(result.Value as IEnumerable<Vehicle>, "result.Value as IEnumerable<Vehicle> != null");
            Assert.IsEmpty(result.Value as IEnumerable<Vehicle>);
        }

        private static VehiclesController MakeVehiclesController()
        {
            return new VehiclesController(MakeVehicleServices());
        }

        private static IVehicleServices MakeVehicleServices()
        {
            static void SetupGetVehicles(Mock<IVehicleServices> mock, string userId, params Vehicle[] vehicles)
            {
                mock.Setup(e => e.GetVehicles(userId))
                    .Returns(vehicles);
            }

            var servicesMock = new Mock<IVehicleServices>();

            servicesMock
                .Setup(e => e.GetVehicles("unknownError"))
                .Throws(new Exception());

            servicesMock
                .Setup(e => e.GetVehicles("gatewayError"))
                .Throws(new GatewayException());

            SetupGetVehicles(servicesMock,
                "1",
                new Vehicle
                {
                    Model = "1",
                    VehicleId = "2",
                    YearOfConstruction = 2019
                }
            );

            return servicesMock.Object;
        }
    }
}
