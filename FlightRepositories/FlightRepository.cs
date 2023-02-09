using FlightRepositories.Data;
using FlightRepositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRepositories
{
    public class FlightRepository : IFlightRepository
    {
        FlightTBookingContext db;
        public FlightRepository() { }
        public FlightRepository(FlightTBookingContext db)
        {
            this.db = db;
        }


        public List<FlightDTO> GetFlights()
        {
            FlightDTO flightdto = new FlightDTO();
            var q = db.AirlinesTicketsChennaiToMumbais.Select(e => new FlightDTO
            {
                FlightId = e.FlightId,
                SeatNo = e.SeatNo,
                DepartureTime = (DateTime)e.DepartureTime,
                ArrivalTime = (DateTime)e.ArrivalTime,
                AirLineName = e.Airline.AirlineName,
                Price = (int)e.Price,
                FlightAvailability = e.FlightAvailability

            }).ToList();
            return q;
        }
        public List<AirlinesTicketsChennaiToMumbai> PostFlights(AirlinesTicketsChennaiToMumbai newAir)
        {
            db.AirlinesTicketsChennaiToMumbais.Add(newAir);
            db.SaveChanges();
            return db.AirlinesTicketsChennaiToMumbais.ToList();
        }
        public AirlinesTicketsChennaiToMumbai DeleteFlights(short id)
        {
            var f = db.AirlinesTicketsChennaiToMumbais.FirstOrDefault(e => e.FlightId == id);
            if (f != null)
            {
                db.AirlinesTicketsChennaiToMumbais.Remove(f);
                db.SaveChanges();
            }
            return f;
        }
        public AirlinesTicketsChennaiToMumbai UpdateFlightStatus(short id)
        {
            var f = db.AirlinesTicketsChennaiToMumbais.FirstOrDefault(e => e.FlightId == id);
            if (f != null)
            {
                f.FlightAvailability = "B";
                db.SaveChanges();
            }
            return f;
        }

    }
}
