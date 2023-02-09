using System;
using System.Collections.Generic;

namespace FlightRepositories.Data
{
    public partial class PassengerDetail
    {
        public short PassengerId { get; set; }
        public short? FlightId { get; set; }
        public short? SeatNo { get; set; }
        public decimal? Price { get; set; }
        public string PassengerName { get; set; } = null!;
        public string PassengerPhoneNo { get; set; } = null!;
        public string PassengerEmail { get; set; } = null!;

        public virtual AirlinesTicketsChennaiToMumbai? AirlinesTicketsChennaiToMumbai { get; set; }
    }
}
