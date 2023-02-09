using FlightRepositories;
using FlightRepositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketBooking.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IFlightRepository flightRepo;

        public AdminController(IFlightRepository flightRepo)
        {
            this.flightRepo = flightRepo;
        }
        [HttpPost]
        public IActionResult Post(AirlinesTicketsChennaiToMumbai newFlight)
        {
            var f = flightRepo.PostFlights(newFlight);
            return Ok(f);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            var f = flightRepo.DeleteFlights(id);
            return Ok(f);
        }
    }
}
