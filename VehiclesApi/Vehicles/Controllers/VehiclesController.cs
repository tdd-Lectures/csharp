using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicles.Gateways;
using Vehicles.Services;

namespace Vehicles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleServices _services;

        public VehiclesController(IVehicleServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetVehicles(string userId)
        {
            if (userId == null)
            {
                return new BadRequestResult();
            }

            try
            {
                return Ok(_services.GetVehicles(userId));
            }
            catch (GatewayException e)
            {
                return new StatusCodeResult((int)HttpStatusCode.FailedDependency);
            }
        }
    }
}
