using System;
using System.Collections.Generic;

namespace FlightRepositories.Data
{
    public partial class Airline
    {
        public Airline()
        {
            AirlinesTicketsChennaiToMumbais = new HashSet<AirlinesTicketsChennaiToMumbai>();
        }

        public short AirlineId { get; set; }
        public string AirlineName { get; set; } = null!;

        public virtual ICollection<AirlinesTicketsChennaiToMumbai> AirlinesTicketsChennaiToMumbais { get; set; }
    }
}
