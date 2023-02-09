using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightRepositories.Data;
using FlightRepositories;

namespace FlightTicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerDetailsController : ControllerBase
    {
        private readonly FlightTBookingContext _context;

        public PassengerDetailsController(FlightTBookingContext context)
        {
            _context = context;
        }

        // GET: api/PassengerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassengerDetail>>> GetPassengerDetails()
        {
            return await _context.PassengerDetails.ToListAsync();
        }

        // GET: api/PassengerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerDetail>> GetPassengerDetail(short id)
        {
            var passengerDetail = await _context.PassengerDetails.FindAsync(id);

            if (passengerDetail == null)
            {
                return NotFound();
            }

            return passengerDetail;
        }



        public IFlightRepository flightRepo;
        
        // POST: api/PassengerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PassengerDetail>> PostPassengerDetail(PassengerDetail passengerDetail)
        {
            _context.PassengerDetails.Add(passengerDetail);
            await _context.SaveChangesAsync();
         //   flightRepo.UpdateFlightStatus((short)passengerDetail.FlightId);
            
            return CreatedAtAction("GetPassengerDetail", new { id = passengerDetail.PassengerId }, passengerDetail);
        }

        // DELETE: api/PassengerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassengerDetail(short id)
        {
            var passengerDetail = await _context.PassengerDetails.FindAsync(id);
            if (passengerDetail == null)
            {
                return NotFound();
            }

            _context.PassengerDetails.Remove(passengerDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassengerDetailExists(short id)
        {
            return _context.PassengerDetails.Any(e => e.PassengerId == id);
        }
    }
}
