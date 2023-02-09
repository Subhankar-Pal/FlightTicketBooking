using FlightRepositories;
using FlightRepositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        public IFlightRepository flightRepo;

        public FlightController(IFlightRepository flightRepo)
        {
            this.flightRepo = flightRepo;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var flightList = flightRepo.GetFlights();
            return Ok(flightList);
        }
        




    }
}
