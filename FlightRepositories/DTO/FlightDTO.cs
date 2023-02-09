using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightRepositories.DTO
{
    public class FlightDTO
    {
        public short FlightId { get; set; }
        public short SeatNo { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string? AirLineName { get; set; }
        public int Price { get; set; }
        public string? FlightAvailability { get; set; }
    }
}
