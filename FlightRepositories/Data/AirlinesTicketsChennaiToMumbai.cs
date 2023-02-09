using System;
using System.Collections.Generic;

namespace FlightRepositories.Data
{
    public partial class AirlinesTicketsChennaiToMumbai
    {
        public AirlinesTicketsChennaiToMumbai()
        {
            PassengerDetails = new HashSet<PassengerDetail>();
        }

        public short FlightId { get; set; }
        public short SeatNo { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public short? AirlineId { get; set; }
        public decimal Price { get; set; }
        public string FlightAvailability { get; set; } = null!;

        public virtual Airline? Airline { get; set; }
        public virtual ICollection<PassengerDetail> PassengerDetails { get; set; }
    }
}
