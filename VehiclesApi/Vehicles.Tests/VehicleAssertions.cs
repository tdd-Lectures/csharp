using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Vehicles.Services;

namespace Vehicles.Tests
{
    internal static class VehicleAssertions
    {
        public static void AssertVehicles(IEnumerable<Vehicle> actual, params Vehicle[] expect)
        {
            var collection = actual.ToList();
            Assert.IsNotEmpty(collection);
            Assert.AreEqual(expect.Length, collection.Count, "the vehicles received are different from expected");
            for (var i = 0; i < expect.Length; i++)
            {
                AssertVehicle(collection[i], expect[i]);
            }
        }

        private static void AssertVehicle(Vehicle actual, Vehicle expect)
        {
            Assert.AreEqual(expect.Model, actual.Model);
            Assert.AreEqual(expect.VehicleId, actual.VehicleId);
            Assert.AreEqual(expect.YearOfConstruction, actual.YearOfConstruction);
        }
    }
}
